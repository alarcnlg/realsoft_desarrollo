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
        public bool CerraAplicacion {get; set;}

        public FrmMDI()
        {
            InitializeComponent();
            CerraAplicacion = true;
        }

        private void FrmMDI_Load(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem) MnuMain.Items.Find("TsmUsuario", false)[0];
            item.Text = ModuloGeneral.UsuarioActivo.NombreUsuario;
        }

        private void FrmMDI_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CerraAplicacion) {
                Application.Exit();
            }
        }

        private void TsmUsuarios_Click(object sender, EventArgs e)
        {
            this.CargarFormulario(new FrmListUsuarios());
        }

        private void TsmBaseDeDatos_Click(object sender, EventArgs e)
        {
            this.CargarFormulario(new FrmConfiguracionBaseDeDatos());
        }

        private void TsmCatalogoProductos_Click(object sender, EventArgs e)
        {
            this.CargarFormulario(new FrmListProductos());
        }

        private void TsmCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar Sesión?", "Cerrar sesión", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                ModuloGeneral.FrmLogin.Visible = true;
                CerraAplicacion = false;
                Close();
            }
        }

    }
}
