namespace SAP.Ventanas
{
    partial class FrmFacturacion
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
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNoVenta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.BtnGenerar = new System.Windows.Forms.Button();
            this.BtnGuardarXML = new System.Windows.Forms.Button();
            this.BtnGuardarPDF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "No Venta:";
            // 
            // TxtNoVenta
            // 
            this.TxtNoVenta.Enabled = false;
            this.TxtNoVenta.Location = new System.Drawing.Point(73, 15);
            this.TxtNoVenta.Name = "TxtNoVenta";
            this.TxtNoVenta.Size = new System.Drawing.Size(100, 20);
            this.TxtNoVenta.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fecha:";
            // 
            // DtpFecha
            // 
            this.DtpFecha.Enabled = false;
            this.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFecha.Location = new System.Drawing.Point(236, 15);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(95, 20);
            this.DtpFecha.TabIndex = 5;
            // 
            // BtnGenerar
            // 
            this.BtnGenerar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.BtnGenerar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerar.Location = new System.Drawing.Point(256, 50);
            this.BtnGenerar.Name = "BtnGenerar";
            this.BtnGenerar.Size = new System.Drawing.Size(75, 23);
            this.BtnGenerar.TabIndex = 7;
            this.BtnGenerar.Text = "Generar";
            this.BtnGenerar.UseVisualStyleBackColor = true;
            this.BtnGenerar.Click += new System.EventHandler(this.BtnGenerar_Click);
            // 
            // BtnGuardarXML
            // 
            this.BtnGuardarXML.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.BtnGuardarXML.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnGuardarXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardarXML.Location = new System.Drawing.Point(246, 50);
            this.BtnGuardarXML.Name = "BtnGuardarXML";
            this.BtnGuardarXML.Size = new System.Drawing.Size(85, 23);
            this.BtnGuardarXML.TabIndex = 8;
            this.BtnGuardarXML.Text = "Guardar XML";
            this.BtnGuardarXML.UseVisualStyleBackColor = true;
            this.BtnGuardarXML.Visible = false;
            this.BtnGuardarXML.Click += new System.EventHandler(this.BtnGuardarXML_Click);
            // 
            // BtnGuardarPDF
            // 
            this.BtnGuardarPDF.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.BtnGuardarPDF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.BtnGuardarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardarPDF.Location = new System.Drawing.Point(154, 50);
            this.BtnGuardarPDF.Name = "BtnGuardarPDF";
            this.BtnGuardarPDF.Size = new System.Drawing.Size(86, 23);
            this.BtnGuardarPDF.TabIndex = 9;
            this.BtnGuardarPDF.Text = "Guardar PDF";
            this.BtnGuardarPDF.UseVisualStyleBackColor = true;
            this.BtnGuardarPDF.Visible = false;
            this.BtnGuardarPDF.Click += new System.EventHandler(this.BtnGuardarPDF_Click);
            // 
            // FrmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(342, 89);
            this.Controls.Add(this.BtnGuardarPDF);
            this.Controls.Add(this.BtnGuardarXML);
            this.Controls.Add(this.BtnGenerar);
            this.Controls.Add(this.DtpFecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtNoVenta);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFacturacion";
            this.Text = "Facturación";
            this.Load += new System.EventHandler(this.FrmFacturacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtNoVenta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.Button BtnGenerar;
        private System.Windows.Forms.Button BtnGuardarXML;
        private System.Windows.Forms.Button BtnGuardarPDF;
    }
}