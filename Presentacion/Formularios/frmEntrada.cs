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
    public partial class frmEntrada : Form
    {
        EntradaProducto entrada;
        public frmEntrada()
        {
            InitializeComponent();
        }

        private void frmEntradaProducto_Load(object sender, EventArgs e)
        {
            dtgDetalleEntradaProducto.AutoGenerateColumns = true;
            cmbProducto.DataSource = Producto.ObtenerProductos();
            cmbProducto.SelectedItem = null;
            entrada = new EntradaProducto();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DetalleEntradaProducto pd = new DetalleEntradaProducto();
            pd.cantidad = Convert.ToInt32(txtCantidad.Text);
            pd.producto = (Producto)cmbProducto.SelectedItem;
            entrada.detalle.Add(pd);
            ActualizarDataGrid();

            Limpiar();
        }

        private void ActualizarDataGrid()
        {
            dtgDetalleEntradaProducto.DataSource = null;
            dtgDetalleEntradaProducto.DataSource = entrada.detalle;

        }

        private void Limpiar()
        {
            txtCantidad.Text = "0";
            cmbProducto.SelectedItem = null;
            txtReceptor.Text = "";
            txtDireccion.Text = "";
            txtNumeroDoc.Text = "";

        }

        private void dtgDetalleEntradaProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DetalleEntradaProducto pd = (DetalleEntradaProducto)dtgDetalleEntradaProducto.CurrentRow.DataBoundItem;
            entrada.detalle.Remove(pd);
            ActualizarDataGrid();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            entrada.fecharecepcion = dtpFechaRemision.Value.Date;
            entrada.direccion = txtDireccion.Text;
            entrada.receptor = txtDireccion.Text;
            try
            {
                entrada.nrodocumento = Convert.ToInt32(txtNumeroDoc.Text);
            }
            catch (FormatException f) { }
            EntradaProducto.Agregar(entrada);
            Limpiar();
            dtgDetalleEntradaProducto.DataSource = null;
            dtpFechaRemision.Value = System.DateTime.Now;
            entrada = new EntradaProducto();
        }

    }
}
