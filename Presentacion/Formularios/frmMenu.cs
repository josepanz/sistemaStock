using Clases;
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
using System.Media;
using Presentacion;

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
                //Application.Exit();
                frmLogin form = new frmLogin();
                form.Show();
                this.Hide();
                //YO CREO QUE HAY QUE CERRAR LA CONEXIÓN... NO SE NOMAS COMO XD
            }
        }

        private void ProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*frmProveedor frmProv = new frmProveedor();
            frmProv.Show();*/
            abrirFormPanel<frmProveedor>();
        }

        private void ProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*frmProducto frmPro = new frmProducto();
            frmPro.Show();*/
            abrirFormPanel<frmProducto>();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMarca frmMarca = new frmMarca();
            frmMarca.ShowDialog(this);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmCategoria frmCategoria = new frmCategoria();            
            frmCategoria.ShowDialog(this);
        }

        private void tipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoProducto frmTipoProducto = new frmTipoProducto();     
            frmTipoProducto.ShowDialog(this);
        }

        private void EntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEntrada form = new frmEntrada();
            form.Show();
            //abrirFormPanel<frmEntrada>();

        }

        private void SalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalida form = new frmSalida();
            form.Show();
        }

        private void CargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCargo form = new frmCargo();
            //form.Show();
            form.ShowDialog(this);
            
        }

        private void UnidadDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            frmUnidadMedida form = new frmUnidadMedida();
            //form.Show();
            form.ShowDialog(this);

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

        private void SistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmException form = new frmException();
            try
            {
                form.setearUrl("C:\\Users\\Panza\\source\\repos\\josepanz\\sistemaStock\\img\\acercaDelSistema.jpg");
                form.Controls["txtMensaje"].Text = "Sistem Stock Pajaro Osado: Version Alpha 69";
                form.Controls["txtMensaje"].ForeColor = Color.Green;
                try
                {
                    SoundPlayer playError = new SoundPlayer(@"C:\Users\Panza\source\repos\josepanz\sistemaStock\sound\/Todo_el_maldito_sistema_esta_mal.wav");
                    playError.Play();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("no hay audio");
                }
                
            }
            catch (Exception ex) {
                Console.WriteLine("No se encontro la direccion de la imagen");
            }
            form.Show();
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteProducto form = new frmReporteProducto();
            form.Show();
        }

        private void mayorSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporteEntradaProductos form = new frmReporteEntradaProductos();
            form.Show();
        }

        private void salidaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReporteSalidaProductos form = new frmReporteSalidaProductos();
            form.Show();
        }

        private void IntegrantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDevelopers form = new frmDevelopers();
            form.Show();
        }
    }
}
