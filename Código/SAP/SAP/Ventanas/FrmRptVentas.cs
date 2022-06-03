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
    public partial class FrmRptVentas : Form
    {
        public FrmRptVentas()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
        }

        private void FrmRptVentas_Load(object sender, EventArgs e)
        {

        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            List<Venta> _datos = new List<Venta>();
            Dictionary<string, object> dataSources = new Dictionary<string, object>();
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            if (!Venta.ConsultarReporte(ref _datos, DtpDel.Value, DtpAl.Value))
            {
                MessageBox.Show("Error al consultar datos para el Reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_datos.Count == 0)
            {
                MessageBox.Show("No existen datos para el Reporte", "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataSources.Add("DtsVentas", _datos);

            parametros.Add("FechaDel", DtpDel.Value.ToString());
            parametros.Add("FechaAl", DtpAl.Value.ToString());

            new FrmVisorReporte("RptVentas", dataSources, parametros).ShowDialog();
        }
    }
}
