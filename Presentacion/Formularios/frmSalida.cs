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
    public partial class frmSalida : Form
    {
        SalidaProducto salida;
        public frmSalida()
        {
            InitializeComponent();
        }

        private void frmSalidaProducto_Load(object sender, EventArgs e)
        {
            dtgDetalleSalidaProducto.AutoGenerateColumns = true;
            cmbProducto.DataSource = Producto.ObtenerProductos();
            cmbMotivo.DataSource = Motivo.ObtenerMotivos();
            cmbProducto.SelectedItem = null;
            cmbMotivo.SelectedItem = null;
            salida = new SalidaProducto();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DetalleSalidaProducto pd = new DetalleSalidaProducto();
            pd.cantidad = Convert.ToInt32(txtCantidad.Value);
            pd.producto = (Producto)cmbProducto.SelectedItem;
            salida.detalle.Add(pd);
            ActualizarDataGrid();

            Limpiar();
        }

        private void ActualizarDataGrid()
        {
            dtgDetalleSalidaProducto.DataSource = null;
            dtgDetalleSalidaProducto.DataSource = salida.detalle;

        }

        private void Limpiar()
        {
            txtCantidad.Value = 0;
            cmbProducto.SelectedItem = null;
            txtDestinatario.Text = "";
            txtDireccion.Text = "";
            txtNumeroDoc.Text = "";

        }

        private void dtgDetalleSalidaProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DetalleSalidaProducto pd = (DetalleSalidaProducto)dtgDetalleSalidaProducto.CurrentRow.DataBoundItem;
            salida.detalle.Remove(pd);
            ActualizarDataGrid();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            salida.fecharemision = dtpFechaRemision.Value.Date;
            salida.motivo = (Motivo)cmbMotivo.SelectedItem;
            salida.direccion = txtDireccion.Text;
            salida.destinatario = txtDireccion.Text;
            try
            {
                salida.nrodocumento = Convert.ToInt32(txtNumeroDoc.Text);
            } catch (FormatException f) { }
            SalidaProducto.Agregar(salida);
            Limpiar();
            dtgDetalleSalidaProducto.DataSource = null;
            dtpFechaRemision.Value = System.DateTime.Now;
            cmbMotivo.SelectedItem = null;
            salida = new SalidaProducto();
        }
    }
}
