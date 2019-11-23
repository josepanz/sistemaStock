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

        private void ListarUnidadMedida()
        {
            dgvUnidadMedida.DataSource = null;
            dgvUnidadMedida.DataSource = UnidadMedida.ObtenerUnidades();
            dgvUnidadMedida.ClearSelection();
            dgvUnidadMedida.Columns[0].HeaderText = "Código interno";
            dgvUnidadMedida.Columns[1].HeaderText = "Descripción";
        }

        private void LimpiarFormulario()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";

        }
        private void frmUnidadMedida_Load(object sender, EventArgs e)
        {
            try
            {
                ListarUnidadMedida();
                txtDescripcion.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private UnidadMedida ObtenerUnidadMedidaFormulario()
        {
            UnidadMedida unidadMedida = new UnidadMedida();
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                unidadMedida.id = Convert.ToInt32(txtCodigo.Text.Trim());
            }
            if (txtDescripcion.Text != "")
            {
                unidadMedida.descripcion = txtDescripcion.Text;
            }
            else
            {
                MessageBox.Show("La descripción es obligatoria");
                txtDescripcion.Focus();
                return null;
            }
            return unidadMedida;
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ObtenerUnidadMedidaFormulario() != null)
                {
                    UnidadMedida m = ObtenerUnidadMedidaFormulario();
                    UnidadMedida.AgregarUnidad(m);
                    MessageBox.Show("Registro insertado correctamente", "Alta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarUnidadMedida();
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
                if (dgvUnidadMedida.SelectedCells.Count > 0)
                {
                    UnidadMedida mar = (UnidadMedida)dgvUnidadMedida.CurrentRow.DataBoundItem;
                    if (mar != null)
                    {
                        if (MessageBox.Show("¿Está seguro de eliminar el registro?", "Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            UnidadMedida.EliminarUnidadMedidas(mar);                            
                            ListarUnidadMedida();
                            MessageBox.Show("Registro eliminado", "Baja", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (dgvUnidadMedida.SelectedCells.Count > 0)
                {

                    UnidadMedida unidadMedida = (UnidadMedida)dgvUnidadMedida.CurrentRow.DataBoundItem;

                    if (unidadMedida != null)
                    {
                        int index = dgvUnidadMedida.CurrentCell.RowIndex;
                        if (ObtenerUnidadMedidaFormulario()!=null)
                        {
                            UnidadMedida m = ObtenerUnidadMedidaFormulario();
                            UnidadMedida.EditarUnidadMedida(index, m);
                            MessageBox.Show("Registro editado correctamente", "Modificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ListarUnidadMedida();
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

        private void dgvUnidadMedida_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUnidadMedida.RowCount > 0)
                {
                    UnidadMedida mar = (UnidadMedida)dgvUnidadMedida.CurrentRow.DataBoundItem;

                    if (mar != null)
                    {
                        txtCodigo.Text = Convert.ToString(mar.id);
                        txtDescripcion.Text = mar.descripcion;
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
