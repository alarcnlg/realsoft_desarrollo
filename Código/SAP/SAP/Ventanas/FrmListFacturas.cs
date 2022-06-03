using SAP.BaseDeDatos;
using SAP.Clases;
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
        List<Factura> _modelo;

        public FrmListFacturas()
        {
            InitializeComponent();

        }

        private void FrmListFacturas_Load(object sender, EventArgs e)
        {
            _inicializarInterfaz();

            _consultar();

        }

        private void _inicializarInterfaz() {

            DtgvListado.ReadOnly = true;
            DtgvListado.RowHeadersVisible = false;
            DtgvListado.MultiSelect = false;
            DtgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DtgvListado.AllowUserToResizeRows = false;
            DtgvListado.AllowUserToDeleteRows = false;
            DtgvListado.AllowUserToAddRows = false;
            DtgvListado.AutoGenerateColumns = false;

            DtgvListado.AgregarColumna("ID", "Folio", typeof(long), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            DtgvListado.AgregarColumna("No. Venta", "No. Venta", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            DtgvListado.AgregarColumna("Fecha", "Fecha", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
          
        }

        private void _consultar()
        {
            if (!Factura.ConsultarListado(ref _modelo, "Id", TxtBuscar.Text))
            {
                MessageBox.Show("Error al consultar Facturas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _llenaDatos();
        }

        private void _llenaDatos()
        {
            DtgvListado.Rows.Clear();

            for (int i = 0; i < _modelo.Count; i++)
            {
                DtgvListado.AgregarCelda(_modelo[i].Id);
                DtgvListado.AgregarCelda(_modelo[i].IdVenta);
                DtgvListado.AgregarCelda(_modelo[i].Fecha.ToString("dd/MM/yyyy"));
        
            }

        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            FrmListVentas frmListVentas = new FrmListVentas(true);
            if (frmListVentas.ShowDialog() != DialogResult.OK) return;

            new FrmFacturacion(frmListVentas.ConseguirVentaSeleccionada().Id).ShowDialog();
             _consultar();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DtgvListado.SelectedRows.Count != 1) return;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.AddExtension = true;
            saveFile.FileName = "Factura.xml";
            saveFile.Filter = "Archivos XML | *.xml";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                byte[] datos = null;
                Factura.ConsultarXML(_modelo[DtgvListado.SelectedRows[0].Index].Id, ref datos);
                System.IO.File.WriteAllBytes(saveFile.FileName, datos);
                MessageBox.Show("Archivo XML guardado Correctamente", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void TxtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                _consultar();
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            _consultar();
        }

        private void BtnGuardarPDF_Click(object sender, EventArgs e)
        {
            if (DtgvListado.SelectedRows.Count != 1) return;
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.AddExtension = true;
            saveFile.FileName = "Factura.pdf";
            saveFile.Filter = "Archivos PDF | *.pdf";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                byte[] datos = null;
                Factura.ConsultarPDF(_modelo[DtgvListado.SelectedRows[0].Index].Id, ref datos);
                System.IO.File.WriteAllBytes(saveFile.FileName, datos);
                MessageBox.Show("Archivo PDF guardado Correctamente", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
