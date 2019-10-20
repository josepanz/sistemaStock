using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio.Modelos;
using Negocio.ObjetosValores;



namespace Presentacion.Formularios
{
    public partial class frmEmpleado : Form
    {
        private ModeloEmpleado empleado = new ModeloEmpleado();
        public frmEmpleado()
        {
            InitializeComponent();
            panel3.Enabled = false;
        }

        private void FormEmpleado_Load(object sender, EventArgs e)
        {
            ListarEmpleado();
        }

        private void ListarEmpleado()
        {
            try
            {
                dgvEmpleado.DataSource = empleado.GetAll();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            //dgvEmpleado.DataSource = empleado.findById(txtBuscar.Text);
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            dgvEmpleado.DataSource = empleado.findById(txtBuscar.Text);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            empleado.IdNumero = txtIDNumero.Text;
            empleado.Email = txtEmail.Text;
            empleado.Nombre = txtNombre.Text;
            empleado.Nacimiento = txtFechaNac.Value;

            bool valid = new Soportes.ValidacionDatos(empleado).Validate();
            if(valid == true)
            {
                string result = empleado.SaveChanges();
                MessageBox.Show(result);
                ListarEmpleado();
                limpiar();
            }
        }
        private void limpiar()
        {
            panel3.Enabled = false;
            txtEmail.Clear();
            txtIDNumero.Clear();
            txtNombre.Clear();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            panel3.Enabled = true;
            empleado.Estado = EstadoEntidad.Agregado;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if(dgvEmpleado.SelectedRows.Count > 0)
            {
                panel3.Enabled = true;
                empleado.Estado = EstadoEntidad.Modificado;
                empleado.IdPK = Convert.ToInt32(dgvEmpleado.CurrentRow.Cells[0].Value);
                txtIDNumero.Text=dgvEmpleado.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = dgvEmpleado.CurrentRow.Cells[2].Value.ToString();
                txtEmail.Text = dgvEmpleado.CurrentRow.Cells[3].Value.ToString();
                txtFechaNac.Value = Convert.ToDateTime(dgvEmpleado.CurrentRow.Cells[4].Value);
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleado.SelectedRows.Count > 0)
            {
                empleado.Estado = EstadoEntidad.Eliminado;
                empleado.IdPK = Convert.ToInt32(dgvEmpleado.CurrentRow.Cells[0].Value);
                string result = empleado.SaveChanges();
                MessageBox.Show(result);
                ListarEmpleado();
                
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }

        }
    }
}
