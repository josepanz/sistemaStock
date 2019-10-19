using Interfaz_tienda_Pratt;
using System;
using System.Windows.Forms;

namespace Interfaz_Tienda_Pratt
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void proveedorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmProveedor pro = new frmProveedor();
            pro.Show();
        }

        private void prendaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmPrendas pre = new frmPrendas();
            pre.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
