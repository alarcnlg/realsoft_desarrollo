using SAP.Pruebas;
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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void FrmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') {
                ModuloGeneral.UsuarioActivo = new BaseDeDatos.Usuario() { Id = 1,Nombre="Admin",Apellidos="Istrador", NombreUsuario = "admin",Password="123", Tipo = 'A' };
                ModuloGeneral.FrmLogin = this;
                FrmMDI frm = new FrmMDI();
                frm.Show();
                Visible = false;
            }
        }
    }
}
