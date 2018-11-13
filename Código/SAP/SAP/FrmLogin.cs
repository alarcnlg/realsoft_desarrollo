using SAP.BaseDeDatos;
using SAP.Clases;
using SAP.Pruebas;
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

namespace SAP
{
    public partial class FrmLogin : Form
    {
        private Usuario _modelo;

        public FrmLogin()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            _modelo = new Usuario();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            ArchivoConfiguracion archivoConfiguracion = new ArchivoConfiguracion();

            if (!archivoConfiguracion.EsExistente())
            {
                Visible = false;
                FrmConfiguracionBaseDeDatos frm = new FrmConfiguracionBaseDeDatos(true);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Visible = true;
                }
                else
                {
                    Application.Exit();
                }
            }
            else {
                archivoConfiguracion.CargarDatos();
                ModuloGeneral.ConnectionString = archivoConfiguracion.CrearConnectionString();
            }
        }

        private bool _validar() {
            
            if (TxtNombreUsuario.Text.Length == 0)
            {
                MessageBox.Show("Escriba su Nombre de Usuario", "No validado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (TxtPassword.Text.Length == 0)
            {
                MessageBox.Show("Escriba su Contraseña", "No validado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            _modelo = new Usuario();
            _modelo.NombreUsuario = TxtNombreUsuario.Text;
            _modelo.Password = TxtPassword.Text;

            return true;
        }

        private void _ingresar() {
            if (!_validar()) return;
            if (Usuario.Ingresar(ref _modelo))
            {
                ModuloGeneral.UsuarioActivo = _modelo;
                ModuloGeneral.FrmLogin = this;

                TxtNombreUsuario.Focus();
                TxtNombreUsuario.Clear();
                TxtPassword.Clear();

                FrmMDI frmMDI = new FrmMDI();
                ModuloGeneral.FrmMDI = frmMDI;
                frmMDI.Show();

                Visible = false;
            }
            else
            {
                MessageBox.Show(BaseDeDatos.Core.ConexionBaseDeDatos.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            _ingresar();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') {
                _ingresar();
            }
        }

    }
}
