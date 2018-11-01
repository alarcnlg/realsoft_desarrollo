using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAP.Clases;
using SAP.Ventanas;

namespace SAP
{
    public partial class FrmMDI : Form
    {
        public FrmMDI()
        {
            InitializeComponent();
        }

        private void FrmMDI_Load(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem) MnuMain.Items.Find("TsmUsuario", false)[0];
            item.Text = ModuloGeneral.UsuarioActivo.NombreUsuario;
        }

        private void FrmMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TsmUsuarios_Click(object sender, EventArgs e)
        {
            this.CargarFormulario(new FrmListUsuarios());
        }
    }
}
