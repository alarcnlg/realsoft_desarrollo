namespace SAP.Ventanas
{
    partial class FrmRptVentas
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
            this.DtpAl = new System.Windows.Forms.DateTimePicker();
            this.BtnGenerar = new System.Windows.Forms.Button();
            this.DtpDel = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DtpAl
            // 
            this.DtpAl.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpAl.Location = new System.Drawing.Point(170, 12);
            this.DtpAl.Name = "DtpAl";
            this.DtpAl.Size = new System.Drawing.Size(81, 20);
            this.DtpAl.TabIndex = 4;
            // 
            // BtnGenerar
            // 
            this.BtnGenerar.Location = new System.Drawing.Point(176, 48);
            this.BtnGenerar.Name = "BtnGenerar";
            this.BtnGenerar.Size = new System.Drawing.Size(75, 23);
            this.BtnGenerar.TabIndex = 7;
            this.BtnGenerar.Text = "Generar";
            this.BtnGenerar.UseVisualStyleBackColor = true;
            this.BtnGenerar.Click += new System.EventHandler(this.BtnGenerar_Click);
            // 
            // DtpDel
            // 
            this.DtpDel.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpDel.Location = new System.Drawing.Point(48, 12);
            this.DtpDel.Name = "DtpDel";
            this.DtpDel.Size = new System.Drawing.Size(81, 20);
            this.DtpDel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Al:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Del:";
            // 
            // FrmRptVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 89);
            this.Controls.Add(this.DtpAl);
            this.Controls.Add(this.BtnGenerar);
            this.Controls.Add(this.DtpDel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmRptVentas";
            this.Text = "FrmRptVentas";
            this.Load += new System.EventHandler(this.FrmRptVentas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DtpAl;
        private System.Windows.Forms.Button BtnGenerar;
        private System.Windows.Forms.DateTimePicker DtpDel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}