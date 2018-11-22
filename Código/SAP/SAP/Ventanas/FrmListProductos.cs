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
    public partial class FrmListProductos : Form
    {
        private List<Producto> _modelo;
        private bool _modoSeleccion;


        public FrmListProductos(bool modoSeleccion = false)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;

            _modelo = new List<Producto>();
            _modoSeleccion = modoSeleccion;
        }

        private void FrmListProductos_Load(object sender, EventArgs e)
        {
            CmbCampos.AgregarItem("Código de Barras", "CodigoBarras");
            CmbCampos.AgregarItem("Nombre", "Nombre");
            CmbCampos.AgregarItem("Marca", "Marca");

            _inicializarInterfaz();

            _consultar();
        }

        private void _consultar()
        {
            if (!Producto.ConsultarListado(ref _modelo, CmbCampos.SelectedValue.ToString(), TxtBuscar.Text))
            {
                MessageBox.Show("Error al consultar Productos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _llenaDatos();

        }

        private void _inicializarInterfaz()
        {
            if (_modoSeleccion)
            {
                Text = "Seleccione Producto";
                BtnAceptar.Text = "Aceptar";

                BtnNuevo.Visible = false;
                BtnEliminar.Visible = false;
            }

            DtgvListado.ReadOnly = true;
            DtgvListado.RowHeadersVisible = false;
            DtgvListado.MultiSelect = false;
            DtgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DtgvListado.AllowUserToResizeRows = false;
            DtgvListado.AllowUserToDeleteRows = false;
            DtgvListado.AllowUserToAddRows = false;
            DtgvListado.AutoGenerateColumns = false;

            DtgvListado.AgregarColumna("ID", "ID", typeof(long), visible: false);
            DtgvListado.AgregarColumna("CODIGOBARRAS", "Código de Barras", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            DtgvListado.AgregarColumna("NOMBRE", "Nombre", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            DtgvListado.AgregarColumna("MARCA", "Marca", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            DtgvListado.AgregarColumna("DESCRIPCION", "Descripcion", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            DtgvListado.AgregarColumna("PRECIO", "Precio", typeof(float), alignment : DataGridViewContentAlignment.MiddleRight, autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill, formato : "N2");
            DtgvListado.AgregarColumna("CANTIDAD", "Cantidad", typeof(int), alignment: DataGridViewContentAlignment.MiddleRight, autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
        }

        private void _llenaDatos()
        {
            DtgvListado.Rows.Clear();

            for (int i = 0; i < _modelo.Count; i++)
            {
                DtgvListado.AgregarCelda(_modelo[i].Id);
                DtgvListado.AgregarCelda(_modelo[i].CodigoBarras);
                DtgvListado.AgregarCelda(_modelo[i].Nombre);
                DtgvListado.AgregarCelda(_modelo[i].Marca);
                DtgvListado.AgregarCelda(_modelo[i].Descripcion);
                DtgvListado.AgregarCelda(_modelo[i].Precio);
                DtgvListado.AgregarCelda(_modelo[i].Cantidad);
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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (DtgvListado.SelectedRows.Count != 1) return;
            if (MessageBox.Show("¿Está seguro de Eliminar este Producto?", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                if (!Producto.Eliminar(_modelo[DtgvListado.SelectedRows[0].Index].Id))
                {
                    MessageBox.Show("Error al eliminar Producto", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Producto eliminado correctamente", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _consultar();
            }

        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (DtgvListado.SelectedRows.Count != 1) return;
            if (!_modoSeleccion)
            {
                FrmProducto frm = new FrmProducto(_modelo[DtgvListado.SelectedRows[0].Index].Id);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _consultar();
                }
            }
            else {
                DialogResult = DialogResult.OK;
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmProducto frm = new FrmProducto();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _consultar();
            }
        }

        public Producto ConseguirUsuarioSeleccionado() {
            return _modelo[DtgvListado.SelectedRows[0].Index];
        }

    }
}
