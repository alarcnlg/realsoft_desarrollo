using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAP.BaseDeDatos;
using SAP.Clases;

namespace SAP.Ventanas
{
    public partial class FrmListCompras : Form
    {
        private List<Compra> _modelo;

        public FrmListCompras()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;

            _modelo = new List<Compra>();
        }

        private void FrmListCompras_Load(object sender, EventArgs e)
        {
           
            _inicializarInterfaz();

            _consultar();


        }
        private void _consultar()
        {
            if (!Compra.ConsultarListado(ref _modelo, "folio", TxtBuscar.Text))
            {
                MessageBox.Show("Error al consultar compras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _llenaDatos();

        }

        private void _inicializarInterfaz()
        {
            DtgvListado.ReadOnly = true;
            DtgvListado.RowHeadersVisible = false;
            DtgvListado.MultiSelect = false;
            DtgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DtgvListado.AllowUserToResizeRows = false;
            DtgvListado.AllowUserToDeleteRows = false;
            DtgvListado.AllowUserToAddRows = false;
            DtgvListado.AutoGenerateColumns = false;

            DtgvListado.AgregarColumna("ID", "ID", typeof(long), visible: false);
            DtgvListado.AgregarColumna("Folio", "Folio", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            DtgvListado.AgregarColumna("Fecha", "Fecha", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            DtgvListado.AgregarColumna("Total", "Total", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            DtgvListado.AgregarColumna("Fecha de cancelación ", "Fecha de cancelación", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            DtgvListado.AgregarColumna("Estado ", "Estado", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);

        }
        private void _llenaDatos()
        {
            DtgvListado.Rows.Clear();

            for (int i = 0; i < _modelo.Count; i++)
            {
                DtgvListado.AgregarCelda(_modelo[i].Id);
                DtgvListado.AgregarCelda(_modelo[i].Folio);
                DtgvListado.AgregarCelda(_modelo[i].Fecha.ToString("dd/MM/yyyy"));
                DtgvListado.AgregarCelda(_modelo[i].Total);
                DtgvListado.AgregarCelda(_modelo[i].FechaCancelacion.ToString("dd/MM/yyyy"));
                DtgvListado.AgregarCelda(_modelo[i].Estado == 'A' ? "Activo" : "Cancelado");
            }

        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if (DtgvListado.SelectedRows.Count != 1) return;
            if (DtgvListado.SelectedRows[0].Cells[5].Value.ToString() == "Cancelado") return;
            if (MessageBox.Show("¿Está seguro de Cancelar esta Compra?", "Cancelar", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                if (!Compra.Cancelar(_modelo[DtgvListado.SelectedRows[0].Index].Id))
                {
                    MessageBox.Show("Error al Cancelar Compra", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Compra Cancelada correctamente", "cancelar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _consultar();
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

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmCompraProductos frm = new FrmCompraProductos();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _consultar();
            }
        }
    }
}
