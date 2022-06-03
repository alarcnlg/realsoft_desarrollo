﻿namespace SAP.Ventanas
{
    partial class FrmListFacturas
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
            this.BtnGenerar = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.TxtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DtgvListado = new System.Windows.Forms.DataGridView();
            this.BtnGuardarPDF = new System.Windows.Forms.Button();
            this.BtnGuardarXML = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnGenerar
            // 
            this.BtnGenerar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.BtnGenerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerar.Location = new System.Drawing.Point(12, 342);
            this.BtnGenerar.Name = "BtnGenerar";
            this.BtnGenerar.Size = new System.Drawing.Size(75, 23);
            this.BtnGenerar.TabIndex = 32;
            this.BtnGenerar.Text = "Generar";
            this.BtnGenerar.UseVisualStyleBackColor = true;
            this.BtnGenerar.Click += new System.EventHandler(this.BtnGenerar_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBuscar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.BtnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscar.Location = new System.Drawing.Point(579, 20);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(75, 23);
            this.BtnBuscar.TabIndex = 31;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBuscar.Location = new System.Drawing.Point(79, 20);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(494, 20);
            this.TxtBuscar.TabIndex = 30;
            this.TxtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBuscar_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Buscar por:";
            // 
            // DtgvListado
            // 
            this.DtgvListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DtgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgvListado.Location = new System.Drawing.Point(12, 48);
            this.DtgvListado.Name = "DtgvListado";
            this.DtgvListado.Size = new System.Drawing.Size(642, 288);
            this.DtgvListado.TabIndex = 28;
            // 
            // BtnGuardarPDF
            // 
            this.BtnGuardarPDF.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.BtnGuardarPDF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnGuardarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardarPDF.Location = new System.Drawing.Point(545, 342);
            this.BtnGuardarPDF.Name = "BtnGuardarPDF";
            this.BtnGuardarPDF.Size = new System.Drawing.Size(109, 23);
            this.BtnGuardarPDF.TabIndex = 33;
            this.BtnGuardarPDF.Text = "Guardar PDF";
            this.BtnGuardarPDF.UseVisualStyleBackColor = true;
            this.BtnGuardarPDF.Click += new System.EventHandler(this.BtnGuardarPDF_Click);
            // 
            // BtnGuardarXML
            // 
            this.BtnGuardarXML.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.BtnGuardarXML.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnGuardarXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardarXML.Location = new System.Drawing.Point(430, 342);
            this.BtnGuardarXML.Name = "BtnGuardarXML";
            this.BtnGuardarXML.Size = new System.Drawing.Size(109, 23);
            this.BtnGuardarXML.TabIndex = 34;
            this.BtnGuardarXML.Text = "Guardar XML";
            this.BtnGuardarXML.UseVisualStyleBackColor = true;
            this.BtnGuardarXML.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmListFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(679, 389);
            this.Controls.Add(this.BtnGuardarXML);
            this.Controls.Add(this.BtnGuardarPDF);
            this.Controls.Add(this.BtnGenerar);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.TxtBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtgvListado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "FrmListFacturas";
            this.Text = "Listado de Facturas";
            this.Load += new System.EventHandler(this.FrmListFacturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgvListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnGenerar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TxtBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DtgvListado;
        private System.Windows.Forms.Button BtnGuardarPDF;
        private System.Windows.Forms.Button BtnGuardarXML;
    }
}