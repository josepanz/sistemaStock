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

        private void ListarTipoProducto()
        {
            dgvTipoProducto.DataSource = null;
            dgvTipoProducto.DataSource = TipoProducto.ObtenerTipoProductos();
            dgvTipoProducto.ClearSelection();
            dgvTipoProducto.Columns[0].HeaderText = "Código interno";
            dgvTipoProducto.Columns[1].HeaderText = "Descripción";
        }

        private TipoProducto ObtenerTipoProFormulario()
        {
            TipoProducto tp = new TipoProducto();
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                tp.id = Convert.ToInt32(txtCodigo.Text.Trim());
            }
            if (txtDescripcion.Text != "")
            {
                tp.descripcion = txtDescripcion.Text;
            }
            else
            {
                MessageBox.Show("La descripción es obligatoria");
                txtDescripcion.Focus();
                return null;
            }

            return tp;
        }

        private void frmTipoProducto_Load(object sender, EventArgs e)
        {
            try
            {
                ListarTipoProducto();
                txtDescripcion.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                if (ObtenerTipoProFormulario() != null)
                {
                    TipoProducto tipo = ObtenerTipoProFormulario();
                    TipoProducto.AgregarProductos(tipo);
                    MessageBox.Show("Registro insertado correctamente", "Alta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarTipoProducto();
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
                if (dgvTipoProducto.SelectedCells.Count > 0)
                {
                    TipoProducto tipo = (TipoProducto)dgvTipoProducto.CurrentRow.DataBoundItem;
                    if (tipo != null)
                    {
                        if (MessageBox.Show("¿Está seguro de eliminar el registro?", "Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            TipoProducto.EliminarTipoProductos(tipo);                            
                            ListarTipoProducto();
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
                if (dgvTipoProducto.SelectedCells.Count > 0)
                {
                    TipoProducto tipo = (TipoProducto)dgvTipoProducto.CurrentRow.DataBoundItem;

                    if (tipo != null)
                    {
                        int index = dgvTipoProducto.CurrentCell.RowIndex;
                        if (ObtenerTipoProFormulario() != null)
                        {
                            TipoProducto t = ObtenerTipoProFormulario();
                            TipoProducto.EditarTipoProducto(index, t);
                            MessageBox.Show("Registro editado correctamente", "Modificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ListarTipoProducto();
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

        
        private void dgvTipoProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTipoProducto.RowCount > 0)
                {
                    TipoProducto tipo = (TipoProducto)dgvTipoProducto.CurrentRow.DataBoundItem;

                    if (tipo != null)
                    {
                        txtCodigo.Text = Convert.ToString(tipo.id);
                        txtDescripcion.Text = tipo.descripcion;

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
