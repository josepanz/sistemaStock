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
            pd.cantidad = Convert.ToInt32(txtCantidad.Value);
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
            txtCantidad.Value = 0;
            cmbProducto.SelectedItem = null;
            txtReceptor.Text ="";
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
            if (validarNulos())
            {
                entrada.fecharecepcion = dtpFechaRemision.Value.Date;
                entrada.direccion = txtDireccion.Text;
                if (txtReceptor.Text != null)
                {
                    entrada.receptor = txtReceptor.Text;
                }
                else
                {
                    frmException excepcion = new frmException();
                    excepcion.setearUrl("C:\\Users\\Panza\\source\\repos\\josepanz\\sistemaStock\\img\\algoAndaMal.jpg");
                    excepcion.Show();
                }
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

        private bool validarNulos() {
            bool flag = true;
            if (dtpFechaRemision.Value ==null){
                
                MessageBox.Show("Debe cargar el valor del campo de fecha", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFechaRemision.Focus();
                return flag = false;
            }

            if (cmbProducto.SelectedItem == null)
            {
                MessageBox.Show("Debe cargar el valor del Producto", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProducto.Focus();
                return flag = false;

            }

            if (txtCantidad.Value <= 0)
            {
                MessageBox.Show("Debe cargar el valor de la cantidad recibida", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCantidad.Focus();
                return flag = false;

            }
            if (txtReceptor.Text.Trim() == null)
            {
                MessageBox.Show("Debe cargar el valor del receptor", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReceptor.Focus();
                return flag = false;

            }
            if (txtDireccion.Text.Trim() == null)
            {
                MessageBox.Show("Debe cargar el valor de la direccion de recepcion", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDireccion.Focus();
                return flag = false;

            }
            if (txtNumeroDoc.Text.Trim() == null)
            {
                MessageBox.Show("Debe cargar el valor del numero de documento de la recepcion", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumeroDoc.Focus();
                return flag = false;

            }
            if (dtgDetalleEntradaProducto.RowCount <=0 )
            {
                MessageBox.Show("Debe agregar por lo menos un producto al detalle", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbProducto.Focus();
                return flag = false;

            }

            return flag;
        }

    }
}
