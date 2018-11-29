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
    public partial class FrmRptFacturas : Form
    {
        public FrmRptFacturas()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        private void FrmRptFacturas_Load(object sender, EventArgs e)
        {

        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            List<Factura> _datos = new List<Factura>();
            Dictionary<string, object> dataSources = new Dictionary<string, object>();

            if (!Factura.ConsultarReporte(ref _datos, DtpDel.Value, DtpAl.Value)) {
                MessageBox.Show("Error al consultar datos para el Reporte","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            dataSources.Add("CLAVE", "DtsFacturas");
            dataSources.Add("DATOS", _datos);

            new FrmVisorReporte("RptFacturas", dataSources).ShowDialog();
        }
    }
}
