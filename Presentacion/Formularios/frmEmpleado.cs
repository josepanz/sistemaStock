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

        private void FormEmpleado_Load(object sender, EventArgs e)
        {
            ListarEmpleado();
            cboCargo.DataSource = Cargo.ObtenerCargos();
            cboCargo.SelectedItem = null;
        }

        private void ListarEmpleado()
        {
            try
            {
                dgvEmpleado.DataSource = null;
                dgvEmpleado.DataSource = Empleado.ObtenerEmpleados();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }        

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            dgvEmpleado.DataSource = Empleado.ObtenerEmpleado(Convert.ToInt32((txtBuscar.Text)));
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvEmpleado.DataSource = Empleado.ObtenerEmpleado(Convert.ToInt32((txtBuscar.Text)));
            } catch (FormatException f) {
                MessageBox.Show("La busqueda debe realizarse por codigo y en valores numericos");
            }

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Empleado empl = null;
            if (modo == "I")
            {
                empl = ObtenerEmpleadoFormulario();
                if (empl.cargo != null)
                {
                    Empleado.AgregarEmpleado(empl);
                    ListarEmpleado();
                    limpiar();
                    panel3.Enabled = false;
                }
            }
            else if (modo == "E")
            {

                int index = Convert.ToInt32(dgvEmpleado.CurrentRow.Cells[0].Value);
                empl = ObtenerEmpleadoFormulario();

                Empleado.EditarEmpleado(index, empl);
                ListarEmpleado();
                limpiar();
                panel3.Enabled = false;


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
            }

            if (txtNombre.Text != "")
            {
                empl.nombre = txtNombre.Text;
            }
            else
            {
                MessageBox.Show("El nombre es obligatorio");
                txtIDNumero.Focus();
            }

            if (txtEmail.Text != "")
            {
                empl.email = txtEmail.Text;
            }
            else
            {
                MessageBox.Show("El email es obligatorio");
                txtIDNumero.Focus();
            }

            if (cboCargo.SelectedItem != null)
            {
                empl.cargo = (Cargo)cboCargo.SelectedItem;
            }
            else
            {
                MessageBox.Show("El cargo es obligatorio");
                txtIDNumero.Focus();
            }




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
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            modo = "I";
            limpiar();
            panel3.Enabled = true;
            
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            modo = "E";
            Empleado empleado = new Empleado();
            if(dgvEmpleado.SelectedCells.Count > 0)
            {
                panel3.Enabled = true;
                empleado = (Empleado)dgvEmpleado.CurrentRow.DataBoundItem;
                //empleado.idPK = Convert.ToInt32(dgvEmpleado.CurrentRow.Cells[0].Value);
                txtidPK.Text = empleado.idPK.ToString();
                txtIDNumero.Text=empleado.idNumero.ToString();
                txtNombre.Text = empleado.nombre;
                txtEmail.Text = empleado.email;
                txtFechaNac.Value = empleado.nacimiento;
                //cboCargo.SelectedItem = empleado.cargo.id;
                cboCargo.SelectedItem = Cargo.ObtenerCargo(empleado.cargo.id);



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

                Empleado.EliminarEmpleado(idPK);
                 
                 ListarEmpleado();

             }
             else
             {
                 MessageBox.Show("Seleccione una fila");
             }
     
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DgvEmpleado_Click(object sender, EventArgs e)
        {
            Empleado emp = (Empleado)dgvEmpleado.CurrentRow.DataBoundItem;

            if (emp != null)
            {
                txtidPK.Text = Convert.ToString(emp.idPK);
                txtIDNumero.Text = Convert.ToString(emp.idNumero);
                txtNombre.Text = emp.nombre;
                txtEmail.Text = emp.email;
                txtFechaNac.Value = emp.nacimiento;
                //cboCargo.SelectedItem = emp.cargo;
                cboCargo.SelectedItem = Cargo.ObtenerCargo(emp.cargo.id);

            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            panel3.Enabled = false;
        }
    }
}
