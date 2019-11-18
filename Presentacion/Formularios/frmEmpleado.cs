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
                Empleado.AgregarEmpleado(empl);
            }
            else if (modo == "E")
            {

                if (dgvEmpleado.SelectedCells.Count > 0)
                {                    
                    int index = Convert.ToInt32(dgvEmpleado.CurrentRow.Cells[0].Value);
                    empl = ObtenerEmpleadoFormulario();
                    Empleado.EditarEmpleado(index, empl);                    

                }
                else
                {
                    MessageBox.Show("Seleccione una fila");
                }
                
            }

            ListarEmpleado();
            limpiar();
            panel3.Enabled = false;


        }

        private Empleado ObtenerEmpleadoFormulario()
        {
            Empleado empl = new Empleado();
            if (!string.IsNullOrEmpty(txtidPK.Text))
            {
                empl.idPK = Convert.ToInt32(txtidPK.Text);
            }

            empl.idNumero = Convert.ToInt32(txtIDNumero.Text);
            empl.nombre = txtNombre.Text;
            empl.email = txtEmail.Text;
            empl.nacimiento = txtFechaNac.Value.Date;
            empl.cargo = (Cargo)cboCargo.SelectedItem;
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
                cboCargo.SelectedItem = empleado.cargo;
                modo = "E";


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
                cboCargo.SelectedItem = emp.cargo;

            }
        }
    }
}
