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

namespace capaPresentacion
{
    public partial class frmCargo : Form
    {
        public frmCargo()
        {
            InitializeComponent();
        }

        private void Cargo_Load(object sender, EventArgs e)
        {
            ListarCargo();
        }

        private void ListarCargo()
        {
            dgvCargo.DataSource = null;
            dgvCargo.DataSource = Cargo.listaCargos;
        }

        private void LimpiarFormulario()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cargo c = ObtenerCargoFormulario();
            Cargo.AgregarCargo(c);
            ListarCargo();
            LimpiarFormulario();
        }

        private Cargo ObtenerCargoFormulario()
        {
            Cargo c = new Cargo();
            c.descripcion = txtDescripcion.Text;
            return c;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cargo cat = (Cargo)dgvCargo.CurrentRow.DataBoundItem;
            if (cat != null)
            {
                Cargo.EliminarCargo(cat);
                ListarCargo();
                LimpiarFormulario();
            }
            ListarCargo();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Cargo cat = (Cargo)dgvCargo.CurrentRow.DataBoundItem;

            if (cat != null)
            {
                int index = dgvCargo.CurrentCell.RowIndex;
                Cargo c = ObtenerCargoFormulario();
                Cargo.EditarCargo(index, c);
                ListarCargo();
            }


        }

        private Cargo ObtenerCargo()
        {
            Cargo cargo = new Cargo();
            cargo.id = Convert.ToInt32(txtCodigo.Text);
            cargo.descripcion = txtDescripcion.Text;


            return cargo;
        }
        private void dgvCargo_Click(object sender, EventArgs e)
        {
            Cargo cat = (Cargo)dgvCargo.CurrentRow.DataBoundItem;

            if (cat != null)
            {
                txtCodigo.Text = Convert.ToString(cat.id);
                txtDescripcion.Text = cat.descripcion;

            }

        }


    }
}
