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
using SAP.Facturacion;

namespace SAP.Ventanas
{
    public partial class FrmFacturacion : Form
    {
        Factura _factura;
        Venta _venta;

        public FrmFacturacion(long idVenta)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;

            _factura = new Factura();
            _venta = new Venta();

            _venta.Id = idVenta;
        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            _inicializarInterfaz();
            _consultar();
        }

        private void _inicializarInterfaz() {
            long id = 0;
            Factura.ConsultarSiguienteID(ref id);
            _factura.Id = id;

            TxtNoVenta.Text = _venta.Id.ToString();
        }

        private void _consultar() {
            if (!Venta.Consultar(ref _venta)) return;
        }

        private void _guardar()
        {
            if (!Venta.Consultar(ref _venta)) return;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            CFDI cfdi = new CFDI();

            int res = cfdi.GenerarYTimbrar(ref _factura, _venta);

            if (res == CFDI.RESULT_ERROR_GENERAL)
            {
                MessageBox.Show("Error al crear la Factura","Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (res == CFDI.RESULT_ERROR_TIMBRADO)
            {
                MessageBox.Show("Error al timbrar la Factura", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Factura Realizada Correctamente", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
