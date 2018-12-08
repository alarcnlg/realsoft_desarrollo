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

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            if (!Venta.Consultar(ref _venta)) return;

            Text = "Facturando....";

            CFDI cfdi = new CFDI();

            int res = cfdi.GenerarYTimbrar(ref _factura, _venta);

            if (res == CFDI.RESULT_ERROR_GENERAL)
            {
                MessageBox.Show("Error al crear la Factura","Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Text = "Facturación";
                return;
            }
            else if (res == CFDI.RESULT_ERROR_TIMBRADO)
            {
                MessageBox.Show("Error al timbrar la Factura", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Text = "Facturación";
                return;
            }
            MessageBox.Show("Factura Realizada Correctamente", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (!Factura.Guardar(ref _factura))
            {
                MessageBox.Show("Error al guardar la Factura", "Facturar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Text = "Facturación";
                return;
            }
            MessageBox.Show("Factura Guardada Correctamente", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Text = "Facturación";
            BtnGenerar.Visible = false;
            BtnGuardarXML.Visible = true;
            BtnGuardarPDF.Visible = true;
        }

        private void BtnGuardarXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.FileName = "Factura_A" + _factura.Id + ".xml";
            fileDialog.Filter = "Archivos XML | *.xml";
            fileDialog.AddExtension = true;
           
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllBytes(fileDialog.FileName, _factura.ArchivoXML);
                    MessageBox.Show("Archivo XML guardado Correctamente", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Error al Guardar archivo XML", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void BtnGuardarPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.FileName = "Factura_A" + _factura.Id + ".pdf";
            fileDialog.Filter = "Archivos PDF | *.pdf";
            fileDialog.AddExtension = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllBytes(fileDialog.FileName, _factura.ArchivoPDF);
                    MessageBox.Show("Archivo PDF guardado Correctamente", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Error al Guardar archivo PDF", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
