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
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }
        private void Categoria_Load(object sender, EventArgs e)
        {
            ListarCategoria();
        }

        private void ListarCategoria()
        {
            dgvCategoria.DataSource = null;
            dgvCategoria.DataSource = Categoria.ObtenerCategorias();
        }

        private void LimpiarFormulario()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Categoria c = ObtenerCategoriaFormulario();
            Categoria.AgregarCategoria(c);
            ListarCategoria();
            LimpiarFormulario();
        }

        private Categoria ObtenerCategoriaFormulario()
        {
            Categoria c = new Categoria();
            c.descripcion = txtDescripcion.Text;
            try
            {
                c.id = Convert.ToInt32(txtCodigo.Text);
            } catch (FormatException f) {
            }
            return c;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Categoria cat = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;
            if (cat != null)
            {
                Categoria.EliminarCategorias(cat);
                ListarCategoria();
                LimpiarFormulario();
            }
            ListarCategoria();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Categoria cat = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;

            if (cat!= null)
            {
                int index = dgvCategoria.CurrentCell.RowIndex;
                Categoria c = ObtenerCategoriaFormulario();
                Categoria.EditarCategorias(index, c);
                ListarCategoria();
            }

            
        }
        private Categoria ObtenerCategoria()
        {
            Categoria categoria = new Categoria();
            categoria.id = Convert.ToInt32(txtCodigo.Text);
            categoria.descripcion = txtDescripcion.Text;


            return categoria;
        }

        private void dgvCategoria_Click(object sender, EventArgs e)
        {
                Categoria cat = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;

                if (cat != null)
                {
                    txtCodigo.Text = Convert.ToString(cat.id);
                    txtDescripcion.Text = cat.descripcion;
                    
                }
            
        }
    }
}
