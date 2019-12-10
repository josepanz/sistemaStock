using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using capaPresentacion.Formularios;
using Clases;
using System.Media;

namespace Presentacion
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        #region Drag Form/ Mover Arrastrar Formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Placeholder or WaterMark
        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.Silver;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Contraseña";
                txtPass.ForeColor = Color.Silver;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        #endregion 

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        private void btnlogin_Click(object sender, EventArgs e)
        {

            if (txtUsuario.Text != "Usuario" )
            {
                if (txtPass.Text != "Contraseña")
                {
                    Empleado empleado = new Empleado();
                    var validLogin = empleado.obtenerCredenciales(txtUsuario.Text, txtPass.Text);
                    if (validLogin == true)
                    {
                        frmMenu frmMenu = new frmMenu();
                        frmMenu.Show();
                        //this.Close();
                        this.Hide();
                    }
                    else
                    {
                        try
                        {
                            SoundPlayer playError = new SoundPlayer(@"C:\Users\Panza\source\repos\josepanz\sistemaStock\sound\error.wav");
                            playError.Play();
                        }
                        catch (Exception ex) {
                            Console.WriteLine("no hay audio");
                        }
                        //MessageBox.Show("Incorrect username or password entered. \n   Please try again.");
                        MessageBox.Show("Usuario o Contraseña incorrecta. \n   Por favor Intenta de Nuevo");
                        txtPass.Text = "Contraseña";
                        txtUsuario.Text = "Usuario";
                        //SoundPlayer playError = new SoundPlayer(@"\sound\error.mp3");

                        txtPass.UseSystemPasswordChar = false;
                        txtUsuario.Focus();
                    }
                }
                else MessageBox.Show("Por Favor ingresa el Usuario");
            }
            else MessageBox.Show("Por Favor ingresa la Contraseña");
        }



    

    public bool validarVacios(string user, string pass)
        {
            bool bandera = false;
            if (user != null || user != "usuario")
            {
                bandera = true;
            }
            else { bandera = false; }
            if (pass != null || pass != "contraseña") {
                bandera = true;
            } else { bandera = false; }

            return bandera;
        }

        private void LinkServer_Click(object sender, EventArgs e)
        {
            frmConfiguration formConfiguration = new frmConfiguration();
            formConfiguration.Show();
            this.Hide();
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
