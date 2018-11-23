using SAP.BaseDeDatos;
using SAP.Ventanas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Pruebas
{
    public partial class FrmPruebaSeleccionProducto : Form
    {
        public FrmPruebaSeleccionProducto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmListProductos frm = new FrmListProductos(true);

            Producto prod;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                prod = frm.ConseguirProductoSeleccionado();
                TxtNombre.Text = prod.Nombre;
                TxtCantidad.Text = prod.Cantidad.ToString();
                TxtCosto.Text = prod.Precio.ToString();
            }
        }
    }
}
