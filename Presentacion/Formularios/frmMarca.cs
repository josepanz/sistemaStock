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

namespace capaPresentacion.Formularios
{
    public partial class frmMarca : Form
    {
        public frmMarca()
        {
            InitializeComponent();
        }

        private void frmMarca_Load(object sender, EventArgs e)
        {
            ListarMarca();
        }
        private void ListarMarca()
        {
            dgvMarca.DataSource = null;
            dgvMarca.DataSource = Marca.ObtenerMarcas();
        }

        private void LimpiarFormulario()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Marca m = ObtenerMarcaFormulario();
            Marca.AgregarMarca(m);
            ListarMarca();
            LimpiarFormulario();
        }

        private Marca ObtenerMarcaFormulario()
        {
            Marca marca = new Marca();
            marca.descripcion = txtDescripcion.Text.Trim();
            marca.id = Convert.ToInt32(txtCodigo.Text.Trim());
            return marca;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Marca mar = (Marca)dgvMarca.CurrentRow.DataBoundItem;
            if (mar != null)
            {
                Marca.EliminarMarcas(mar);
                ListarMarca();
                LimpiarFormulario();
            }
            ListarMarca();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Marca marca = (Marca)dgvMarca.CurrentRow.DataBoundItem;

            if (marca != null)
            {
                int index = dgvMarca.CurrentCell.RowIndex;
                Marca m = ObtenerMarcaFormulario();
                Marca.EditarMarca(index, m);
                ListarMarca();
                LimpiarFormulario();
            }
        }

        private Marca ObtenerMarca()
        {
            Marca mar = new Marca();
            mar.id = Convert.ToInt32(txtCodigo.Text);
            mar.descripcion = txtDescripcion.Text.Trim();


            return mar;
        }

        private void dgvMarca_Click(object sender, EventArgs e)
        {
            Marca mar = (Marca)dgvMarca.CurrentRow.DataBoundItem;

            if (mar != null)
            {
                txtCodigo.Text = Convert.ToString(mar.id);
                txtDescripcion.Text = mar.descripcion;

            }
        }
    }
}
