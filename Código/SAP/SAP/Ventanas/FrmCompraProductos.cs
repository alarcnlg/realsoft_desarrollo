using SAP.BaseDeDatos;
using SAP.Clases;
using MySql.Data.MySqlClient;
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
    public partial class FrmCompraProductos : Form
    {
        /*
        * _modelo es en donde se va a guardar los datos de la compra
        * idProducto es el producto que el usuario seleccionó
        */
        Compra _modelo = new Compra();
        long _idProducto = 0;

        public FrmCompraProductos()
        {
            InitializeComponent();
            _modelo = new Compra();
            _modelo.Detalles = new List<CompraDetalle>();
        }

        private void FrmListComprasProductos_Load(object sender, EventArgs e)
        {
            _inicializarInterfaz();
        }

        /*
        * Se crea y se da formato a la tabla  
        */
        private void _inicializarInterfaz()
        {
            tbldatos.ReadOnly = true;
            tbldatos.RowHeadersVisible = false;
            tbldatos.MultiSelect = false;
            tbldatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tbldatos.AllowUserToResizeRows = false;
            tbldatos.AllowUserToDeleteRows = false;
            tbldatos.AllowUserToAddRows = false;
            tbldatos.AutoGenerateColumns = false;

            /*
             * Se agregan las columnas 
             */
            tbldatos.Columns.Clear();
            tbldatos.AgregarColumna("ID", "ID", typeof(long), visible: false);
            tbldatos.AgregarColumna("NOMBRE", "Nombre", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            tbldatos.AgregarColumna("CANTIDAD", "Cantidad", typeof(int), alignment: DataGridViewContentAlignment.MiddleRight, autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            tbldatos.AgregarColumna("COSTO", "Costo", typeof(float), alignment: DataGridViewContentAlignment.MiddleRight, autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill, formato: "N2");
            tbldatos.AgregarColumna("TOTAL", "Total", typeof(float), alignment: DataGridViewContentAlignment.MiddleRight, autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill, formato: "N2");
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            /*
            * Se cargan los datos del producto seleccionado
            */
            FrmListProductos frm = new FrmListProductos(true);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Producto producto = frm.ConseguirProductoSeleccionado();
                _idProducto = producto.Id;
                txtNombre.Text = producto.Nombre;
                txtCosto.Text = "0";
                txtCant.Text = "0";
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            /*
            * Se agrega la celda correspondiente a cada columna
            */
            tbldatos.AgregarCelda(_idProducto);
            tbldatos.AgregarCelda(txtNombre.Text);
            tbldatos.AgregarCelda(txtCosto.Text);
            tbldatos.AgregarCelda(txtCant.Text);
            tbldatos.AgregarCelda(float.Parse(txtCosto.Text) * float.Parse(txtCant.Text));

            /*
            * Se actualiza el total
            */
            float total = float.Parse(txttotal.Text);
            total += float.Parse(txtCosto.Text) * float.Parse(txtCant.Text);

            txttotal.Text = total.ToString();

            /*
            * Se limpia los datos del producto
            */
            _idProducto = 0;
            txtNombre.Text = "";
            txtCosto.Text = "";
            txtCant.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Compra pCompra = new Compra();
            pCompra.Folio = txtFolio.Text.Trim();
            /*  pCompra.Fecha = dtpFecha.Value.Year + "/" + dtpFecha.Value.Month + "/" + dtpFecha.Value.Day;
             pCompra.Total= txttotal.Text.Trim();

              float resultado = Compra.Guardar(pCompra);
              if (resultado > 0)*/
            {
                MessageBox.Show("Compra Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*   Limpiar();
                Deshabilitar();

           }*/
            //else
            {
                    MessageBox.Show("No se pudo guardar la compra", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }


        }
    }
}
        
    


    