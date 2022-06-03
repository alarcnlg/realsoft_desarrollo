﻿using SAP.BaseDeDatos;
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

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            List<Factura> _datos = new List<Factura>();
            Dictionary<string, object> dataSources = new Dictionary<string, object>();
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            if (!Factura.ConsultarReporte(ref _datos, DtpDel.Value, DtpAl.Value)) {
                MessageBox.Show("Error al consultar datos para el Reporte","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (_datos.Count == 0)
            {
                MessageBox.Show("No existen datos para el Reporte", "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataSources.Add("DtsFacturas", _datos);

            parametros.Add("FechaDel", DtpDel.Value.ToString());
            parametros.Add("FechaAl", DtpAl.Value.ToString());

            new FrmVisorReporte("RptFacturas", dataSources, parametros).ShowDialog();
        }

    }
}
