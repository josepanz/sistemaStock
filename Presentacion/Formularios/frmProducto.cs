using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos.Entidades;


namespace capaPresentacion
{
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }
        private void frmProducto_Load(object sender, EventArgs e)
        {
            ListarProducto();
        }

        private void ListarProducto()
        {
            dgvProducto.DataSource = null;
            dgvProducto.DataSource = Producto.listaProductos;
        }

        private void LimpiarFormulario()
        {
            txtDescripcion.Text = "";
            cmbMarca.SelectedIndex = -1;
            cmbCategoria.SelectedIndex = -1;
            cmbProveedor.SelectedIndex = -1;
            cmbTipoProducto.SelectedIndex = -1;
            nudPrecio.Value = 0;
            dtpVencimiento.Value =DateTime.Now;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.descripcion = txtDescripcion.Text;
            producto.marca =(Marca)cmbMarca.SelectedItem;
            producto.categoria = (Categoria)cmbCategoria.SelectedItem;
            producto.tipoProducto = (TipoProducto)cmbTipoProducto.SelectedItem;
            producto.proveedor =(Proveedor) cmbProveedor.SelectedItem;
            producto.precio = (Double)nudPrecio.Value;
            producto.fechaVencimiento = dtpVencimiento.Value;
            Producto.AgregarProductos(producto);

            ListarProducto();
            LimpiarFormulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Producto pro = (Producto)dgvProducto.CurrentRow.DataBoundItem;
            if (pro != null)
            {
                Producto.listaProductos.Remove(pro);
            }
            ListarProducto();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Producto pro = (Producto)dgvProducto.CurrentRow.DataBoundItem;

            if (pro != null)
            {
                int index = dgvProducto.CurrentCell.RowIndex;
                Producto.listaProductos[index] = ObtenerProductos();
                ListarProducto();
            }
        }

        private Producto ObtenerProductos()
        {
            Producto pro = new Producto();
            pro.descripcion = txtDescripcion.Text;
            pro.marca = (Marca)cmbMarca.SelectedItem;
            pro.categoria = (Categoria)cmbCategoria.SelectedItem;
            pro.tipoProducto = (TipoProducto)cmbTipoProducto.SelectedItem;
            pro.proveedor = (Proveedor)cmbProveedor.SelectedItem;
            pro.precio = (Double)nudPrecio.Value;
            pro.fechaVencimiento = dtpVencimiento.Value;

            return pro;
        }


        private void dgvProducto_Click(object sender, EventArgs e)
        {
            Producto pro = (Producto)dgvProducto.CurrentRow.DataBoundItem;

            if (pro != null)
            {
                txtDescripcion.Text = pro.descripcion;
                cmbMarca.SelectedItem = pro.marca;
                cmbCategoria.SelectedItem = pro.categoria;
                cmbTipoProducto.SelectedItem = pro.tipoProducto;
                cmbProveedor.SelectedItem = pro.proveedor;
                nudPrecio.Value = (Decimal)pro.precio;
                dtpVencimiento.Value = pro.fechaVencimiento;
            }
        }
    }
}
