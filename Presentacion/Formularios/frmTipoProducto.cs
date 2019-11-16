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
    public partial class frmTipoProducto : Form
    {
        public frmTipoProducto()
        {
            InitializeComponent();
        }

        private void frmTipoProducto_Load(object sender, EventArgs e)
        {
            ListarTipoProducto();
        }

        private void ListarTipoProducto()
        {
            dgvTipoProducto.DataSource = null;
            dgvTipoProducto.DataSource = TipoProducto.listaTipoProductos;
        }

        private void LimpiarFormulario()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            TipoProducto tipo = new TipoProducto();
            tipo.codigo = Convert.ToInt32(txtCodigo.Text);
            tipo.descripcion = txtDescripcion.Text;
            TipoProducto.AgregarProductos(tipo);

            ListarTipoProducto();
            LimpiarFormulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            TipoProducto tipo = (TipoProducto)dgvTipoProducto.CurrentRow.DataBoundItem;
            if (tipo != null)
            {
                TipoProducto.listaTipoProductos.Remove(tipo);
            }
            ListarTipoProducto();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            TipoProducto tipo = (TipoProducto)dgvTipoProducto.CurrentRow.DataBoundItem;

            if (tipo != null)
            {
                int index = dgvTipoProducto.CurrentCell.RowIndex;
                TipoProducto.listaTipoProductos[index] = ObtenerTipoProducto();
                ListarTipoProducto();
            }
        }

        private TipoProducto ObtenerTipoProducto()
        {
            TipoProducto tipo = new TipoProducto();
            tipo.codigo = Convert.ToInt32(txtCodigo.Text);
            tipo.descripcion = txtDescripcion.Text;


            return tipo;
        }

        private void dgvTipoProducto_Click(object sender, EventArgs e)
        {
            TipoProducto tipo = (TipoProducto)dgvTipoProducto.CurrentRow.DataBoundItem;

            if (tipo != null)
            {
                txtCodigo.Text = Convert.ToString(tipo.codigo);
                txtDescripcion.Text = tipo.descripcion;

            }
        }
    }


}
