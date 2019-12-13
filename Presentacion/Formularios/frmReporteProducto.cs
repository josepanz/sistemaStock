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
    public partial class frmReporteProducto : Form
    {
        private ReporteProductos ReporteProductos1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;

        public frmReporteProducto()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.ReporteProductos1 = new capaPresentacion.Formularios.ReporteProductos();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = 0;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ReportSource = this.ReporteProductos1;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1234, 611);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // frmReporteProducto
            // 
            this.ClientSize = new System.Drawing.Size(1234, 611);
            this.Controls.Add(this.crystalReportViewer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReporteProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }
    }
}
