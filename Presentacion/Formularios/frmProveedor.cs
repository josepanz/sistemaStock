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
            txtRuc.Enabled = false;
            txtRazon.Enabled = false;
            txtEmail.Enabled = false;
            txtTelefono.Enabled = false;
            txtDireccion.Enabled = false;
        }

        private void ListarProveedor()
        {
            lstProveedores.DataSource = null;
            lstProveedores.DataSource = Proveedor.ObtenerProveedores();
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            modo = "I";
            LimpiarFormulario();
            DesbloquearFormulario();

        }

        private void DesbloquearFormulario()
        {
            txtRuc.Enabled = true;
            txtRazon.Enabled = true;
            txtEmail.Enabled = true;
            txtTelefono.Enabled = true;
            txtDireccion.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            Proveedor proveedor = (Proveedor)lstProveedores.SelectedItem;
            if (proveedor != null)
            {
                Proveedor.EliminarProveedores(proveedor);
                ListarProveedor();
                LimpiarFormulario();
            }
            else
            {
                MessageBox.Show("Favor seleccionar una fila de la lista");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = (Proveedor)lstProveedores.SelectedItem;
            if (proveedor != null)
            {
                modo = "E";
                DesbloquearFormulario();
            }
            else
            {
                MessageBox.Show("Ojo, Selecciona un Item");
            }
        }

        private Proveedor ObtenerProveedor()
        {
            Proveedor pro = new Proveedor();
            pro.Ruc = Convert.ToInt32(txtRuc.Text);
            pro.RazonSocial = txtRazon.Text;
            pro.Telefono = Convert.ToInt32(txtTelefono.Text);
            pro.Direccion = txtEmail.Text;


            return pro;
        }




        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (modo == "I")
            {
                Proveedor pro = ObtenerProveedorFormulario();
                Proveedor.AgregarProveedores(pro);
            }
            else if (modo == "E")
            {
                int index = lstProveedores.SelectedIndex;
                Proveedor pro = ObtenerProveedorFormulario();
                Proveedor.EditarProveedores(index, pro);
            }

            ListarProveedor();
            LimpiarFormulario();
            BloquearFormulario();
        }



        private Proveedor ObtenerProveedorFormulario()
        {
            Proveedor pro = new Proveedor();
            if (!string.IsNullOrEmpty(txtidPK.Text))
            {
                pro.idPK = Convert.ToInt32(txtidPK.Text);
            }
            txtEmail.Enabled = false;
            txtTelefono.Enabled = false;
            txtDireccion.Enabled = false;
            pro.Ruc = Convert.ToInt32(txtRuc.Text);
            pro.RazonSocial = txtRazon.Text;
            pro.Email = txtEmail.Text;
            pro.Telefono = Convert.ToInt32(txtTelefono.Text);
            pro.Direccion = txtDireccion.Text;

            return pro;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void lstProveedores_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = (Proveedor)lstProveedores.SelectedItem;
            txtidPK.Text = Convert.ToString(proveedor.idPK);
            txtRuc.Text = Convert.ToString(proveedor.Ruc);
            txtRazon.Text = proveedor.RazonSocial;
            txtEmail.Text = proveedor.Email;
            txtTelefono.Text = Convert.ToString(proveedor.Telefono);
            txtDireccion.Text = proveedor.Direccion;
        }
    }


}
