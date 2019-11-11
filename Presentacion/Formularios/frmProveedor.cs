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
        public frmProveedor()
        {
            InitializeComponent();
        }

        private void FormProveedor_Load(object sender, EventArgs e)
        {
            ListarProveedor();
        }

        private void ListarProveedor()
        {
            dgvProveedor.DataSource = null;
            dgvProveedor.DataSource = Proveedor.listaProveedores;
        }

        private void LimpiarFormulario()
        {
            txtRuc.Text = "";
            txtRazon.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.Ruc = txtRuc.Text;
            proveedor.RazonSocial = txtRazon.Text;
            proveedor.Direccion = txtDireccion.Text;
            proveedor.Telefono = txtTelefono.Text;
            Proveedor.AgregarProveedores(proveedor);

            ListarProveedor();
            LimpiarFormulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Proveedor pro = (Proveedor)dgvProveedor.CurrentRow.DataBoundItem;
            if (pro != null)
            {
                Proveedor.listaProveedores.Remove(pro);
            }
            ListarProveedor();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Proveedor pro = (Proveedor)dgvProveedor.CurrentRow.DataBoundItem;

            if (pro != null)
            {
                int index = dgvProveedor.CurrentCell.RowIndex;
                Proveedor.listaProveedores[index] = ObtenerProveedor();
                ListarProveedor();
            }
        }

        private Proveedor ObtenerProveedor()
        {
            Proveedor pro = new Proveedor();
            pro.Ruc = txtRuc.Text;
            pro.RazonSocial = txtRazon.Text;
            pro.Telefono = txtTelefono.Text;
            pro.Direccion = txtDireccion.Text;
            

            return pro;
        }

     
        private void dgvProveedor_Click(object sender, EventArgs e)
        {
            Proveedor pro = (Proveedor)dgvProveedor.CurrentRow.DataBoundItem;

            if (pro != null)
            {
                txtRuc.Text = pro.Ruc;
                txtRazon.Text = pro.RazonSocial;
                txtTelefono.Text = pro.Telefono;
                txtDireccion.Text = pro.Direccion;
            }
        }
    }

    
}
