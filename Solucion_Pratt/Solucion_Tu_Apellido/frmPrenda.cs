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
    public partial class frmPrendas : Form
    {
        public frmPrendas()
        {
            InitializeComponent();
        }

        private void LimpiarFormulario()
        {
            txtDetalles.Text = "";
            txtTamaño.Text = "";
            txtPrecioCosto.Text = "";
            txtPrecioVenta.Text = "";
            txtUtilidadBruta.Text = "";
            cmbColor.SelectedItem = null;
            cmbProveedor.SelectedItem = null;
            cmbTipoPrenda.SelectedItem = null;
            dtpFechaIngreso.Value = System.DateTime.Now;
            rdbSi.Checked = true;
            txtDetalles.Focus();
        }

        private void ActualizarListaPrenda()
        {
            lstPrenda.DataSource = null;
            lstPrenda.DataSource = Prenda.obtenerPrendas();
        }

        private Prenda ObtenerPrendaFormulario()
        {
            Prenda P = new Prenda();
            P.detalle = txtDetalles.Text;
            P.tamaño = txtTamaño.Text;
            P.Color = (Clases_Pratt.Color)cmbColor.SelectedItem;
            P.TipoVestimenta = (TipoVestimenta)cmbTipoPrenda.SelectedItem;
            P.Fecha_Ingreso = dtpFechaIngreso.Value.Date;
            if (rdbSi.Checked)
            {
                P.cambiable = Cambiable.Si;
            }
            else if (rdbNo.Checked)
            {
                P.cambiable = Cambiable.No;
            }
            P.Proveedor = (Proveedor)cmbProveedor.SelectedItem;
            P.Precio_Costo = Convert.ToDouble(txtPrecioCosto.Text);
            P.Precio_Venta = Convert.ToDouble(txtPrecioVenta.Text);
            P.Utilidad_Bruta = Convert.ToDouble(txtUtilidadBruta.Text);
            return P;
        }

      
       

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            Prenda prenda = ObtenerPrendaFormulario();

            Prenda.AgregarPrendas(prenda);
            ActualizarListaPrenda();
            LimpiarFormulario();
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            if (lstPrenda.SelectedItems.Count > 0)
            {
                Prenda prenda = (Prenda)lstPrenda.SelectedItem;
                if (prenda != null)
                {
                    int index = lstPrenda.SelectedIndex;
                    Prenda.listaPrendas[index] = ObtenerPrendaFormulario();
                    ActualizarListaPrenda();
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
            if (lstPrenda.SelectedItems.Count > 0)
            {
                Prenda prenda = (Prenda)lstPrenda.SelectedItem;
                if (prenda != null)
                {
                    Prenda.EliminarPrendas(prenda);
                    ActualizarListaPrenda();
                    LimpiarFormulario();
                }
            }
            else
            {
                MessageBox.Show("Favor seleccionar la prenda de la lista para eliminar");
            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void lstPrenda_Click_1(object sender, EventArgs e)
        {
            Prenda prenda = (Prenda)lstPrenda.SelectedItem;
            if (prenda != null)
            {
                txtDetalles.Text = prenda.detalle;
                txtTamaño.Text = prenda.tamaño;
                txtPrecioCosto.Text = Convert.ToString(prenda.Precio_Costo);
                txtPrecioVenta.Text = Convert.ToString(prenda.Precio_Venta);
                txtUtilidadBruta.Text = Convert.ToString(prenda.Utilidad_Bruta);
                cmbColor.SelectedItem = prenda.Color;
                cmbTipoPrenda.SelectedItem = prenda.TipoVestimenta;
                cmbProveedor.SelectedItem = prenda.Proveedor;
                dtpFechaIngreso.Value = prenda.Fecha_Ingreso;
                if (prenda.cambiable == Cambiable.Si)
                {
                    rdbSi.Checked = true;
                }
                else if (prenda.cambiable == Cambiable.No)
                {
                    rdbNo.Checked = true;
                }
            }
        }

        private void frmPrendas_Load(object sender, EventArgs e)
        {
            ActualizarListaPrenda();
            cmbColor.DataSource = Enum.GetValues(typeof(Clases_Pratt.Color));
            cmbTipoPrenda.DataSource = Enum.GetValues(typeof(TipoVestimenta));
            cmbProveedor.DataSource = Proveedor.ObtenerProveedor();
            cmbColor.SelectedItem = null;
            cmbProveedor.SelectedItem = null;
            cmbTipoPrenda.SelectedItem = null;
            rdbSi.Checked = true;
        }

        private void txtPrecioCosto_Leave_1(object sender, EventArgs e)
        {
            double precio_costo = Convert.ToDouble(txtPrecioCosto.Text);

            double precio_venta = precio_costo + (precio_costo * 25) / 100;
            double utilidad_bruta = precio_venta - precio_costo;

            txtPrecioVenta.Text = Convert.ToString(precio_venta);
            txtUtilidadBruta.Text = Convert.ToString(utilidad_bruta);
        }

       
    }
}
