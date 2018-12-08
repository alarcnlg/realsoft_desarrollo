namespace SAP
{
    partial class FrmMDI
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
            this.MnuMain = new System.Windows.Forms.MenuStrip();
            this.TsmPuntoVenta = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmFacturacion = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmRptProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmRptVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmRptCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmRptFacturas = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmConfiguracion = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmBaseDeDatos = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // MnuMain
            // 
            this.MnuMain.BackColor = System.Drawing.Color.White;
            this.MnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmPuntoVenta,
            this.TsmProductos,
            this.TsmVentas,
            this.TsmFacturacion,
            this.TsmCompras,
            this.TsmReportes,
            this.TsmConfiguracion,
            this.TsmUsuario});
            this.MnuMain.Location = new System.Drawing.Point(0, 0);
            this.MnuMain.Name = "MnuMain";
            this.MnuMain.Size = new System.Drawing.Size(800, 24);
            this.MnuMain.TabIndex = 1;
            this.MnuMain.Text = "menuStrip1";
            // 
            // TsmPuntoVenta
            // 
            this.TsmPuntoVenta.Name = "TsmPuntoVenta";
            this.TsmPuntoVenta.Size = new System.Drawing.Size(99, 20);
            this.TsmPuntoVenta.Text = "Punto de Venta";
            this.TsmPuntoVenta.Click += new System.EventHandler(this.TsmPuntoVenta_Click);
            // 
            // TsmProductos
            // 
            this.TsmProductos.Name = "TsmProductos";
            this.TsmProductos.Size = new System.Drawing.Size(73, 20);
            this.TsmProductos.Text = "Productos";
            this.TsmProductos.Click += new System.EventHandler(this.TsmProductos_Click);
            // 
            // TsmVentas
            // 
            this.TsmVentas.Name = "TsmVentas";
            this.TsmVentas.Size = new System.Drawing.Size(53, 20);
            this.TsmVentas.Text = "Ventas";
            this.TsmVentas.Click += new System.EventHandler(this.TsmVentas_Click);
            // 
            // TsmFacturacion
            // 
            this.TsmFacturacion.Name = "TsmFacturacion";
            this.TsmFacturacion.Size = new System.Drawing.Size(81, 20);
            this.TsmFacturacion.Text = "Facturación";
            this.TsmFacturacion.Click += new System.EventHandler(this.TsmFacturacion_Click);
            // 
            // TsmCompras
            // 
            this.TsmCompras.Name = "TsmCompras";
            this.TsmCompras.Size = new System.Drawing.Size(67, 20);
            this.TsmCompras.Text = "Compras";
            this.TsmCompras.Click += new System.EventHandler(this.TsmCompras_Click);
            // 
            // TsmReportes
            // 
            this.TsmReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmRptProductos,
            this.TsmRptVentas,
            this.TsmRptCompras,
            this.TsmRptFacturas});
            this.TsmReportes.Name = "TsmReportes";
            this.TsmReportes.Size = new System.Drawing.Size(65, 20);
            this.TsmReportes.Text = "Reportes";
            // 
            // TsmRptProductos
            // 
            this.TsmRptProductos.Name = "TsmRptProductos";
            this.TsmRptProductos.Size = new System.Drawing.Size(128, 22);
            this.TsmRptProductos.Text = "Productos";
            this.TsmRptProductos.Click += new System.EventHandler(this.TsmRptProductos_Click);
            // 
            // TsmRptVentas
            // 
            this.TsmRptVentas.Name = "TsmRptVentas";
            this.TsmRptVentas.Size = new System.Drawing.Size(128, 22);
            this.TsmRptVentas.Text = "Ventas";
            this.TsmRptVentas.Click += new System.EventHandler(this.TsmRptVentas_Click);
            // 
            // TsmRptCompras
            // 
            this.TsmRptCompras.Name = "TsmRptCompras";
            this.TsmRptCompras.Size = new System.Drawing.Size(128, 22);
            this.TsmRptCompras.Text = "Compras";
            this.TsmRptCompras.Click += new System.EventHandler(this.TsmRptCompras_Click);
            // 
            // TsmRptFacturas
            // 
            this.TsmRptFacturas.Name = "TsmRptFacturas";
            this.TsmRptFacturas.Size = new System.Drawing.Size(128, 22);
            this.TsmRptFacturas.Text = "Facturas";
            this.TsmRptFacturas.Click += new System.EventHandler(this.TsmRptFacturas_Click);
            // 
            // TsmConfiguracion
            // 
            this.TsmConfiguracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmUsuarios,
            this.TsmBaseDeDatos});
            this.TsmConfiguracion.Name = "TsmConfiguracion";
            this.TsmConfiguracion.Size = new System.Drawing.Size(95, 20);
            this.TsmConfiguracion.Text = "Configuración";
            // 
            // TsmUsuarios
            // 
            this.TsmUsuarios.Name = "TsmUsuarios";
            this.TsmUsuarios.Size = new System.Drawing.Size(147, 22);
            this.TsmUsuarios.Text = "Usuarios";
            this.TsmUsuarios.Click += new System.EventHandler(this.TsmUsuarios_Click);
            // 
            // TsmBaseDeDatos
            // 
            this.TsmBaseDeDatos.Name = "TsmBaseDeDatos";
            this.TsmBaseDeDatos.Size = new System.Drawing.Size(147, 22);
            this.TsmBaseDeDatos.Text = "Base de Datos";
            this.TsmBaseDeDatos.Click += new System.EventHandler(this.TsmBaseDeDatos_Click);
            // 
            // TsmUsuario
            // 
            this.TsmUsuario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmCerrarSesion,
            this.TsmSalir});
            this.TsmUsuario.Name = "TsmUsuario";
            this.TsmUsuario.Size = new System.Drawing.Size(59, 20);
            this.TsmUsuario.Text = "Usuario";
            // 
            // TsmCerrarSesion
            // 
            this.TsmCerrarSesion.Name = "TsmCerrarSesion";
            this.TsmCerrarSesion.Size = new System.Drawing.Size(143, 22);
            this.TsmCerrarSesion.Text = "Cerrar Sesión";
            this.TsmCerrarSesion.Click += new System.EventHandler(this.TsmCerrarSesion_Click);
            // 
            // TsmSalir
            // 
            this.TsmSalir.Name = "TsmSalir";
            this.TsmSalir.Size = new System.Drawing.Size(143, 22);
            this.TsmSalir.Text = "Salir";
            this.TsmSalir.Click += new System.EventHandler(this.TsmSalir_Click);
            // 
            // FrmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MnuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MnuMain;
            this.Name = "FrmMDI";
            this.ShowIcon = false;
            this.Text = "SAP-Sistema de Administración de Papelería";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMDI_FormClosed);
            this.Load += new System.EventHandler(this.FrmMDI_Load);
            this.MnuMain.ResumeLayout(false);
            this.MnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MnuMain;
        private System.Windows.Forms.ToolStripMenuItem TsmConfiguracion;
        private System.Windows.Forms.ToolStripMenuItem TsmUsuarios;
        private System.Windows.Forms.ToolStripMenuItem TsmBaseDeDatos;
        private System.Windows.Forms.ToolStripMenuItem TsmUsuario;
        private System.Windows.Forms.ToolStripMenuItem TsmCerrarSesion;
        private System.Windows.Forms.ToolStripMenuItem TsmSalir;
        private System.Windows.Forms.ToolStripMenuItem TsmProductos;
        private System.Windows.Forms.ToolStripMenuItem TsmPuntoVenta;
        private System.Windows.Forms.ToolStripMenuItem TsmVentas;
        private System.Windows.Forms.ToolStripMenuItem TsmCompras;
        private System.Windows.Forms.ToolStripMenuItem TsmReportes;
        private System.Windows.Forms.ToolStripMenuItem TsmRptProductos;
        private System.Windows.Forms.ToolStripMenuItem TsmRptVentas;
        private System.Windows.Forms.ToolStripMenuItem TsmRptCompras;
        private System.Windows.Forms.ToolStripMenuItem TsmRptFacturas;
        private System.Windows.Forms.ToolStripMenuItem TsmFacturacion;
    }
}