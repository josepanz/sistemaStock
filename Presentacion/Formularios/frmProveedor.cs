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
            txtEmail.Text = "";
            txtDireccion.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor();
            if (!string.IsNullOrEmpty(txtidPK.Text))
            {
                proveedor.idPK = Convert.ToInt32(txtidPK.Text);
            }
            proveedor.idNumero= Convert.ToInt32(txtRuc.Text);
            proveedor.RazonSocial = txtRazon.Text;
            proveedor.Direccion = txtDireccion.Text;
            proveedor.Email = txtEmail.Text;
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
            pro.idNumero = Convert.ToInt32(txtRuc.Text);
            pro.RazonSocial = txtRazon.Text;
            pro.Email = txtEmail.Text;
            pro.Direccion = txtDireccion.Text;
            

            return pro;
        }

     
        private void dgvProveedor_Click(object sender, EventArgs e)
        {
            Proveedor pro = (Proveedor)dgvProveedor.CurrentRow.DataBoundItem;

            if (pro != null)
            {
                  pro.idNumero = Convert.ToInt32(txtRuc.Text);
                txtRazon.Text = pro.RazonSocial;
                txtEmail.Text = pro.Email;
                txtDireccion.Text = pro.Direccion;
            }
        }
    }

    
}
