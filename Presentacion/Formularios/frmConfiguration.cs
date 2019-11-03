using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Presentacion;

namespace capaPresentacion.Formularios
{
    public partial class frmConfiguration : Form
    {
        public frmConfiguration()
        {
            InitializeComponent();
        }

        private void FormConfiguration_Load(object sender, EventArgs e)
        {
            txtServidor.Text = Properties.Settings.Default.Servidor;
            txtBaseDatos.Text = Properties.Settings.Default.BaseDatos;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            
            Properties.Settings.Default.BaseDatos = txtBaseDatos.Text;
            Properties.Settings.Default.Servidor = txtServidor.Text;
            String ConnectionString = "data source = " + Properties.Settings.Default.Servidor + "; initial catalog = " + Properties.Settings.Default.BaseDatos + "; Integrated Security=True";
            Properties.Settings.Default.connStock = ConnectionString;
            using (SqlConnection CN = new SqlConnection(ConnectionString))
            {
                try
                {
                    CN.Open();
                    MessageBox.Show("Conexion realizada");

                    frmLogin formLogin = new frmLogin();
                    formLogin.Show();
                    this.Hide();//esconde el formulario
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo establecer conexion");
                }
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
