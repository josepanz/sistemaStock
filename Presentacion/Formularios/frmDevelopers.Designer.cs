namespace capaPresentacion.Formularios
{
    partial class frmDevelopers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMensaje = new System.Windows.Forms.Label();
            this.btnGeneral = new System.Windows.Forms.Button();
            this.btnPratt = new System.Windows.Forms.Button();
            this.btnMarcos = new System.Windows.Forms.Button();
            this.btnHugo = new System.Windows.Forms.Button();
            this.btnJuan = new System.Windows.Forms.Button();
            this.btnPanza = new System.Windows.Forms.Button();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.pcbDev = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbDev)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMensaje
            // 
            this.txtMensaje.AutoSize = true;
            this.txtMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensaje.ForeColor = System.Drawing.Color.Red;
            this.txtMensaje.Location = new System.Drawing.Point(134, 209);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(0, 13);
            this.txtMensaje.TabIndex = 5;
            // 
            // btnGeneral
            // 
            this.btnGeneral.Location = new System.Drawing.Point(36, 318);
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(75, 23);
            this.btnGeneral.TabIndex = 4;
            this.btnGeneral.Text = "General";
            this.btnGeneral.UseVisualStyleBackColor = true;
            this.btnGeneral.Click += new System.EventHandler(this.BtnGeneral_Click);
            // 
            // btnPratt
            // 
            this.btnPratt.Location = new System.Drawing.Point(117, 318);
            this.btnPratt.Name = "btnPratt";
            this.btnPratt.Size = new System.Drawing.Size(75, 23);
            this.btnPratt.TabIndex = 6;
            this.btnPratt.Text = "Negro";
            this.btnPratt.UseVisualStyleBackColor = true;
            this.btnPratt.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnMarcos
            // 
            this.btnMarcos.Location = new System.Drawing.Point(198, 318);
            this.btnMarcos.Name = "btnMarcos";
            this.btnMarcos.Size = new System.Drawing.Size(75, 23);
            this.btnMarcos.TabIndex = 7;
            this.btnMarcos.Text = "Harry Potter";
            this.btnMarcos.UseVisualStyleBackColor = true;
            this.btnMarcos.Click += new System.EventHandler(this.BtnMarcos_Click);
            // 
            // btnHugo
            // 
            this.btnHugo.Location = new System.Drawing.Point(279, 318);
            this.btnHugo.Name = "btnHugo";
            this.btnHugo.Size = new System.Drawing.Size(75, 23);
            this.btnHugo.TabIndex = 8;
            this.btnHugo.Text = "Contador";
            this.btnHugo.UseVisualStyleBackColor = true;
            this.btnHugo.Click += new System.EventHandler(this.BtnHugo_Click);
            // 
            // btnJuan
            // 
            this.btnJuan.Location = new System.Drawing.Point(360, 318);
            this.btnJuan.Name = "btnJuan";
            this.btnJuan.Size = new System.Drawing.Size(75, 23);
            this.btnJuan.TabIndex = 9;
            this.btnJuan.Text = "Cabo";
            this.btnJuan.UseVisualStyleBackColor = true;
            this.btnJuan.Click += new System.EventHandler(this.BtnJuan_Click);
            // 
            // btnPanza
            // 
            this.btnPanza.Location = new System.Drawing.Point(441, 318);
            this.btnPanza.Name = "btnPanza";
            this.btnPanza.Size = new System.Drawing.Size(75, 23);
            this.btnPanza.TabIndex = 10;
            this.btnPanza.Text = "Panza";
            this.btnPanza.UseVisualStyleBackColor = true;
            this.btnPanza.Click += new System.EventHandler(this.BtnPanza_Click);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(33, 243);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(501, 72);
            this.lblDescripcion.TabIndex = 0;
            this.lblDescripcion.Text = "Descripcion:";
            // 
            // pcbDev
            // 
            this.pcbDev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbDev.Location = new System.Drawing.Point(12, 12);
            this.pcbDev.Name = "pcbDev";
            this.pcbDev.Size = new System.Drawing.Size(522, 217);
            this.pcbDev.TabIndex = 3;
            this.pcbDev.TabStop = false;
            // 
            // frmDevelopers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 353);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.btnPanza);
            this.Controls.Add(this.btnJuan);
            this.Controls.Add(this.btnHugo);
            this.Controls.Add(this.btnMarcos);
            this.Controls.Add(this.btnPratt);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.btnGeneral);
            this.Controls.Add(this.pcbDev);
            this.Name = "frmDevelopers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDevelopers";
            this.Load += new System.EventHandler(this.FrmDevelopers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbDev)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtMensaje;
        private System.Windows.Forms.Button btnGeneral;
        private System.Windows.Forms.PictureBox pcbDev;
        private System.Windows.Forms.Button btnPratt;
        private System.Windows.Forms.Button btnMarcos;
        private System.Windows.Forms.Button btnHugo;
        private System.Windows.Forms.Button btnJuan;
        private System.Windows.Forms.Button btnPanza;
        private System.Windows.Forms.Label lblDescripcion;
    }
}