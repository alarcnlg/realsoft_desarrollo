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

        public FrmVisorReporte(string nombre, Dictionary<string, object> dataSources)
        {
            InitializeComponent();

            _nombre = nombre;
            _dataSources = dataSources;
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

                for (int i = 0; i < _dataSources.Count; i++)
                {
                    RptViewer.LocalReport.DataSources.Add(new ReportDataSource(_dataSources["CLAVE"].ToString(), _dataSources["DATOS"]));
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
