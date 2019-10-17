﻿using Presentacion.Formularios;
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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEmpleado frmprov = new FormEmpleado();
            frmprov.Show();
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
            }
            
        }
    }
}
