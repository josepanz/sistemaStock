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
   
    public partial class frmException : Form
    {
        string url;
        public frmException()
        {
            InitializeComponent();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            frmException form = new frmException();
            this.Close();
        }

        private void FrmException_Load(object sender, EventArgs e)
        {
            Excepcion err = new Excepcion();
            
            pcbErr.Image =   err.mostrarErr(url);
            pcbErr.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        public void setearUrl(string url) {

            this.url = url;
        }
    }
}
