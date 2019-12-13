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

namespace capaPresentacion.Formularios
{
    public partial class frmDevelopers : Form
    {
        string url;
        Bitmap MyImage;
        public frmDevelopers()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                setearUrl("C:\\Users\\Panza\\source\\repos\\josepanz\\sistemaStock\\img\\pratt.jpg");
                lblDescripcion.Text = "DESCRIPCION: Latrell Spencer: El negro del grupo, no tiene nada de parecido con la personalidad, pero ambos son negros, Sebastian Pratt";
                lblDescripcion.ForeColor = Color.Black;
                try
                {
                    if (MyImage != null)
                    {
                        MyImage.Dispose();
                    }

                    MyImage = new Bitmap(url);

                    pcbDev.Image = MyImage;
                    pcbDev.SizeMode = PictureBoxSizeMode.StretchImage;
                    /*SoundPlayer playError = new SoundPlayer(@"C:\Users\Panza\source\repos\josepanz\sistemaStock\sound\/Todo_el_maldito_sistema_esta_mal.wav");
                    playError.Play();*/
                }
                catch (Exception ex)
                {
                    Console.WriteLine("no hay audio");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("No se encontro la direccion de la imagen");
            }
        }

        private void BtnPanza_Click(object sender, EventArgs e)
        {
           
            try
            {
                setearUrl("C:\\Users\\Panza\\source\\repos\\josepanz\\sistemaStock\\img\\panza.jpg");
                lblDescripcion.Text = "DESCRIPCION: Peter Griffin: El Gordo Buena Onda y simpatico del grupo, Jose Panza";
                lblDescripcion.ForeColor = Color.Blue;
                try
                {
                    if (MyImage != null)
                    {
                        MyImage.Dispose();
                    }

                    MyImage = new Bitmap(url);

                    pcbDev.Image = MyImage;
                    pcbDev.SizeMode = PictureBoxSizeMode.StretchImage;
                    /*SoundPlayer playError = new SoundPlayer(@"C:\Users\Panza\source\repos\josepanz\sistemaStock\sound\/Todo_el_maldito_sistema_esta_mal.wav");
                    playError.Play();*/
                }
                catch (Exception ex)
                {
                    Console.WriteLine("no hay audio");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("No se encontro la direccion de la imagen");
            }
           
        }
        public void setearUrl(string url)
        {

            this.url = url;
        }

        private void BtnJuan_Click(object sender, EventArgs e)
        {
            try
            {
                setearUrl("C:\\Users\\Panza\\source\\repos\\josepanz\\sistemaStock\\img\\juan.png");
                lblDescripcion.Text = "DESCRIPCION: Cabo: El serio y militarizado amigo del grupo, Juan Cristaldo";
                lblDescripcion.ForeColor = Color.Blue;
                try
                {
                    if (MyImage != null)
                    {
                        MyImage.Dispose();
                    }

                    MyImage = new Bitmap(url);

                    pcbDev.Image = MyImage;
                    pcbDev.SizeMode = PictureBoxSizeMode.StretchImage;
                    /*SoundPlayer playError = new SoundPlayer(@"C:\Users\Panza\source\repos\josepanz\sistemaStock\sound\/Todo_el_maldito_sistema_esta_mal.wav");
                    playError.Play();*/
                }
                catch (Exception ex)
                {
                    Console.WriteLine("no hay audio");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("No se encontro la direccion de la imagen");
            }
        }

        private void BtnHugo_Click(object sender, EventArgs e)
        {
            try
            {
                setearUrl("C:\\Users\\Panza\\source\\repos\\josepanz\\sistemaStock\\img\\contador.jpg");
                lblDescripcion.Text = "DESCRIPCION: Sasuke: El emo vengador de Materias Perdidas (la de sus amigos), Hugo Rodriguez";
                lblDescripcion.ForeColor = Color.Blue;
                try
                {
                    if (MyImage != null)
                    {
                        MyImage.Dispose();
                    }

                    MyImage = new Bitmap(url);

                    pcbDev.Image = MyImage;
                    pcbDev.SizeMode = PictureBoxSizeMode.StretchImage;
                    /*SoundPlayer playError = new SoundPlayer(@"C:\Users\Panza\source\repos\josepanz\sistemaStock\sound\/Todo_el_maldito_sistema_esta_mal.wav");
                    playError.Play();*/
                }
                catch (Exception ex)
                {
                    Console.WriteLine("no hay audio");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("No se encontro la direccion de la imagen");
            }

        }

        private void BtnMarcos_Click(object sender, EventArgs e)
        {
            try
            {
                setearUrl("C:\\Users\\Panza\\source\\repos\\josepanz\\sistemaStock\\img\\marcos.jpg");
                lblDescripcion.Text = "DESCRIPCION: Harry Potter: El que por arte de Magia Pasa, Marcos Aquino";
                lblDescripcion.ForeColor = Color.Blue;
                try
                {
                    if (MyImage != null)
                    {
                        MyImage.Dispose();
                    }

                    MyImage = new Bitmap(url);

                    pcbDev.Image = MyImage;
                    pcbDev.SizeMode = PictureBoxSizeMode.StretchImage;
                    SoundPlayer playError = new SoundPlayer(@"C:\Users\Panza\source\repos\josepanz\sistemaStock\sound\harryFlaute.wav");
                    playError.Play();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("no hay audio");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("No se encontro la direccion de la imagen");
            }
        }

        private void BtnGeneral_Click(object sender, EventArgs e)
        {
            try
            {

                setearUrl("C:\\Users\\Panza\\source\\repos\\josepanz\\sistemaStock\\img\\pajaroOsado.jpg");
                lblDescripcion.Text = "Sistema de Gestion de Stock Pajaro Osado";
                lblDescripcion.ForeColor = Color.Black;
                try
                {
                    if (MyImage != null)
                    {
                        MyImage.Dispose();
                    }

                    MyImage = new Bitmap(url);

                    pcbDev.Image = MyImage;
                    pcbDev.SizeMode = PictureBoxSizeMode.StretchImage;
                    /*SoundPlayer playError = new SoundPlayer(@"C:\Users\Panza\source\repos\josepanz\sistemaStock\sound\/Todo_el_maldito_sistema_esta_mal.wav");
                    playError.Play();*/
                }
                catch (Exception ex)
                {
                    Console.WriteLine("no hay audio");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("No se encontro la direccion de la imagen");
            }
        }

        private void FrmDevelopers_Load(object sender, EventArgs e)
        {
            try
            {
                setearUrl("C:\\Users\\Panza\\source\\repos\\josepanz\\sistemaStock\\img\\equipo.jpg");
                lblDescripcion.Text = "El Equipo Alfa Buena Maravilla Onda Dinamita Escuadron Lobo, les presenta... ";
                lblDescripcion.ForeColor = Color.Black;
                try
                {
                    if (MyImage != null)
                    {
                        MyImage.Dispose();
                    }

                    MyImage = new Bitmap(url);

                    pcbDev.Image = MyImage;
                    pcbDev.SizeMode = PictureBoxSizeMode.StretchImage;
                    /*SoundPlayer playError = new SoundPlayer(@"C:\Users\Panza\source\repos\josepanz\sistemaStock\sound\/Todo_el_maldito_sistema_esta_mal.wav");
                    playError.Play();*/
                }
                catch (Exception ex)
                {
                    Console.WriteLine("no hay audio");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("No se encontro la direccion de la imagen");
            }

        }
    }
}
