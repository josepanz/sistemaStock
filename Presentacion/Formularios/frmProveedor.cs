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
    public partial class frmProveedor : Form
    {
        public string modo;
        public frmProveedor()
        {
            InitializeComponent();
        }

        private void FormProveedor_Load(object sender, EventArgs e)
        {
            ListarProveedor();
            BloquearFormulario();
        }

        private void BloquearFormulario()
        {            
            panel2.Enabled = false;
        }

        private void ListarProveedor()
        {
            dgvProveedor.DataSource = null;
            dgvProveedor.DataSource = Proveedor.ObtenerProveedores();
            dgvProveedor.ClearSelection();
            dgvProveedor.Columns[0].HeaderText = "Código interno";
            dgvProveedor.Columns[1].HeaderText = "RUC";
            dgvProveedor.Columns[2].HeaderText = "Razón social";
            dgvProveedor.Columns[3].HeaderText = "E-mail";
            dgvProveedor.Columns[4].HeaderText = "Teléfono";
            dgvProveedor.Columns[5].HeaderText = "Dirección";
        }

        private void LimpiarFormulario()
        {
            txtidPK.Text = "";
            txtRuc.Text = "";
            txtRazon.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
        }
        

        private void DesbloquearFormulario()
        {            
            panel2.Enabled = true;
        }

        private Proveedor ObtenerProveedorFormulario()
        {
            Proveedor pro = new Proveedor();
            if (!string.IsNullOrEmpty(txtidPK.Text))
            {
                pro.idPK = Convert.ToInt32(txtidPK.Text);
            }
            
            if (txtRuc.Text != "")
            {
                pro.Ruc = txtRuc.Text.ToUpper();
            }
            else
            {
                MessageBox.Show("El RUC es obligatorio");
                txtRuc.Focus();
                return null;
            }
            if (txtRazon.Text != "")
            {
                pro.RazonSocial = txtRazon.Text;
            }
            else
            {
                MessageBox.Show("La razón social es obligatoria");
                txtRazon.Focus();
                return null;
            }
            if (txtEmail.Text != "")
            {
                pro.Email = txtEmail.Text;
            }
            else
            {
                MessageBox.Show("El email es obligatorio");
                txtEmail.Focus();
                return null;
            }

            if (txtDireccion.Text != "")
            {
                pro.Telefono = txtTelefono.Text;
            }
            else
            {
                MessageBox.Show("El teléfono es obligatorio");
                txtTelefono.Focus();
                return null;
            }
            if (txtDireccion.Text != "")
            {
                pro.Direccion = txtDireccion.Text;
            }
            else
            {
                MessageBox.Show("La dirección es obligatoria");
                txtDireccion.Focus();
                return null;
            }           

            return pro;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            modo = "I";
            LimpiarFormulario();
            DesbloquearFormulario();
            panel3.Enabled = false;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {

            modo = "E";
            Proveedor proveedor = new Proveedor();
            if (dgvProveedor.SelectedCells.Count > 0)
            {
                panel2.Enabled = true;
                panel3.Enabled = false;
                proveedor = (Proveedor)dgvProveedor.CurrentRow.DataBoundItem;
                txtidPK.Text = Convert.ToString(proveedor.idPK);
                txtRuc.Text = proveedor.Ruc;
                txtRazon.Text = proveedor.RazonSocial;
                txtEmail.Text = proveedor.Email;
                txtTelefono.Text = proveedor.Telefono;
                txtDireccion.Text = proveedor.Direccion;             
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }            
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            int idPK;
            if (dgvProveedor.SelectedCells.Count > 0)
            {
                idPK = Convert.ToInt32(dgvProveedor.CurrentRow.Cells[0].Value);
                if (MessageBox.Show("¿Está seguro de eliminar el registro?", "Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Proveedor.EliminarProveedores(idPK);
                    ListarProveedor();
                    MessageBox.Show("Registro eliminado", "Baja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }     

        private void DgvProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProveedor.RowCount > 0)
                {
                    Proveedor proveedor = (Proveedor)dgvProveedor.CurrentRow.DataBoundItem;
                    if (proveedor != null)
                    {
                        txtidPK.Text = Convert.ToString(proveedor.idPK);
                        txtRuc.Text = proveedor.Ruc;
                        txtRazon.Text = proveedor.RazonSocial;
                        txtEmail.Text = proveedor.Email;
                        txtTelefono.Text = proveedor.Telefono;
                        txtDireccion.Text = proveedor.Direccion;
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

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Proveedor prov = null;
                if (modo == "I")
                {
                    prov = ObtenerProveedorFormulario();
                    if (prov != null)
                    {
                        Proveedor.AgregarProveedores(prov);
                        MessageBox.Show("Registro insertado correctamente", "Alta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarProveedor();
                        LimpiarFormulario();
                        panel3.Enabled = true;
                        panel2.Enabled = false;
                    }
                }
                else if (modo == "E")
                {
                    int index = Convert.ToInt32(dgvProveedor.CurrentRow.Cells[0].Value);
                    prov = ObtenerProveedorFormulario();
                    if (prov != null)
                    {
                        Proveedor.EditarProveedores(index, prov);
                        MessageBox.Show("Registro editado correctamente", "Modificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarProveedor();
                        LimpiarFormulario();
                        panel3.Enabled = true;
                        panel2.Enabled = false;
                    }
                    txtBuscar.Focus();
                }
            }
            catch (Exception ex)
            {
                System.Data.SqlClient.SqlException sqlEx = ex as System.Data.SqlClient.SqlException;
                if (sqlEx != null && sqlEx.Number == 2601)
                {
                    MessageBox.Show("No se pude insertar el registro. Registro duplicado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRuc.Focus();
                }
                else
                {
                    MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRuc.Focus();
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            BloquearFormulario();
            panel3.Enabled = true;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            var result = Proveedor.ObtenerProveedores().Where(x => x.Ruc.ToString().Contains(txtBuscar.Text)).ToList();
            dgvProveedor.DataSource = result;
        }
    }


}
