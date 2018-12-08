namespace SAP.Ventanas
{
    partial class FrmPuntoVenta
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
            this.LblNombreEmpresa = new System.Windows.Forms.Label();
            this.DtgvProductos = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtPrecio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.TxtCantidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.TxtCodigoBarras = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PbLogo = new System.Windows.Forms.PictureBox();
            this.LblTotal = new System.Windows.Forms.Label();
            this.BtnFinCompra = new System.Windows.Forms.Button();
            this.BtnLimpCom = new System.Windows.Forms.Button();
            this.BtnEditProducto = new System.Windows.Forms.Button();
            this.BtnElimProducto = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.PnlBusqueda = new System.Windows.Forms.Panel();
            this.DtgvListadoBusqueda = new System.Windows.Forms.DataGridView();
            this.LblCantidadProductos = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnFacturar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgvProductos)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).BeginInit();
            this.PnlBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgvListadoBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // LblNombreEmpresa
            // 
            this.LblNombreEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombreEmpresa.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LblNombreEmpresa.Location = new System.Drawing.Point(231, 12);
            this.LblNombreEmpresa.Name = "LblNombreEmpresa";
            this.LblNombreEmpresa.Size = new System.Drawing.Size(452, 115);
            this.LblNombreEmpresa.TabIndex = 1;
            this.LblNombreEmpresa.Text = "Sistema de Administración de Papelería";
            this.LblNombreEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DtgvProductos
            // 
            this.DtgvProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgvProductos.Location = new System.Drawing.Point(39, 238);
            this.DtgvProductos.Name = "DtgvProductos";
            this.DtgvProductos.Size = new System.Drawing.Size(957, 189);
            this.DtgvProductos.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.TxtPrecio);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.BtnLimpiar);
            this.panel1.Controls.Add(this.BtnAgregar);
            this.panel1.Controls.Add(this.TxtCantidad);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TxtNombre);
            this.panel1.Controls.Add(this.TxtCodigoBarras);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(39, 142);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 51);
            this.panel1.TabIndex = 5;
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPrecio.Enabled = false;
            this.TxtPrecio.Location = new System.Drawing.Point(555, 14);
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Size = new System.Drawing.Size(68, 20);
            this.TxtPrecio.TabIndex = 6;
            this.TxtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(509, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Precio:";
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnLimpiar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.BtnLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpiar.Location = new System.Drawing.Point(862, 12);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(92, 23);
            this.BtnLimpiar.TabIndex = 4;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAgregar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.BtnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregar.Location = new System.Drawing.Point(764, 12);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(92, 23);
            this.BtnAgregar.TabIndex = 3;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCantidad.Location = new System.Drawing.Point(690, 15);
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(68, 20);
            this.TxtCantidad.TabIndex = 2;
            this.TxtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCantidad_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(629, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cantidad:";
            // 
            // TxtNombre
            // 
            this.TxtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNombre.Location = new System.Drawing.Point(272, 14);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(231, 20);
            this.TxtNombre.TabIndex = 1;
            this.TxtNombre.TextChanged += new System.EventHandler(this.TxtNombre_TextChanged);
            this.TxtNombre.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtNombre_KeyUp);
            // 
            // TxtCodigoBarras
            // 
            this.TxtCodigoBarras.Location = new System.Drawing.Point(108, 14);
            this.TxtCodigoBarras.Name = "TxtCodigoBarras";
            this.TxtCodigoBarras.Size = new System.Drawing.Size(105, 20);
            this.TxtCodigoBarras.TabIndex = 0;
            this.TxtCodigoBarras.TextChanged += new System.EventHandler(this.TxtCodigoBarras_TextChanged);
            this.TxtCodigoBarras.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtCodigoBarras_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código de Barras";
            // 
            // PbLogo
            // 
            this.PbLogo.BackColor = System.Drawing.Color.White;
            this.PbLogo.Image = global::SAP.Properties.Resources.logoSAP;
            this.PbLogo.Location = new System.Drawing.Point(39, 12);
            this.PbLogo.Name = "PbLogo";
            this.PbLogo.Size = new System.Drawing.Size(186, 124);
            this.PbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbLogo.TabIndex = 6;
            this.PbLogo.TabStop = false;
            // 
            // LblTotal
            // 
            this.LblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotal.ForeColor = System.Drawing.Color.DodgerBlue;
            this.LblTotal.Location = new System.Drawing.Point(734, 39);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(274, 68);
            this.LblTotal.TabIndex = 7;
            this.LblTotal.Text = "0.00";
            this.LblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnFinCompra
            // 
            this.BtnFinCompra.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.BtnFinCompra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnFinCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFinCompra.Location = new System.Drawing.Point(39, 199);
            this.BtnFinCompra.Name = "BtnFinCompra";
            this.BtnFinCompra.Size = new System.Drawing.Size(123, 24);
            this.BtnFinCompra.TabIndex = 8;
            this.BtnFinCompra.Text = "F1 Finalizar Compra";
            this.BtnFinCompra.UseVisualStyleBackColor = true;
            this.BtnFinCompra.Click += new System.EventHandler(this.BtnFinCompra_Click);
            // 
            // BtnLimpCom
            // 
            this.BtnLimpCom.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.BtnLimpCom.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnLimpCom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpCom.Location = new System.Drawing.Point(168, 199);
            this.BtnLimpCom.Name = "BtnLimpCom";
            this.BtnLimpCom.Size = new System.Drawing.Size(123, 24);
            this.BtnLimpCom.TabIndex = 9;
            this.BtnLimpCom.Text = "F4 Limpiar Compra";
            this.BtnLimpCom.UseVisualStyleBackColor = true;
            this.BtnLimpCom.Click += new System.EventHandler(this.BtnLimpCom_Click);
            // 
            // BtnEditProducto
            // 
            this.BtnEditProducto.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.BtnEditProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnEditProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditProducto.Location = new System.Drawing.Point(426, 200);
            this.BtnEditProducto.Name = "BtnEditProducto";
            this.BtnEditProducto.Size = new System.Drawing.Size(123, 23);
            this.BtnEditProducto.TabIndex = 10;
            this.BtnEditProducto.Text = "F5 Editar Producto";
            this.BtnEditProducto.UseVisualStyleBackColor = true;
            this.BtnEditProducto.Click += new System.EventHandler(this.BtnEditProducto_Click);
            // 
            // BtnElimProducto
            // 
            this.BtnElimProducto.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.BtnElimProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnElimProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnElimProducto.Location = new System.Drawing.Point(297, 200);
            this.BtnElimProducto.Name = "BtnElimProducto";
            this.BtnElimProducto.Size = new System.Drawing.Size(123, 23);
            this.BtnElimProducto.TabIndex = 11;
            this.BtnElimProducto.Text = "Supr Eliminar Producto";
            this.BtnElimProducto.UseVisualStyleBackColor = true;
            this.BtnElimProducto.Click += new System.EventHandler(this.BtnElimProducto_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(559, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 68);
            this.label4.TabIndex = 12;
            this.label4.Text = "Total $:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PnlBusqueda
            // 
            this.PnlBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlBusqueda.BackColor = System.Drawing.Color.White;
            this.PnlBusqueda.Controls.Add(this.DtgvListadoBusqueda);
            this.PnlBusqueda.Location = new System.Drawing.Point(197, 181);
            this.PnlBusqueda.Name = "PnlBusqueda";
            this.PnlBusqueda.Size = new System.Drawing.Size(655, 171);
            this.PnlBusqueda.TabIndex = 5;
            this.PnlBusqueda.Visible = false;
            // 
            // DtgvListadoBusqueda
            // 
            this.DtgvListadoBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtgvListadoBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgvListadoBusqueda.Location = new System.Drawing.Point(13, 9);
            this.DtgvListadoBusqueda.Name = "DtgvListadoBusqueda";
            this.DtgvListadoBusqueda.Size = new System.Drawing.Size(627, 150);
            this.DtgvListadoBusqueda.TabIndex = 0;
            // 
            // LblCantidadProductos
            // 
            this.LblCantidadProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCantidadProductos.Location = new System.Drawing.Point(921, 209);
            this.LblCantidadProductos.Name = "LblCantidadProductos";
            this.LblCantidadProductos.Size = new System.Drawing.Size(75, 23);
            this.LblCantidadProductos.TabIndex = 7;
            this.LblCantidadProductos.Text = "0";
            this.LblCantidadProductos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(857, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Productos:";
            // 
            // BtnFacturar
            // 
            this.BtnFacturar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.BtnFacturar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnFacturar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFacturar.Location = new System.Drawing.Point(555, 200);
            this.BtnFacturar.Name = "BtnFacturar";
            this.BtnFacturar.Size = new System.Drawing.Size(82, 24);
            this.BtnFacturar.TabIndex = 14;
            this.BtnFacturar.Text = "F8 Facturar";
            this.BtnFacturar.UseVisualStyleBackColor = true;
            this.BtnFacturar.Click += new System.EventHandler(this.BtnFacturar_Click);
            // 
            // FrmPuntoVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1035, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LblCantidadProductos);
            this.Controls.Add(this.PnlBusqueda);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BtnElimProducto);
            this.Controls.Add(this.BtnEditProducto);
            this.Controls.Add(this.BtnLimpCom);
            this.Controls.Add(this.BtnFinCompra);
            this.Controls.Add(this.LblTotal);
            this.Controls.Add(this.PbLogo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DtgvProductos);
            this.Controls.Add(this.LblNombreEmpresa);
            this.Controls.Add(this.BtnFacturar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(915, 489);
            this.Name = "FrmPuntoVenta";
            this.ShowIcon = false;
            this.Text = "Venta de Productos";
            this.Load += new System.EventHandler(this.FrmPuntoVenta_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmPuntoVenta_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.DtgvProductos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbLogo)).EndInit();
            this.PnlBusqueda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgvListadoBusqueda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblNombreEmpresa;
        private System.Windows.Forms.DataGridView DtgvProductos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox PbLogo;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox TxtCodigoBarras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.TextBox TxtCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnFinCompra;
        private System.Windows.Forms.Button BtnLimpCom;
        private System.Windows.Forms.Button BtnEditProducto;
        private System.Windows.Forms.Button BtnElimProducto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel PnlBusqueda;
        private System.Windows.Forms.DataGridView DtgvListadoBusqueda;
        private System.Windows.Forms.TextBox TxtPrecio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblCantidadProductos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnFacturar;
    }
}