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
    public partial class FrmRptCompras : Form
    {
        public FrmRptCompras()
        {
            InitializeComponent();
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            List<Compra> _datos = new List<Compra>();
            Dictionary<string, object> dataSources = new Dictionary<string, object>();
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            if (!Compra.ConsultarReporte(ref _datos, DtpDel.Value, DtpAl.Value))
            {
                MessageBox.Show("Error al consultar datos para el Reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_datos.Count == 0)
            {
                MessageBox.Show("No existen datos para el Reporte", "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataSources.Add("DtsCompras", _datos);

            parametros.Add("FechaDel", DtpDel.Value.ToString());
            parametros.Add("FechaAl", DtpAl.Value.ToString());

            new FrmVisorReporte("RptCompras", dataSources, parametros).ShowDialog();
        }
    }
}
