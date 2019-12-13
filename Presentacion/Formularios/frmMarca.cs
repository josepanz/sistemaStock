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

        private void ListarMarca()
        {
            dgvMarca.DataSource = null;
            dgvMarca.DataSource = Marca.ObtenerMarcas();
            dgvMarca.ClearSelection();
            dgvMarca.Columns[0].HeaderText = "Código interno";
            dgvMarca.Columns[1].HeaderText = "Descripción";
        }

        private void LimpiarFormulario()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
        }

        private void frmMarca_Load(object sender, EventArgs e)
        {
            try
            {
                ListarMarca();
                txtDescripcion.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private Marca ObtenerMarcaFormulario()
        {
            Marca marca = new Marca();
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                marca.id = Convert.ToInt32(txtCodigo.Text.Trim());
            }
            if (txtDescripcion.Text != "")
            {
                marca.descripcion = txtDescripcion.Text.Trim();
            }
            else
            {
                MessageBox.Show("La descripción es obligatoria");
                txtDescripcion.Focus();
                return null;
            }
            return marca;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObtenerMarcaFormulario() != null)
                {
                    Marca m = ObtenerMarcaFormulario();
                    Marca.AgregarMarca(m);
                    MessageBox.Show("Registro insertado correctamente", "Alta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarMarca();
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
                if (dgvMarca.SelectedCells.Count > 0)
                {
                    Marca mar = (Marca)dgvMarca.CurrentRow.DataBoundItem;
                    if (mar != null)
                    {
                        Marca.EliminarMarcas(mar);                       
                        ListarMarca();
                        MessageBox.Show("Registro eliminado", "Baja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarFormulario();
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
                if (dgvMarca.SelectedCells.Count > 0)
                {
                    Marca marca = (Marca)dgvMarca.CurrentRow.DataBoundItem;

                    if (marca != null)
                    {
                        int index = dgvMarca.CurrentCell.RowIndex;
                        if (ObtenerMarcaFormulario() != null)
                        {
                            Marca m = ObtenerMarcaFormulario();
                            Marca.EditarMarca(index, m);
                            ListarMarca();
                            MessageBox.Show("Registro editado correctamente", "Modificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        private void dgvMarca_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMarca.RowCount > 0)
                {
                    Marca mar = (Marca)dgvMarca.CurrentRow.DataBoundItem;

                    if (mar != null)
                    {
                        txtCodigo.Text = Convert.ToString(mar.id);
                        txtDescripcion.Text = mar.descripcion.Trim();

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
