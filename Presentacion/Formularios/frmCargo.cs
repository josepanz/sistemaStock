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

namespace capaPresentacion
{
    public partial class frmCargo : Form
    {
        public frmCargo()
        {
            InitializeComponent();
        }

        private void ListarCargo()
        {
            dgvCargo.DataSource = null;            
            dgvCargo.DataSource = Cargo.ObtenerCargos();            
            dgvCargo.ClearSelection();
            dgvCargo.Columns[0].HeaderText = "Código interno";
            dgvCargo.Columns[1].HeaderText = "Descripción";
        }

        private void Cargo_Load(object sender, EventArgs e)
        {
            try
            {
                ListarCargo();
                txtDescripcion.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());                
            }            
        }
        private Cargo ObtenerCargoFormulario()
        {
            Cargo c = new Cargo();
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
                if (ObtenerCargoFormulario() != null)
                {
                    Cargo c = ObtenerCargoFormulario();
                    Cargo.AgregarCargo(c);
                    MessageBox.Show("Registro insertado correctamente", "Alta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarCargo();
                    LimpiarFormulario();
                }
             }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }            
        }       

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCargo.SelectedCells.Count > 0)
                {
                    Cargo cat = (Cargo)dgvCargo.CurrentRow.DataBoundItem;
                    if (cat != null)
                    {
                        if (MessageBox.Show("¿Está seguro de eliminar el registro?", "Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            Cargo.EliminarCargo(cat);                            
                            MessageBox.Show("Registro eliminado", "Baja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarFormulario();
                            ListarCargo();
                        }                     
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una fila");
                }                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCargo.SelectedCells.Count > 0)
                {
                    Cargo cat = (Cargo)dgvCargo.CurrentRow.DataBoundItem;

                    if (cat != null)
                    {
                        if (ObtenerCargoFormulario() != null)
                        {
                            int index = dgvCargo.CurrentCell.RowIndex;
                            Cargo c = ObtenerCargoFormulario();
                            Cargo.EditarCargo(index, c);
                            MessageBox.Show("Registro editado correctamente", "Modificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ListarCargo();
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
        
        private void dgvCargo_Click(object sender, EventArgs e)
        {
           try
            {
                if (dgvCargo.RowCount > 0)
                {

                    Cargo cat = (Cargo)dgvCargo.CurrentRow.DataBoundItem;
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
