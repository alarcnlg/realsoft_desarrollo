namespace SAP.Ventanas
{
    partial class FrmRptFacturas
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpDel = new System.Windows.Forms.DateTimePicker();
            this.BtnGenerar = new System.Windows.Forms.Button();
            this.DtpAl = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Del:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Al:";
            // 
            // DtpDel
            // 
            this.DtpDel.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpDel.Location = new System.Drawing.Point(50, 12);
            this.DtpDel.Name = "DtpDel";
            this.DtpDel.Size = new System.Drawing.Size(81, 20);
            this.DtpDel.TabIndex = 1;
            // 
            // BtnGenerar
            // 
            this.BtnGenerar.Location = new System.Drawing.Point(178, 48);
            this.BtnGenerar.Name = "BtnGenerar";
            this.BtnGenerar.Size = new System.Drawing.Size(75, 23);
            this.BtnGenerar.TabIndex = 2;
            this.BtnGenerar.Text = "Generar";
            this.BtnGenerar.UseVisualStyleBackColor = true;
            this.BtnGenerar.Click += new System.EventHandler(this.BtnGenerar_Click);
            // 
            // DtpAl
            // 
            this.DtpAl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpAl.Location = new System.Drawing.Point(172, 12);
            this.DtpAl.Name = "DtpAl";
            this.DtpAl.Size = new System.Drawing.Size(81, 20);
            this.DtpAl.TabIndex = 1;
            // 
            // FrmRptFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 85);
            this.Controls.Add(this.DtpAl);
            this.Controls.Add(this.BtnGenerar);
            this.Controls.Add(this.DtpDel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRptFacturas";
            this.ShowIcon = false;
            this.Text = "Reporte de Facturas";
            this.Load += new System.EventHandler(this.FrmRptFacturas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpDel;
        private System.Windows.Forms.Button BtnGenerar;
        private System.Windows.Forms.DateTimePicker DtpAl;
    }
}