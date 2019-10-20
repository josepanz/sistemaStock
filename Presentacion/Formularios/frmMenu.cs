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
            /*if (MessageBox.Show("¿Está seguro que desea salir del sistema?") == DialogResult.Yes)
            {
                this.Close();
            }*/
            if (MessageBox.Show("¿Está seguro que desea salir del sistema?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)==DialogResult.Yes)
            {
                this.Close();
                Close();
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
    }
}
