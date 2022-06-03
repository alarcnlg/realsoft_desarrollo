using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SAP.Ventanas
{
    public partial class FrmVisorReporte : Form
    {
        private string _nombre;
        private Dictionary<string, object> _dataSources;
        private Dictionary<string, object> _parametros;

        public FrmVisorReporte(string nombre, Dictionary<string, object> dataSources, Dictionary<string, object> parametros = null)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            _nombre = nombre;
            _dataSources = dataSources;

            if (parametros == null) {
                parametros = new Dictionary<string, object>();
            }
            _parametros = parametros;
        }

        private void FrmVisorReporte_Load(object sender, EventArgs e)
        {
            RptViewer.SetDisplayMode(DisplayMode.PrintLayout);
            RptViewer.ZoomMode = ZoomMode.Percent;
            RptViewer.ZoomPercent = 100;
            try
            {
                RptViewer.ProcessingMode = ProcessingMode.Local;

                RptViewer.LocalReport.ReportEmbeddedResource = $"SAP.Reportes.{_nombre}.rdlc";

                foreach (var key in _dataSources.Keys)
                {
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource(key, _dataSources[key]));
                }

                if (_parametros.Count > 0) {
                    List<ReportParameter> parametros = new List<ReportParameter>();

                    foreach (var key in _parametros.Keys)
                    {
                        parametros.Add(new ReportParameter(key, _parametros[key].ToString()));
                    }
                    RptViewer.LocalReport.SetParameters(parametros);
                }

                RptViewer.RefreshReport();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + " Error al crear Reporte","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
