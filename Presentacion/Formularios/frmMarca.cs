using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos.Entidades;

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
            dgvMarca.DataSource = Marca.listaMarca;
        }

        private void LimpiarFormulario()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca();
            marca.codigo = txtCodigo.Text;
            marca.descripcion = txtDescripcion.Text;
            Marca.AgregarMarca(marca);

            ListarMarca();
            LimpiarFormulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Marca mar = (Marca)dgvMarca.CurrentRow.DataBoundItem;
            if (mar != null)
            {
                Marca.listaMarca.Remove(mar);
            }
            ListarMarca();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Marca marca = (Marca)dgvMarca.CurrentRow.DataBoundItem;

            if (marca != null)
            {
                int index = dgvMarca.CurrentCell.RowIndex;
                Marca.listaMarca[index] = ObtenerMarca();
                ListarMarca();
            }
        }

        private Marca ObtenerMarca()
        {
            Marca mar = new Marca();
            mar.codigo = txtCodigo.Text;
            mar.descripcion = txtDescripcion.Text;


            return mar;
        }

        private void dgvMarca_Click(object sender, EventArgs e)
        {
            Marca mar = (Marca)dgvMarca.CurrentRow.DataBoundItem;

            if (mar != null)
            {
                txtCodigo.Text = mar.codigo;
                txtDescripcion.Text = mar.descripcion;

            }
        }
    }
}
