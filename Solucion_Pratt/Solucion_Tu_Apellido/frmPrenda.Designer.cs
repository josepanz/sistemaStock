namespace Interfaz_tienda_Pratt
{
    partial class frmPrendas
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
            this.lblDetalle = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblCambiable = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblPrecioCosto = new System.Windows.Forms.Label();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.lblUtilidadBruta = new System.Windows.Forms.Label();
            this.lblFechaIngreso = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.txtDetalles = new System.Windows.Forms.TextBox();
            this.txtPrecioCosto = new System.Windows.Forms.TextBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.txtUtilidadBruta = new System.Windows.Forms.TextBox();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.cmbTipoPrenda = new System.Windows.Forms.ComboBox();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.rdbSi = new System.Windows.Forms.RadioButton();
            this.rdbNo = new System.Windows.Forms.RadioButton();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lstPrenda = new System.Windows.Forms.ListBox();
            this.txtTamaño = new System.Windows.Forms.TextBox();
            this.lblTamaño = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Location = new System.Drawing.Point(29, 87);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(45, 13);
            this.lblDetalle.TabIndex = 0;
            this.lblDetalle.Text = "Detalles";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(31, 125);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(31, 13);
            this.lblColor.TabIndex = 2;
            this.lblColor.Text = "Color";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(27, 159);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(65, 13);
            this.lblTipo.TabIndex = 3;
            this.lblTipo.Text = "Tipo Prenda";
            // 
            // lblCambiable
            // 
            this.lblCambiable.AutoSize = true;
            this.lblCambiable.Location = new System.Drawing.Point(31, 269);
            this.lblCambiable.Name = "lblCambiable";
            this.lblCambiable.Size = new System.Drawing.Size(56, 13);
            this.lblCambiable.TabIndex = 4;
            this.lblCambiable.Text = "Cambiable";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(262, 117);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(94, 13);
            this.lblPrecio.TabIndex = 5;
            this.lblPrecio.Text = "Precio y Utilidades";
            // 
            // lblPrecioCosto
            // 
            this.lblPrecioCosto.AutoSize = true;
            this.lblPrecioCosto.Location = new System.Drawing.Point(262, 152);
            this.lblPrecioCosto.Name = "lblPrecioCosto";
            this.lblPrecioCosto.Size = new System.Drawing.Size(67, 13);
            this.lblPrecioCosto.TabIndex = 6;
            this.lblPrecioCosto.Text = "Precio Costo";
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Location = new System.Drawing.Point(262, 187);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(68, 13);
            this.lblPrecioVenta.TabIndex = 7;
            this.lblPrecioVenta.Text = "Precio Venta";
            // 
            // lblUtilidadBruta
            // 
            this.lblUtilidadBruta.AutoSize = true;
            this.lblUtilidadBruta.Location = new System.Drawing.Point(262, 219);
            this.lblUtilidadBruta.Name = "lblUtilidadBruta";
            this.lblUtilidadBruta.Size = new System.Drawing.Size(70, 13);
            this.lblUtilidadBruta.TabIndex = 8;
            this.lblUtilidadBruta.Text = "Utilidad Bruta";
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.AutoSize = true;
            this.lblFechaIngreso.Location = new System.Drawing.Point(262, 87);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(75, 13);
            this.lblFechaIngreso.TabIndex = 9;
            this.lblFechaIngreso.Text = "Fecha Ingreso";
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(31, 231);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(56, 13);
            this.lblProveedor.TabIndex = 10;
            this.lblProveedor.Text = "Proveedor";
            // 
            // txtDetalles
            // 
            this.txtDetalles.Location = new System.Drawing.Point(107, 79);
            this.txtDetalles.Name = "txtDetalles";
            this.txtDetalles.Size = new System.Drawing.Size(121, 20);
            this.txtDetalles.TabIndex = 0;
            // 
            // txtPrecioCosto
            // 
            this.txtPrecioCosto.Location = new System.Drawing.Point(343, 145);
            this.txtPrecioCosto.Name = "txtPrecioCosto";
            this.txtPrecioCosto.Size = new System.Drawing.Size(121, 20);
            this.txtPrecioCosto.TabIndex = 8;
            this.txtPrecioCosto.Leave += new System.EventHandler(this.txtPrecioCosto_Leave_1);
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(343, 180);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(121, 20);
            this.txtPrecioVenta.TabIndex = 9;
            // 
            // txtUtilidadBruta
            // 
            this.txtUtilidadBruta.Location = new System.Drawing.Point(343, 212);
            this.txtUtilidadBruta.Name = "txtUtilidadBruta";
            this.txtUtilidadBruta.Size = new System.Drawing.Size(121, 20);
            this.txtUtilidadBruta.TabIndex = 10;
            // 
            // cmbColor
            // 
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(107, 117);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(121, 21);
            this.cmbColor.TabIndex = 2;
            // 
            // cmbTipoPrenda
            // 
            this.cmbTipoPrenda.FormattingEnabled = true;
            this.cmbTipoPrenda.Location = new System.Drawing.Point(107, 154);
            this.cmbTipoPrenda.Name = "cmbTipoPrenda";
            this.cmbTipoPrenda.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoPrenda.TabIndex = 3;
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(107, 228);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(121, 21);
            this.cmbProveedor.TabIndex = 7;
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaIngreso.Location = new System.Drawing.Point(343, 87);
            this.dtpFechaIngreso.MinDate = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(121, 20);
            this.dtpFechaIngreso.TabIndex = 6;
            // 
            // rdbSi
            // 
            this.rdbSi.AutoSize = true;
            this.rdbSi.Location = new System.Drawing.Point(112, 269);
            this.rdbSi.Name = "rdbSi";
            this.rdbSi.Size = new System.Drawing.Size(34, 17);
            this.rdbSi.TabIndex = 4;
            this.rdbSi.TabStop = true;
            this.rdbSi.Text = "Si";
            this.rdbSi.UseVisualStyleBackColor = true;
            // 
            // rdbNo
            // 
            this.rdbNo.AutoSize = true;
            this.rdbNo.Location = new System.Drawing.Point(164, 269);
            this.rdbNo.Name = "rdbNo";
            this.rdbNo.Size = new System.Drawing.Size(39, 17);
            this.rdbNo.TabIndex = 5;
            this.rdbNo.TabStop = true;
            this.rdbNo.Text = "No";
            this.rdbNo.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(83, 444);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 22;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click_1);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(164, 444);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 23;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click_1);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(245, 444);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 24;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(337, 444);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 25;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_1);
            // 
            // lstPrenda
            // 
            this.lstPrenda.FormattingEnabled = true;
            this.lstPrenda.Location = new System.Drawing.Point(32, 305);
            this.lstPrenda.Name = "lstPrenda";
            this.lstPrenda.Size = new System.Drawing.Size(417, 95);
            this.lstPrenda.TabIndex = 26;
            this.lstPrenda.Click += new System.EventHandler(this.lstPrenda_Click_1);
            // 
            // txtTamaño
            // 
            this.txtTamaño.Location = new System.Drawing.Point(107, 189);
            this.txtTamaño.Name = "txtTamaño";
            this.txtTamaño.Size = new System.Drawing.Size(121, 20);
            this.txtTamaño.TabIndex = 27;
            // 
            // lblTamaño
            // 
            this.lblTamaño.AutoSize = true;
            this.lblTamaño.Location = new System.Drawing.Point(29, 196);
            this.lblTamaño.Name = "lblTamaño";
            this.lblTamaño.Size = new System.Drawing.Size(46, 13);
            this.lblTamaño.TabIndex = 28;
            this.lblTamaño.Text = "Tamaño";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(176, 24);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(126, 37);
            this.lblTitulo.TabIndex = 29;
            this.lblTitulo.Text = "Prenda";
            // 
            // frmPrendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 498);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.txtTamaño);
            this.Controls.Add(this.lblTamaño);
            this.Controls.Add(this.lstPrenda);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.rdbNo);
            this.Controls.Add(this.rdbSi);
            this.Controls.Add(this.dtpFechaIngreso);
            this.Controls.Add(this.cmbProveedor);
            this.Controls.Add(this.cmbTipoPrenda);
            this.Controls.Add(this.cmbColor);
            this.Controls.Add(this.txtUtilidadBruta);
            this.Controls.Add(this.txtPrecioVenta);
            this.Controls.Add(this.txtPrecioCosto);
            this.Controls.Add(this.txtDetalles);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.lblFechaIngreso);
            this.Controls.Add(this.lblUtilidadBruta);
            this.Controls.Add(this.lblPrecioVenta);
            this.Controls.Add(this.lblPrecioCosto);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblCambiable);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblDetalle);
            this.Name = "frmPrendas";
            this.Text = "Prendas";
            this.Load += new System.EventHandler(this.frmPrendas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblCambiable;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblPrecioCosto;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.Label lblUtilidadBruta;
        private System.Windows.Forms.Label lblFechaIngreso;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.TextBox txtDetalles;
        private System.Windows.Forms.TextBox txtPrecioCosto;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.TextBox txtUtilidadBruta;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.ComboBox cmbTipoPrenda;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
        private System.Windows.Forms.RadioButton rdbSi;
        private System.Windows.Forms.RadioButton rdbNo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.ListBox lstPrenda;
        private System.Windows.Forms.TextBox txtTamaño;
        private System.Windows.Forms.Label lblTamaño;
        private System.Windows.Forms.Label lblTitulo;
    }
}