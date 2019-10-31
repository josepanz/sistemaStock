using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace capaPresentacion.Formularios
{
    public partial class formConnection : Form
    {
        public formConnection()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string va = ConfigurationManager.ConnectionStrings["connStock"].ToString();
            MessageBox.Show(va);
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            string server = txtServidor.Text.Trim();
            string bd = txtBaseDatos.Text.Trim();

            XmlDocument xml = new XmlDocument();

            xml.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            foreach (XmlElement element in xml.DocumentElement)
            {
                if (element.Name.Equals("connectionStrings"))
                {
                    foreach(XmlNode node in element.ChildNodes)
                    {
                        if (node.Attributes[0].Value== "connStock")
                        {
                            node.Attributes[1].Value = "Data Source = " + server + "; Initial Catalog =" + bd + "; Integrated Security = True";

                        }
                    }
                }
            }

            xml.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}
