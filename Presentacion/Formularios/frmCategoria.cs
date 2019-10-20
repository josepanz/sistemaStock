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
            dgvCategoria.DataSource = Categoria.listaCategoria;
        }

        private void LimpiarFormulario()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();
            categoria.codigo = txtCodigo.Text;
            categoria.descripcion = txtDescripcion.Text;
            Categoria.AgregarCategoria(categoria);

            ListarCategoria();
            LimpiarFormulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Categoria cat = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;
            if (cat != null)
            {
                Categoria.listaCategoria.Remove(cat);
            }
            ListarCategoria();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Categoria cat = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;

            if (cat!= null)
            {
                int index = dgvCategoria.CurrentCell.RowIndex;
                Categoria.listaCategoria[index] = ObtenerCategoria();
                ListarCategoria();
            }

            
        }
        private Categoria ObtenerCategoria()
        {
            Categoria categoria = new Categoria();
            categoria.codigo = txtCodigo.Text;
            categoria.descripcion = txtDescripcion.Text;


            return categoria;
        }

        private void dgvCategoria_Click(object sender, EventArgs e)
        {
                Categoria cat = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;

                if (cat != null)
                {
                    txtCodigo.Text = cat.codigo ;
                    txtDescripcion.Text = cat.descripcion;
                    
                }
            
        }
    }
}
