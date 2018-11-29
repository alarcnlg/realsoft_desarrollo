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
    public partial class FrmTotal : Form
    {
        float _total;
        public FrmTotal(float Total)
        {
            
            InitializeComponent();
            _total = Total;
        } 

        private void FrmTotal_Load(object sender, EventArgs e)
        {
            TxtTotal.Text = _total.ToString();

        }

        private void TxtEfectivo_TextChanged(object sender, EventArgs e)
        {
            float ingreso;
            float.TryParse(TxtEfectivo.Text, out ingreso);
            float cambio = ingreso-_total;

            if(cambio<0)
            {
                cambio = 0;
            }

            TxtCambio.Text = cambio.ToString();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            float ingreso;
            float.TryParse(TxtEfectivo.Text, out ingreso);
            float cambio = ingreso - _total;

            if(cambio>=0)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("El Efectivo no cubre con el Total");
            }

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
