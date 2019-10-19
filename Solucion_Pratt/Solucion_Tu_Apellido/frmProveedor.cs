using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases_Pratt;
namespace Interfaz_tienda_Pratt
{
    public partial class frmProveedor : Form
    {
        
        public frmProveedor()
        {
            InitializeComponent();
        }
    
        private void ActualizarLista()
        {
            lstProveedor.DataSource = null;
            lstProveedor.DataSource = Proveedor.listaProveedores;
        }

        private void LimpiarFormulario()
        {
            txtRuc.Text = "";
            txtRazonSocial.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtRuc.Focus();
            
        }

           

        private Proveedor ObtenerProveedorFormulario()
        {
            Proveedor proveedor = new Proveedor();
            proveedor.Ruc = txtRuc.Text;
            proveedor.RazonSocial = txtRazonSocial.Text;
            proveedor.direccion = txtDireccion.Text;
            proveedor.Telefono = txtTelefono.Text;
            
            return proveedor;
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.Ruc = txtRuc.Text;
            proveedor.RazonSocial = txtRazonSocial.Text;
            proveedor.direccion = txtDireccion.Text;
            proveedor.Telefono = txtTelefono.Text;
            Proveedor.AgregarProveedores(proveedor);

            ActualizarLista();
            LimpiarFormulario();
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            if (lstProveedor.SelectedItems.Count > 0)
            {
                Proveedor proveedor = (Proveedor)lstProveedor.SelectedItem;
                if (proveedor != null)
                {
                    int index = lstProveedor.SelectedIndex;
                    Proveedor.listaProveedores[index] = ObtenerProveedorFormulario();
                    ActualizarLista();
                    LimpiarFormulario();
                }

            }
            else
            {
                MessageBox.Show("Favor seleccionar la prenda de la lista para modificar");
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (lstProveedor.SelectedItems.Count > 0)
            {
                Proveedor proveedor = (Proveedor)lstProveedor.SelectedItem;
                if (proveedor != null)
                {
                    int index = lstProveedor.SelectedIndex;
                    Proveedor.listaProveedores.Remove(proveedor);
                    ActualizarLista();
                    LimpiarFormulario();
                }

            }
            else
            {
                MessageBox.Show("Favor seleccionar la prenda de la lista para modificar");
            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

       

        private void lstProveedor_Click_1(object sender, EventArgs e)
        {
            Proveedor proveedor = (Proveedor)lstProveedor.SelectedItem;

            if (proveedor != null)
            {
                txtRuc.Text = proveedor.Ruc;
                txtRazonSocial.Text = proveedor.RazonSocial;
                txtDireccion.Text = proveedor.direccion;
                txtTelefono.Text = proveedor.Telefono;
                
            }
        }
    }
}
