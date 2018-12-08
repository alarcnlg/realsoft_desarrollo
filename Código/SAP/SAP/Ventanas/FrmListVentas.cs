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
    public partial class FrmListVentas : Form
    {
        private List<Venta> _modelo;
        private bool _modoSeleccion;

        public FrmListVentas(bool modoSeleccion = false)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;

            _modelo = new List<Venta>();
            _modoSeleccion = modoSeleccion;
        }

        private void FrmListVentas_Load(object sender, EventArgs e)
        {
            _inicializarInterfaz();
            _consultar();
        }

        private void _consultar()
        {
            if (!Venta.ConsultarListado(ref _modelo, "id", TxtBuscar.Text, _modoSeleccion))
            {
                MessageBox.Show("Error al consultar ventas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _llenaDatos();

        }

        private void _inicializarInterfaz()
        {
            if (_modoSeleccion)
            {
                Text = "Seleccione Venta a Facturar";
                BtnAceptar.Text = "Aceptar";
            }

            DtgvListado.ReadOnly = true;
            DtgvListado.RowHeadersVisible = false;
            DtgvListado.MultiSelect = false;
            DtgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DtgvListado.AllowUserToResizeRows = false;
            DtgvListado.AllowUserToDeleteRows = false;
            DtgvListado.AllowUserToAddRows = false;
            DtgvListado.AutoGenerateColumns = false;

            DtgvListado.AgregarColumna("ID", "Número de Venta", typeof(long), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            DtgvListado.AgregarColumna("Fecha", "Fecha", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            DtgvListado.AgregarColumna("Total", "Total", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            DtgvListado.AgregarColumna("FechaCancelacion ", "Fecha de cancelación", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            DtgvListado.AgregarColumna("Estado ", "Estado", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);

        }

        private void _llenaDatos()
        {
            DtgvListado.Rows.Clear();

            for (int i = 0; i < _modelo.Count; i++)
            {
                DtgvListado.AgregarCelda(_modelo[i].Id);
                DtgvListado.AgregarCelda(_modelo[i].Fecha.ToString("dd/MM/yyyy"));
                DtgvListado.AgregarCelda(_modelo[i].Total);
                DtgvListado.AgregarCelda(_modelo[i].FechaCancelacion.ToString("dd/MM/yyyy"));
                DtgvListado.AgregarCelda(_modelo[i].Estado == 'A' ? "Activo" : "Cancelado");
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (DtgvListado.SelectedRows.Count != 1) return;
            if (!_modoSeleccion)
            {
                if (DtgvListado.SelectedRows[0].Cells[4].Value.ToString() == "Cancelado") return;
                if (MessageBox.Show("¿Está seguro de Cancelar esta Venta?", "Cancelar", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    if (!Venta.Cancelar(_modelo[DtgvListado.SelectedRows[0].Index].Id))
                    {
                        MessageBox.Show("Error al Cancelar Venta", "Cancelar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Venta Cancelada correctamente", "cancelar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _consultar();
                }
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            _consultar();
        }

        private void TxtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                _consultar();
            }
        }

        public Venta ConseguirVentaSeleccionada()
        {
            return _modelo[DtgvListado.SelectedRows[0].Index];
        }
    }
}


