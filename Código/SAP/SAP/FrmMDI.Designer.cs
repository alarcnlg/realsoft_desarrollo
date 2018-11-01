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
            this.MnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmConfiguracion,
            this.TsmUsuario});
            this.MnuMain.Location = new System.Drawing.Point(0, 0);
            this.MnuMain.Name = "MnuMain";
            this.MnuMain.Size = new System.Drawing.Size(800, 24);
            this.MnuMain.TabIndex = 1;
            this.MnuMain.Text = "menuStrip1";
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
            this.TsmUsuarios.Size = new System.Drawing.Size(180, 22);
            this.TsmUsuarios.Text = "Usuarios";
            this.TsmUsuarios.Click += new System.EventHandler(this.TsmUsuarios_Click);
            // 
            // TsmBaseDeDatos
            // 
            this.TsmBaseDeDatos.Name = "TsmBaseDeDatos";
            this.TsmBaseDeDatos.Size = new System.Drawing.Size(180, 22);
            this.TsmBaseDeDatos.Text = "Base de Datos";
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
            this.TsmCerrarSesion.Size = new System.Drawing.Size(180, 22);
            this.TsmCerrarSesion.Text = "Cerrar Sesión";
            // 
            // TsmSalir
            // 
            this.TsmSalir.Name = "TsmSalir";
            this.TsmSalir.Size = new System.Drawing.Size(180, 22);
            this.TsmSalir.Text = "Salir";
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
            this.Text = "SAP-Sistema de Administración de Papelería";
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
    }
}