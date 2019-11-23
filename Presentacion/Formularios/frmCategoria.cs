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

        private void ListarCategoria()
        {
            dgvCategoria.DataSource = null;
            dgvCategoria.DataSource = Categoria.ObtenerCategorias();
            dgvCategoria.ClearSelection();
            dgvCategoria.Columns[0].HeaderText = "Código interno";
            dgvCategoria.Columns[1].HeaderText = "Descripción";
        }
        private void Categoria_Load(object sender, EventArgs e)
        {
            try
            {
                ListarCategoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private Categoria ObtenerCategoriaFormulario()
        {
            Categoria c = new Categoria();
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                c.id = Convert.ToInt32(txtCodigo.Text);
            }
            if (txtDescripcion.Text != "")
            {
                c.descripcion = txtDescripcion.Text;
            }
            else
            {
                MessageBox.Show("La descripción es obligatoria");
                txtDescripcion.Focus();
                return null;
            }
            return c;
        }


        private void LimpiarFormulario()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObtenerCategoriaFormulario() != null)
                {
                    Categoria c = ObtenerCategoriaFormulario();
                    Categoria.AgregarCategoria(c);
                    ListarCategoria();
                    LimpiarFormulario();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCategoria.SelectedCells.Count > 0)
                {
                    Categoria cat = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;
                    if (cat != null)
                    {
                        if (MessageBox.Show("¿Está seguro de eliminar el registro?", "Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            Categoria.EliminarCategorias(cat);
                            MessageBox.Show("Registro eliminado", "Baja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ListarCategoria();
                            LimpiarFormulario();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una fila");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
            
        

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCategoria.SelectedCells.Count > 0)
                {
                    Categoria cat = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;

                    if (cat != null)
                    {
                        if (ObtenerCategoriaFormulario() != null)
                        {
                            int index = dgvCategoria.CurrentCell.RowIndex;
                            Categoria c = ObtenerCategoriaFormulario();
                            Categoria.EditarCategorias(index, c);
                            MessageBox.Show("Registro editado correctamente", "Modificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ListarCategoria();
                            LimpiarFormulario();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una fila");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

      
        private void dgvCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCategoria.RowCount > 0)
                {
                    Categoria cat = (Categoria)dgvCategoria.CurrentRow.DataBoundItem;

                    if (cat != null)
                    {
                        txtCodigo.Text = Convert.ToString(cat.id);
                        txtDescripcion.Text = cat.descripcion;
                    
                    }
                }
                else
                {
                    MessageBox.Show("No hay registros para seleccionar");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        
    }
}
