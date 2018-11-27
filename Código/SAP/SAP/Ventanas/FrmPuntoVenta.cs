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
    public partial class FrmPuntoVenta : Form
    {
        private List<Producto> _modeloBusqueda;
        private long _idProductoActivo;
        private bool _cambioTexto;

        private float _totalVenta;
        private float TotalVenta {
            get
            {
                return _totalVenta;
            }
            set
            {
                _totalVenta = value;
                LblTotal.Text = _totalVenta.ToString("###,##0.00");
            }
        }

        private int _cantidadProductos;
        private int CantidadProductos
        {
            get
            {
                return _cantidadProductos;
            }
            set
            {
                _cantidadProductos = value;
                LblCantidadProductos.Text = _cantidadProductos.ToString("###,###,##0");
            }
        }

        public FrmPuntoVenta()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            _modeloBusqueda = new List<Producto>();
        }

        private void FrmPuntoVenta_Load(object sender, EventArgs e)
        {
            _inicializarInterfaz();
        }

        private void _inicializarInterfaz()
        {
            /*
            * Tabla de Productos
            */
            DtgvProductos.ReadOnly = true;
            DtgvProductos.RowHeadersVisible = false;
            DtgvProductos.MultiSelect = false;
            DtgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DtgvProductos.AllowUserToResizeRows = false;
            DtgvProductos.AllowUserToDeleteRows = false;
            DtgvProductos.AllowUserToAddRows = false;
            DtgvProductos.AutoGenerateColumns = false;

            DtgvProductos.AgregarColumna("ID", "ID", typeof(long), visible: false);
            DtgvProductos.AgregarColumna("CODIGOBARRAS", "Código de Barras", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            DtgvProductos.AgregarColumna("NOMBRE", "Nombre", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            DtgvProductos.AgregarColumna("PRECIO", "Precio", typeof(float), alignment: DataGridViewContentAlignment.MiddleRight, autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill, formato: "N2");
            DtgvProductos.AgregarColumna("CANTIDAD", "Cantidad", typeof(int), alignment: DataGridViewContentAlignment.MiddleRight, autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill, formato: "N2");
            DtgvProductos.AgregarColumna("TOTAL", "Total", typeof(float), alignment: DataGridViewContentAlignment.MiddleRight, autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill, formato: "N2");

            /*
             * Tabla de Busqueda
             */
            DtgvListadoBusqueda.ReadOnly = true;
            DtgvListadoBusqueda.RowHeadersVisible = false;
            DtgvListadoBusqueda.MultiSelect = false;
            DtgvListadoBusqueda.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DtgvListadoBusqueda.AllowUserToResizeRows = false;
            DtgvListadoBusqueda.AllowUserToDeleteRows = false;
            DtgvListadoBusqueda.AllowUserToAddRows = false;
            DtgvListadoBusqueda.AutoGenerateColumns = false;

            DtgvListadoBusqueda.AgregarColumna("ID", "ID", typeof(long), visible: false);
            DtgvListadoBusqueda.AgregarColumna("CODIGOBARRAS", "Código de Barras", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            DtgvListadoBusqueda.AgregarColumna("NOMBRE", "Nombre", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            DtgvListadoBusqueda.AgregarColumna("PRECIO", "Precio", typeof(float), alignment: DataGridViewContentAlignment.MiddleRight, autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill, formato: "N2");
            DtgvListadoBusqueda.AgregarColumna("CANTIDAD", "Inventario", typeof(int), alignment: DataGridViewContentAlignment.MiddleRight, autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
        }

        private void _consultarBusqueda() {
            string campo = "";
            string dato = "";
            if (TxtCodigoBarras.Focused)
            {
                campo = "CODIGOBARRAS";
                dato = TxtCodigoBarras.Text;
            }
            else
            {
                campo = "NOMBRE";
                dato = TxtNombre.Text;
            }

            if (!Producto.ConsultarListado(ref _modeloBusqueda, campo, dato))
            {
                return;
            }

            DtgvListadoBusqueda.Rows.Clear();

            for (int i = 0; i < _modeloBusqueda.Count; i++)
            {
                DtgvListadoBusqueda.AgregarCelda(_modeloBusqueda[i].Id);
                DtgvListadoBusqueda.AgregarCelda(_modeloBusqueda[i].CodigoBarras);
                DtgvListadoBusqueda.AgregarCelda(_modeloBusqueda[i].Nombre);
                DtgvListadoBusqueda.AgregarCelda(_modeloBusqueda[i].Precio);
                DtgvListadoBusqueda.AgregarCelda(_modeloBusqueda[i].Cantidad);
            }

        }

        private void _agregarProducto() {
            if (_idProductoActivo == 0) return;
            float precio = 0;
            int cantidad = 0;

            int.TryParse(TxtCantidad.Text, out cantidad);
            float.TryParse(TxtPrecio.Text, out precio);

            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0","Agregar Producto",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            if (!Producto.ValidarExistencia(_idProductoActivo, cantidad)) {
                MessageBox.Show("No hay cantidad suficiente en el inventario", "Agregar Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            DtgvProductos.AgregarCelda(_idProductoActivo);
            DtgvProductos.AgregarCelda(TxtCodigoBarras.Text);
            DtgvProductos.AgregarCelda(TxtNombre.Text);
            DtgvProductos.AgregarCelda(precio);
            DtgvProductos.AgregarCelda(cantidad);
            DtgvProductos.AgregarCelda(precio * cantidad);

            CantidadProductos += 1;
 
            TotalVenta += precio * cantidad;

            LimpiarProductoActual();
        }

        private void LimpiarProductoActual() {
            _idProductoActivo = 0;
            TxtCodigoBarras.Text = "";
            TxtNombre.Text = "";
            TxtPrecio.Text = "";
            TxtCantidad.Text = "";

            TxtCodigoBarras.Focus();
        }

        private void LlenarDatosBusqueda() {
            DataGridViewRow row = DtgvListadoBusqueda.SelectedRows[0];
            _idProductoActivo = Convert.ToInt64(row.Cells[0].Value);
            TxtCodigoBarras.Text =row.Cells[1].Value.ToString();
            TxtNombre.Text = row.Cells[2].Value.ToString();
            TxtPrecio.Text = row.Cells[3].Value.ToString();
            TxtCantidad.Text = "1";

            TxtCantidad.Focus();
            PnlBusqueda.Visible = false;
        }

        private void FinalizarVenta()
        {
            if(DtgvProductos.Rows.Count == 0)
            {
                MessageBox.Show("La Venta está vacía", "No Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            FrmTotal frm = new FrmTotal(TotalVenta);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Venta pVenta = new Venta();
                pVenta.Fecha = DateTime.Now;
                pVenta.Total = TotalVenta;

                pVenta.Detalles = new List<VentaDetalle>();
                VentaDetalle ventaDetalle = null;
                
                for (int i = 0; i < DtgvProductos.RowCount; i++)
                {
                    ventaDetalle = new VentaDetalle();
                    ventaDetalle.IdProducto = Convert.ToInt32(DtgvProductos.Rows[i].Cells["ID"].Value);
                    ventaDetalle.Cantidad = Convert.ToInt32(DtgvProductos.Rows[i].Cells["CANTIDAD"].Value);
                    ventaDetalle.PrecioUnidad = float.Parse(DtgvProductos.Rows[i].Cells["PRECIO"].Value.ToString());
                    ventaDetalle.Total = ventaDetalle.Cantidad * ventaDetalle.PrecioUnidad;

                    pVenta.Detalles.Add(ventaDetalle);
                }

                if (Venta.Guardar(ref pVenta))
                {
                    MessageBox.Show("Venta Realizada Con Exito!!", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {
                    MessageBox.Show("No se pudo Guardar la Venta", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void LimpiarVenta()
        {
            TotalVenta = 0;
            CantidadProductos = 0;
            DtgvProductos.Rows.Clear();
            LimpiarProductoActual();
          
        }

        private void EliminarProducto()
        {

        }

        private void EditarProducto()
        {

        }

        private void TxtCodigoBarras_TextChanged(object sender, EventArgs e)
        {
            _cambioTexto = true;
        }

        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            _cambioTexto = true;
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) _agregarProducto();
        }

        private void TxtCodigoBarras_KeyUp(object sender, KeyEventArgs e)
        {
            EjecutarTeclasTexbox(sender, e);
        }

        private void TxtNombre_KeyUp(object sender, KeyEventArgs e)
        {
            EjecutarTeclasTexbox(sender, e);
        }

        private void FrmPuntoVenta_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                FinalizarVenta();
            }
            else if (e.KeyCode == Keys.F4)
            {
                LimpiarVenta();
            }
            else if (e.KeyCode == Keys.F5 && !PnlBusqueda.Visible)
            {
                EditarProducto();
            }
            else if (e.KeyCode == Keys.Delete && !PnlBusqueda.Visible)
            {
                EliminarProducto();
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            _agregarProducto();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarProductoActual();
        }

        private void BtnFinCompra_Click(object sender, EventArgs e)
        {
            FinalizarVenta();
        }

        private void BtnLimpCom_Click(object sender, EventArgs e)
        {
            LimpiarVenta();
        }

        private void BtnElimProducto_Click(object sender, EventArgs e)
        {
            EliminarProducto();
        }

        private void BtnEditProducto_Click(object sender, EventArgs e)
        {
            EditarProducto();
        }

        private void EjecutarTeclasTexbox(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape)
            {
                if (PnlBusqueda.Visible)
                {
                    LimpiarProductoActual();
                    PnlBusqueda.Visible = false;
                }
                return;
            }

            DataGridView dataGridViewSeleccionado = null;
            int index = 0;

            if (PnlBusqueda.Visible)
            {
                dataGridViewSeleccionado = DtgvListadoBusqueda;
            }
            else
            {
                dataGridViewSeleccionado = DtgvProductos;
            }

            if (dataGridViewSeleccionado.SelectedRows.Count == 1)
            {

                if (e.KeyCode == Keys.Enter)
                {
                    if (PnlBusqueda.Visible)
                    {
                        LlenarDatosBusqueda();
                    }
                    else
                    {
                        EditarProducto();
                    }
                    return;
                }

                index = dataGridViewSeleccionado.SelectedRows[0].Index;

                if (e.KeyCode == Keys.Up)
                {
                    index--;
                    if (index < 0)
                    {
                        index = dataGridViewSeleccionado.Rows.Count - 1;
                    }
                }
                else if (e.KeyCode == Keys.Down)
                {
                    index++;
                    if (index == dataGridViewSeleccionado.Rows.Count)
                    {
                        index = 0;
                    }
                }

                dataGridViewSeleccionado.CurrentCell = dataGridViewSeleccionado.Rows[index].Cells[1];


            }

            if (_cambioTexto == true)
            {
                TextBox txt = sender as TextBox;
                if (txt.Text.Length <= 0)
                {
                    PnlBusqueda.Visible = false;
                }
                else
                {
                    PnlBusqueda.Visible = true;
                    _consultarBusqueda();
                }
                _cambioTexto = false;
            }

        }

    }
}
