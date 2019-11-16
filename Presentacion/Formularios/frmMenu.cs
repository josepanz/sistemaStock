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
            frmEmpleado frmEmpl = new frmEmpleado();
            frmEmpl.Show();
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
    }
}
