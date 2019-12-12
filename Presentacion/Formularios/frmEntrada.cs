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
using System.Media;

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
            if (validarNulosDetalle()) { 
                DetalleEntradaProducto pd = new DetalleEntradaProducto();
                pd.cantidad = Convert.ToInt32(txtCantidad.Value);
                pd.producto = (Producto)cmbProducto.SelectedItem;
                entrada.detalle.Add(pd);
                ActualizarDataGrid();
                Limpiar();
            }
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


        }

        private void LimpiarCab()
        {
            txtCantidad.Value = 0;
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
            if (validarNulosCabecera())
            {
                entrada.fecharecepcion = dtpFechaRemision.Value.Date;
                entrada.direccion = txtDireccion.Text;
                entrada.receptor = txtReceptor.Text;
                entrada.nrodocumento = txtNumeroDoc.Text;
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

                    entrada.nrodocumento = txtNumeroDoc.Text;

                EntradaProducto.Agregar(entrada);
                LimpiarCab();
                dtgDetalleEntradaProducto.DataSource = null;
                dtpFechaRemision.Value = System.DateTime.Now;
                entrada = new EntradaProducto();
            }

        }

        private bool validarNulosDetalle() {
            bool flag = true;
            frmException err = new frmException();
            err.setearUrl("C:\\Users\\Panza\\source\\repos\\josepanz\\sistemaStock\\img\\algoAndaMal.jpg");

            if (dtpFechaRemision.Value ==null){
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

            if (txtCantidad.Value <= 0)
            {
                err.Controls["txtMensaje"].Text = "Debe cargar el valor de la cantidad recibida";
                txtCantidad.Focus();
                mostrarForm(err);
                return flag = false;

            }
            if (txtReceptor.Text.Trim() == null)
            {
                err.Controls["txtMensaje"].Text = "Debe cargar el valor del receptor";
                txtReceptor.Focus();
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
            if (dtgDetalleEntradaProducto.RowCount <= 0)
            {
                err.Controls["txtMensaje"].Text = "Debe agregar por lo menos un producto al detalle";
                cmbProducto.Focus();
                mostrarForm(err);
                return flag = false;

            }

            return flag;

        }
        public void mostrarForm(Form err) {
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
