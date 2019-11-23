using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;

namespace Presentacion.Formularios
{
    public partial class frmEmpleado : Form
    {
        public string modo;

        public frmEmpleado()
        {
            InitializeComponent();
            panel3.Enabled = false;
        }

        private void ListarEmpleado()
        {         
             dgvEmpleado.DataSource = null;
             dgvEmpleado.DataSource = Empleado.ObtenerEmpleados();
            dgvEmpleado.ClearSelection();
            //this.dgvEmpleado.Columns["idPK"].Visible = false;
            dgvEmpleado.Columns[0].HeaderText = "Código interno";
             dgvEmpleado.Columns[1].HeaderText = "Cédula de identidad";
             dgvEmpleado.Columns[2].HeaderText = "Nombre";
             dgvEmpleado.Columns[3].HeaderText = "E-mail";
             dgvEmpleado.Columns[4].HeaderText = "Fecha de nacimiento";
             //dgvEmpleado.Columns[5].HeaderText = "Contraseña";
             dgvEmpleado.Columns[6].HeaderText = "Cargo";
             dgvEmpleado.Columns[5].Visible = false;
            
        }

        private void FormEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                ListarEmpleado();
                cboCargo.DataSource = Cargo.ObtenerCargos();
                cboCargo.SelectedItem = null;
                dgvEmpleado.AllowUserToResizeColumns = false;
                dgvEmpleado.AllowUserToResizeRows = false;                
                txtBuscar.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
        }

        private Empleado ObtenerEmpleadoFormulario()
        {
            Empleado empl = new Empleado();
            if (!string.IsNullOrEmpty(txtidPK.Text))
            {
                empl.idPK = Convert.ToInt32(txtidPK.Text);

            }
            if (txtIDNumero.Text != "")
            {
                empl.idNumero = Convert.ToInt32(txtIDNumero.Text);
            }
            else
            {
                MessageBox.Show("El número de identificación es obligatorio");
                txtIDNumero.Focus();
                return null;
            }
            if (txtNombre.Text != "")
            {
                empl.nombre = txtNombre.Text.ToUpper();
            }
            else
            {
                MessageBox.Show("El nombre es obligatorio");
                txtNombre.Focus();
                return null;
            }
            if (txtEmail.Text != "")
            {
                empl.email = txtEmail.Text;
            }
            else
            {
                MessageBox.Show("El email es obligatorio");
                txtEmail.Focus();
                return null;
            }
            if (cboCargo.SelectedItem != null)
            {
                empl.cargo = (Cargo)cboCargo.SelectedItem;
            }
            else
            {
                MessageBox.Show("El cargo es obligatorio");
                cboCargo.Focus();
                return null;
            }
            empl.pass = txtPass.Text;
            empl.nacimiento = txtFechaNac.Value.Date;
            return empl;
        }

        private void limpiar()
        {
            panel3.Enabled = false;
            txtEmail.Clear();
            txtIDNumero.Clear();
            txtNombre.Clear();
            cboCargo.SelectedItem = null;
            txtPass.Clear();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            modo = "I";
            limpiar();
            panel3.Enabled = true;
            panel1.Enabled = false;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            modo = "E";
            Empleado empleado = new Empleado();
            if (dgvEmpleado.SelectedCells.Count > 0)
            {
                panel3.Enabled = true;
                panel1.Enabled = false;
                empleado = (Empleado)dgvEmpleado.CurrentRow.DataBoundItem;
                //empleado.idPK = Convert.ToInt32(dgvEmpleado.CurrentRow.Cells[0].Value);
                txtidPK.Text = empleado.idPK.ToString();
                txtIDNumero.Text = empleado.idNumero.ToString();
                txtNombre.Text = empleado.nombre;
                txtEmail.Text = empleado.email;
                txtFechaNac.Value = empleado.nacimiento;
                //cboCargo.SelectedItem = empleado.cargo.id;
                if (empleado.cargo != null)
                {
                    cboCargo.SelectedItem = Cargo.ObtenerCargo(empleado.cargo.id);
                }
                      
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            int idPK;
            if (dgvEmpleado.SelectedCells.Count > 0)
            {
                idPK = Convert.ToInt32(dgvEmpleado.CurrentRow.Cells[0].Value);
                if (MessageBox.Show("¿Está seguro de eliminar el registro?", "Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Empleado.EliminarEmpleado(idPK);
                    ListarEmpleado();
                    MessageBox.Show("Registro eliminado", "Baja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            var result = Empleado.ObtenerEmpleados().Where(x => x.idNumero.ToString().Contains(txtBuscar.Text)).ToList();
            dgvEmpleado.DataSource = result;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado empl = null;
                if (modo == "I")
                {
                    empl = ObtenerEmpleadoFormulario();
                    if (empl != null)
                    {
                        Empleado.AgregarEmpleado(empl);
                        MessageBox.Show("Registro insertado correctamente", "Alta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarEmpleado();
                        limpiar();
                        panel3.Enabled = false;
                        panel1.Enabled = true;
                    }
                }
                else if (modo == "E")
                {
                    int index = Convert.ToInt32(dgvEmpleado.CurrentRow.Cells[0].Value);
                    empl = ObtenerEmpleadoFormulario();
                    if (empl != null)
                    {
                        Empleado.EditarEmpleado(index, empl);
                        MessageBox.Show("Registro editado correctamente", "Modificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarEmpleado();
                        limpiar();
                        panel3.Enabled = false;
                        panel1.Enabled = true;
                    }
                    txtBuscar.Focus();
                }
            }
            catch (Exception ex)
            {
                System.Data.SqlClient.SqlException sqlEx = ex as System.Data.SqlClient.SqlException;
                if (sqlEx != null && sqlEx.Number == 2601)
                {
                    MessageBox.Show("No se pude insertar el registro. Registro duplicado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIDNumero.Focus();
                }
                else
                {
                    MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIDNumero.Focus();
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            panel3.Enabled = false;
            panel1.Enabled = true;
        }

        private void DgvEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmpleado.RowCount > 0)
                {
                    Empleado emp = (Empleado)dgvEmpleado.CurrentRow.DataBoundItem;
                    if (emp != null)
                    {
                        txtidPK.Text = Convert.ToString(emp.idPK);
                        txtIDNumero.Text = Convert.ToString(emp.idNumero);
                        txtNombre.Text = emp.nombre;
                        txtEmail.Text = emp.email;
                        txtFechaNac.Value = emp.nacimiento;
                        cboCargo.SelectedItem = Cargo.ObtenerCargo(emp.cargo.id);
                    }                    
                }
                else
                {
                    MessageBox.Show("No hay registros para seleccionar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
