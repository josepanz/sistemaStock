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
using System.Media;


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
            if (validarNulosDetalle())
            {
                DetalleSalidaProducto pd = new DetalleSalidaProducto();
                pd.cantidad = Convert.ToInt32(txtCantidad.Value);
                pd.producto = (Producto)cmbProducto.SelectedItem;
                salida.detalle.Add(pd);
                ActualizarDataGrid();

                Limpiar();
            }
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


        }
        private void LimpiarCab()
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
            if (validarNulosCabecera())
            {
                salida.fecharemision = dtpFechaRemision.Value.Date;
                salida.motivo = (Motivo)cmbMotivo.SelectedItem;
                salida.direccion = txtDireccion.Text;
                salida.destinatario = txtDestinatario.Text;
                salida.nrodocumento = txtNumeroDoc.Text;
                
           
                SalidaProducto.Agregar(salida);
                LimpiarCab();
                dtgDetalleSalidaProducto.DataSource = null;
                dtpFechaRemision.Value = System.DateTime.Now;
                cmbMotivo.SelectedItem = null;
                salida = new SalidaProducto();
            }
        }
        private bool validarNulosDetalle()
        {
            bool flag = true;
            frmException err = new frmException();
            err.setearUrl("C:\\Users\\Panza\\source\\repos\\josepanz\\sistemaStock\\img\\algoAndaMal.jpg");

            if (dtpFechaRemision.Value == null)
            {
                err.Controls["txtMensaje"].Text = "Fecha";
                MessageBox.Show("Debe cargar el valor del campo de fecha", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFechaRemision.Focus();
                return flag = false;
            }

            if (cmbProducto.SelectedItem == null)
            {
                err.Controls["txtMensaje"].Text = "Debe cargar el valor del Producto";
                cmbProducto.Focus();
                mostrarForm(err);
                return flag = false;

            }
            if (cmbMotivo.SelectedItem == null)
            {
                err.Controls["txtMensaje"].Text = "Debe cargar el valor del Motivo de Salida";
                cmbMotivo.Focus();
                mostrarForm(err);
                return flag = false;

            }

            if (txtCantidad.Value <= 0)
            {
                err.Controls["txtMensaje"].Text = "Debe cargar el valor de la cantidad recibida";
                txtCantidad.Focus();
                mostrarForm(err);
                return flag = false;

            }
            if (txtDestinatario.Text.Trim() == null)
            {
                err.Controls["txtMensaje"].Text = "Debe cargar el valor del Destinatario";
                txtDestinatario.Focus();
                mostrarForm(err);
                return flag = false;

            }
            if (txtDireccion.Text.Trim() == null)
            {
                err.Controls["txtMensaje"].Text = "Debe cargar el valor de la direccion de recepcion";
                txtDireccion.Focus();
                mostrarForm(err);
                return flag = false;

            }
            if (txtNumeroDoc.Text.Trim() == null)
            {
                err.Controls["txtMensaje"].Text = "Debe cargar el valor del numero de documento de la recepcion";
                txtNumeroDoc.Focus();
                mostrarForm(err);
                return flag = false;

            }


            return flag;
        }

        public bool validarNulosCabecera() {
            bool flag = true;
            frmException err = new frmException();
            err.setearUrl("C:\\Users\\Panza\\source\\repos\\josepanz\\sistemaStock\\img\\algoAndaMal.jpg");

            if (dtgDetalleSalidaProducto.RowCount <= 0)
            {
                err.Controls["txtMensaje"].Text = "Debe agregar por lo menos un producto al detalle";
                cmbProducto.Focus();
                mostrarForm(err);
                return flag = false;

            }

            return flag;
        }
        public void mostrarForm(Form err)
        {
            try
            {
                SoundPlayer playError = new SoundPlayer(@"C:\Users\Panza\source\repos\josepanz\sistemaStock\sound\algoandamal.wav");
                playError.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("no hay audio");
            }
            err.Show();
        }
    }
}
