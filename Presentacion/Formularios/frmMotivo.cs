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
    public partial class frmMotivo : Form
    {
        public frmMotivo()
        {
            InitializeComponent();
        }

        private void frmMotivo_Load(object sender, EventArgs e)
        {
            ListarMotivo();
        }
        private void ListarMotivo()
        {
            dgvMotivo.DataSource = null;
            dgvMotivo.DataSource = Motivo.ObtenerMotivos();
        }

        private void LimpiarFormulario()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Motivo m = ObtenerMotivoFormulario();
            if (validarNulos())
            {
                Motivo.AgregarMotivo(m);
                ListarMotivo();
                LimpiarFormulario();
            }
        }

        private Motivo ObtenerMotivoFormulario()
        {
            Motivo motivo = new Motivo();
            motivo.descripcion = txtDescripcion.Text.Trim();
            try
            {
                motivo.id = Convert.ToInt32(txtCodigo.Text.Trim());
            }
            catch (FormatException f) { }
            return motivo;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Motivo mar = (Motivo)dgvMotivo.CurrentRow.DataBoundItem;
            if (mar != null)
            {
                Motivo.EliminarMotivo(mar);
                ListarMotivo();
                LimpiarFormulario();
            }
            ListarMotivo();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Motivo motivo = (Motivo)dgvMotivo.CurrentRow.DataBoundItem;

            if (motivo != null)
            {
                int index = dgvMotivo.CurrentCell.RowIndex;
                Motivo m = ObtenerMotivoFormulario();
                Motivo.EditarMotivo(index, m);
                ListarMotivo();
                LimpiarFormulario();
            }
        }

        private Motivo ObtenerMotivo()
        {
            Motivo mar = new Motivo();
            mar.id = Convert.ToInt32(txtCodigo.Text);
            mar.descripcion = txtDescripcion.Text.Trim();


            return mar;
        }

        private void dgvMotivo_Click(object sender, EventArgs e)
        {
            Motivo mar = (Motivo)dgvMotivo.CurrentRow.DataBoundItem;

            if (mar != null)
            {
                txtCodigo.Text = Convert.ToString(mar.id);
                txtDescripcion.Text = mar.descripcion;

            }
        }
        private bool validarNulos()
        {
            bool flag = true;
            frmException err = new frmException();
            err.setearUrl("C:\\Users\\Panza\\source\\repos\\josepanz\\sistemaStock\\img\\algoAndaMal.jpg");

           
            if (txtDescripcion.Text.Trim() == null || txtDescripcion.Text.Trim()=="") 
            {
                err.Controls["txtMensaje"].Text = "Debe cargar el valor de la descripcion del motivo";
                txtDescripcion.Focus();
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
