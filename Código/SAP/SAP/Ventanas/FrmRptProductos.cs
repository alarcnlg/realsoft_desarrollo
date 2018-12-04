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
    public partial class FrmRptProductos : Form
    {
        public FrmRptProductos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Producto> _datos = new List<Producto>();
            Dictionary<string, object> dataSources = new Dictionary<string, object>();
            Dictionary<string, object> parametros = new Dictionary<string, object>();

            if (!Producto.ConsultarReporte(ref _datos))
            {
                MessageBox.Show("Error al consultar datos para el Reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_datos.Count == 0)
            {
                MessageBox.Show("No existen datos para el Reporte", "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataSources.Add("DtsProductos", _datos);


            new FrmVisorReporte("RptProductos", dataSources, parametros).ShowDialog();
        }
    }
}
