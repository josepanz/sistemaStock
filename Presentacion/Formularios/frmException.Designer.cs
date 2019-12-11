namespace capaPresentacion.Formularios
{
    partial class frmException
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
            this.pcbErr = new System.Windows.Forms.PictureBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtMensaje = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbErr)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbErr
            // 
            this.pcbErr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbErr.Location = new System.Drawing.Point(12, 12);
            this.pcbErr.Name = "pcbErr";
            this.pcbErr.Size = new System.Drawing.Size(428, 190);
            this.pcbErr.TabIndex = 0;
            this.pcbErr.TabStop = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(180, 235);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // txtMensaje
            // 
            this.txtMensaje.AutoSize = true;
            this.txtMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensaje.ForeColor = System.Drawing.Color.Red;
            this.txtMensaje.Location = new System.Drawing.Point(134, 209);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(0, 13);
            this.txtMensaje.TabIndex = 2;
            // 
            // frmException
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 270);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.pcbErr);
            this.Name = "frmException";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advertencia";
            this.Load += new System.EventHandler(this.FrmException_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbErr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbErr;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label txtMensaje;
    }
}