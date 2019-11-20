using Presentacion.Formularios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion.Formularios
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            abrirFormPanel<frmEmpleado>();

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir del sistema?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)==DialogResult.Yes)
            {
                Application.Exit();
                //Close();
                //YO CREO QUE HAY QUE CERRAR LA CONEXIÓN... NO SE NOMAS COMO XD
            }
        }

        private void ProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedor frmProv = new frmProveedor();
            frmProv.Show();
        }

        private void ProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducto frmPro = new frmProducto();
            frmPro.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMarca frmMarca = new frmMarca();
            frmMarca.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmCategoria frmCategoria = new frmCategoria();
            frmCategoria.Show();
        }

        private void tipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoProducto frmTipoProducto = new frmTipoProducto();
            frmTipoProducto.Show();
        }

        private void EntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEntrada form = new frmEntrada();
            form.Show();
        }

        private void SalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalida form = new frmSalida();
            form.Show();
        }

        private void CargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCargo form = new frmCargo();
            form.Show();
        }

        private void UnidadDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUnidadMedida form = new frmUnidadMedida();
            form.Show();

        }

        private void MotivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMotivo form = new frmMotivo();
            form.Show();

        }

        private void FrmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void abrirFormPanel<Miform>() where Miform : Form, new()
        {
            Form Formulario;
            Formulario = pnlForms.Controls.OfType<Miform>().FirstOrDefault(); //Busca el formulario en la coleccion
                                                                              //Si form no fue encontrado/ no existe
            if (Formulario == null)
            {
                Formulario = new Miform();
                Formulario.TopLevel = false;
                pnlForms.Controls.Add(Formulario);
                pnlForms.Tag = Formulario;
                //Formulario.FormClosed = new EventHandler(this.cerrarFormulario);
                //Formulario.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                Formulario.Dock = DockStyle.Fill;
                Formulario.Show();
                Formulario.BringToFront();
            }
            else
            {
                Formulario.BringToFront();
            }
        }

        /*private void cerrarFormulario(object sender, FormClosedEventArgs e)
        {
            //'CONDICION SI FORM ESTA ABIERTO
            if ((Application.OpenForms("frmProductos") == null))
            {
                btnProducto.BackColor = Color.FromArgb(4, 41, 68);
            }

            if ((Application.OpenForms("frmEmpleados") == null))
            {
                btnEmpleado.BackColor = Color.FromArgb(4, 41, 68);
            }

            if ((Application.OpenForms("frmProveedores") == null))
            {
                btnProveedor.BackColor = Color.FromArgb(4, 41, 68);
            }

            if ((Application.OpenForms("frmClientes") == null))
            {
                btnCliente.BackColor = Color.FromArgb(4, 41, 68);
            }

            if ((Application.OpenForms("frmMovil") == null))
            {
                btnMovil.BackColor = Color.FromArgb(4, 41, 68);
            }

            if ((Application.OpenForms("frmVentas") == null))
            {
                btnVenta.BackColor = Color.FromArgb(4, 41, 68);
            }

            if ((Application.OpenForms("frmCpmpras") == null))
            {
                btnCompra.BackColor = Color.FromArgb(4, 41, 68);
            }
        }*/
    }
}
