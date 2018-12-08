using SAP.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Ventanas
{
    public partial class FrmListFacturas : Form
    {
        public FrmListFacturas()
        {
            InitializeComponent();

        }

        private void FrmListFacturas_Load(object sender, EventArgs e)
        {
           
        }

        private void _inicializarIntefaz() {

        }

        private void _consultar()
        {
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            FrmListVentas frmListVentas = new FrmListVentas(true);
            if (frmListVentas.ShowDialog() != DialogResult.OK) return;

            if (new FrmFacturacion(frmListVentas.ConseguirVentaSeleccionada().Id).ShowDialog() == DialogResult.OK) {
                _consultar();
            }
        }
    }
}
