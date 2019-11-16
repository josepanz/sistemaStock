﻿using System;
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
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }
        private void frmProducto_Load(object sender, EventArgs e)
        {
            dgvProducto.AutoGenerateColumns = true;
            cmbMarca.DataSource = Marca.ObtenerMarcas();
            cmbTipoProducto.DataSource = TipoProducto.ObtenerTipoProductos();
            cmbProveedor.DataSource = Proveedor.ObtenerProveedores();
            cmbUnidad.DataSource = UnidadMedida.ObtenerUnidades();
            cmbCategoria.DataSource = Categoria.ObtenerCategorias();

            cmbMarca.SelectedItem = null;
            cmbTipoProducto.SelectedItem = null;
            cmbProveedor.SelectedItem = null;
            cmbUnidad.SelectedItem = null;
            cmbCategoria.SelectedItem = null;

            ListarProducto();
        }

        private void ListarProducto()
        {
            dgvProducto.DataSource = null;
            dgvProducto.DataSource = Producto.listaProductos;
        }

        private void LimpiarFormulario()
        {
            txtId.Text = "";
            txtDescripcion.Text = "";
            txtCodBarra.Text = "";
            nudPrecio.Value = 0;
            nudCantidad.Value = 0;
            cmbMarca.SelectedIndex = -1;
            cmbTipoProducto.SelectedIndex = -1;
            cmbProveedor.SelectedIndex = -1;
            cmbUnidad.SelectedIndex = -1;
            cmbCategoria.SelectedIndex = -1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.descripcion = txtDescripcion.Text;
            producto.codBarra = txtCodBarra.Text;
            producto.precio = Convert.ToInt32(nudPrecio.Value);
            producto.cantidad = Convert.ToInt32(nudCantidad.Value);
            producto.marca = (Marca)cmbMarca.SelectedItem;
            producto.tipoProducto = (TipoProducto)cmbTipoProducto.SelectedItem;
            producto.proveedor = (Proveedor)cmbProveedor.SelectedItem;
            producto.unidad = (UnidadMedida)cmbUnidad.SelectedItem;
            producto.categoria = (Categoria)cmbCategoria.SelectedItem;


            Producto.AgregarProductos(producto);
            MessageBox.Show("Se ha agregado con éxito!!");

            ListarProducto();
            LimpiarFormulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            /*Producto producto = (Producto)dgvProducto.CurrentRow.DataBoundItem;
            Producto.listaProductos.Remove(producto);
            ListarProducto();*/


            Producto pro = (Producto)dgvProducto.CurrentRow.DataBoundItem;
            if (pro != null)
            {
                Producto.listaProductos.Remove(pro);
            }
            
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
            pro.codBarra = txtCodBarra.Text;
            pro.precio = Convert.ToInt32(nudPrecio.Value);
            pro.cantidad = Convert.ToInt32(nudCantidad.Value);
            pro.marca = (Marca)cmbMarca.SelectedItem;
            pro.tipoProducto = (TipoProducto)cmbTipoProducto.SelectedItem;
            pro.proveedor = (Proveedor)cmbProveedor.SelectedItem;
            pro.unidad = (UnidadMedida)cmbUnidad.SelectedItem;
            pro.categoria = (Categoria)cmbCategoria.SelectedItem;

            return pro;
        }


        private void dgvProducto_Click(object sender, EventArgs e)
        {
            Producto pro = (Producto)dgvProducto.CurrentRow.DataBoundItem;

            if (pro != null)
            {
                txtDescripcion.Text = pro.descripcion;
                txtCodBarra.Text = pro.codBarra;
                nudPrecio.Value = (Decimal)pro.precio;
                nudCantidad.Value = (Decimal)pro.cantidad;
                cmbMarca.SelectedItem = pro.marca;
                cmbTipoProducto.SelectedItem = pro.tipoProducto;
                cmbProveedor.SelectedItem = pro.proveedor;
                cmbUnidad.SelectedItem = pro.unidad;
                cmbCategoria.SelectedItem = pro.categoria;

            }
        }
    }
}
