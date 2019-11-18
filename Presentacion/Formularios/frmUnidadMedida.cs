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
    public partial class frmUnidadMedida : Form
    {
        public frmUnidadMedida()
        {
            InitializeComponent();
        }
        private void frmUnidadMedida_Load(object sender, EventArgs e)
        {
            ListarUnidadMedida();
        }
        private void ListarUnidadMedida()
        {
            dgvUnidadMedida.DataSource = null;
            dgvUnidadMedida.DataSource = UnidadMedida.ObtenerUnidades();
        }

        private void LimpiarFormulario()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            UnidadMedida m = ObtenerUnidadMedidaFormulario();
            UnidadMedida.AgregarUnidad(m);
            ListarUnidadMedida();
            LimpiarFormulario();
        }

        private UnidadMedida ObtenerUnidadMedidaFormulario()
        {
            UnidadMedida unidadMedida = new UnidadMedida();
            unidadMedida.descripcion = txtDescripcion.Text.Trim();
            try
            {
                unidadMedida.id = Convert.ToInt32(txtCodigo.Text.Trim());
            }
            catch(FormatException f)
            {
            }

            return unidadMedida;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            UnidadMedida mar = (UnidadMedida)dgvUnidadMedida.CurrentRow.DataBoundItem;
            if (mar != null)
            {
                UnidadMedida.EliminarUnidadMedidas(mar);
                ListarUnidadMedida();
                LimpiarFormulario();
            }
            ListarUnidadMedida();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            UnidadMedida unidadMedida = (UnidadMedida)dgvUnidadMedida.CurrentRow.DataBoundItem;

            if (unidadMedida != null)
            {
                int index = dgvUnidadMedida.CurrentCell.RowIndex;
                UnidadMedida m = ObtenerUnidadMedidaFormulario();
                UnidadMedida.EditarUnidadMedida(index, m);
                ListarUnidadMedida();
                LimpiarFormulario();
            }
        }

        private UnidadMedida ObtenerUnidadMedida()
        {
            UnidadMedida mar = new UnidadMedida();
            mar.id = Convert.ToInt32(txtCodigo.Text);
            mar.descripcion = txtDescripcion.Text.Trim();


            return mar;
        }

        private void dgvUnidadMedida_Click(object sender, EventArgs e)
        {
            UnidadMedida mar = (UnidadMedida)dgvUnidadMedida.CurrentRow.DataBoundItem;

            if (mar != null)
            {
                txtCodigo.Text = Convert.ToString(mar.id);
                txtDescripcion.Text = mar.descripcion;

            }
        }
    }
}
