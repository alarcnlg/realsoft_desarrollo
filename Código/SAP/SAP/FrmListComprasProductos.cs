using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP
{
    public partial class Compra : Form
    {

        public Compra()
        {
            InitializeComponent();
        }

        private void FrmListComprasProductos_Load(object sender, EventArgs e)
        { /*
            try
            {
                DataGridView dtgv = new DataGridView();

                //Constructor de la ventana o evento Load
                Compra compra = new Compra();
                compra.Detalles = new List<CompraDetalle>();
                

                // Conseguir datos dtgv = Nombre del datagridview
                CompraDetalle compraDetalle = null;

                float total = 0;
                for (int i = 0; i < dtgv.RowCount; i++)
                {
                    compraDetalle = new CompraDetalle();
                    txtNombre.Text = Convert.ToInt32(dtgv.Rows[i].Cells["Nombre"].Value);
                    txtCant.Text = Convert.ToInt32(dtgv.Rows[i].Cells["CANTIDAD"].Value);
                    txtCosto.Text = float.Parse(dtgv.Rows[i].Cells["COSTO"].Value.ToString());
                    total += compraDetalle.Cantidad * compraDetalle.CostoUnidad;
                    compra.Detalles.Add(compraDetalle);
                }
                compra.txttotal= total;
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


       
            */
        }
    }
        }
    