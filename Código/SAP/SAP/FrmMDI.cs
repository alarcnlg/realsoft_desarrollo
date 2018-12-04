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
            ToolStripMenuItem item = (ToolStripMenuItem)MnuMain.Items.Find("TsmUsuario", false)[0];
            item.Text = ModuloGeneral.UsuarioActivo.NombreUsuario;

            if (ModuloGeneral.UsuarioActivo.Tipo == 'C')
            {
                for (int i = 1; i < MnuMain.Items.Count - 1; i++)
                {
                    MnuMain.Items[i].Visible = false;
                }
                new FrmPuntoVenta().ShowDialog();
            }
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

        private void TsmProductos_Click(object sender, EventArgs e)
        {
            this.CargarFormulario(new FrmListProductos());
        }

        private void TsmCompras_Click(object sender, EventArgs e)
        {
            this.CargarFormulario(new FrmListCompras());
        }

        private void TsmPuntoVenta_Click(object sender, EventArgs e)
        {
            new FrmPuntoVenta().ShowDialog();
        }

        private void TsmVentas_Click(object sender, EventArgs e)
        {
            this.CargarFormulario(new FrmListVentas());
        }

        private void TsmRptFacturas_Click(object sender, EventArgs e)
        {
            this.CargarFormulario(new FrmRptFacturas());
        }

        private void TsmRptCompras_Click(object sender, EventArgs e)
        {
            this.CargarFormulario(new FrmRptCompras());
        }

        private void TsmRptProductos_Click(object sender, EventArgs e)
        {
            this.CargarFormulario(new FrmRptProductos());
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

        private void TsmSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de Salir?", "Salir", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                Close();
            }
        }

    }
}
