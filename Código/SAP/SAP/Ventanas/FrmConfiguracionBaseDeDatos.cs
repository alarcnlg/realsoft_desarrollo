using MySql.Data.MySqlClient;
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
    public partial class FrmConfiguracionBaseDeDatos : Form
    {
        ArchivoConfiguracion _archivoConf;
        bool _modoConfigIni;

        public FrmConfiguracionBaseDeDatos(bool modoConfigIni = false)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _modoConfigIni = modoConfigIni;
        }

        private void FrmConfiguracionBaseDeDatos_Load(object sender, EventArgs e)
        {
            _archivoConf = new ArchivoConfiguracion();
            _cargarDatos();
        }

        private void _cargarDatos()
        { 
            try
            {
                if (_archivoConf.EsExistente())
                {
                    _archivoConf.CargarDatos();
                }
                TxtServidor.Text = _archivoConf.Servidor;
                TxtPuerto.Text = _archivoConf.Puerto.ToString();
                TxtBaseDeDatos.Text = _archivoConf.BaseDeDatos;
                TxtUsuario.Text = _archivoConf.Usuario;
                TxtPassword.Text = "";
            }
            catch
            {
                MessageBox.Show("Error al cargar Configuración", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private bool _validar()
        {
            if (TxtServidor.Text.Length == 0) {
                MessageBox.Show("El Servidor es necesario", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            int puerto;
            if (!int.TryParse(TxtPuerto.Text, out puerto))
            {
                MessageBox.Show("El Puerto es invalido", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (TxtBaseDeDatos.Text.Length == 0)
            {
                MessageBox.Show("El nombre de la Base de Datos es necesario", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (TxtUsuario.Text.Length == 0)
            {
                MessageBox.Show("El Usuario es necesario", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (TxtPassword.Text.Length == 0)
            {
                MessageBox.Show("La Contraseña es necesario", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            _archivoConf.Servidor = TxtServidor.Text;
            _archivoConf.Puerto = Convert.ToInt32(TxtPuerto.Text);
            _archivoConf.BaseDeDatos = TxtBaseDeDatos.Text;
            _archivoConf.Usuario = TxtUsuario.Text;
            _archivoConf.Password = TxtPassword.Text;

            return true;
        }

        private bool ProbarConexion() {
            try
            {
                MySqlConnection conn = new MySqlConnection(_archivoConf.CrearConnectionString());
                conn.Open();
                conn.Close();
                MessageBox.Show("Conexión correcta", "Prueba de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Conexión incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void BtnProbar_Click(object sender, EventArgs e)
        {
            if (!_validar()) return;
            ProbarConexion();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!_validar()) return;
            if (!ProbarConexion()) return;
            try
            {
                _archivoConf.GuardarDatos();
                ModuloGeneral.ConnectionString = _archivoConf.CrearConnectionString();
                DialogResult = DialogResult.OK;
                MessageBox.Show("Configuración guardada correctamente", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (_modoConfigIni)
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("Se reiniciará el sistema para aplicar la nueva configuración", "Nueva Configuración", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    ModuloGeneral.FrmLogin.Visible = true;
                    ModuloGeneral.FrmMDI.CerraAplicacion = false;
                    ModuloGeneral.FrmMDI.Close();
                }
            }
            catch {
                MessageBox.Show("Error al guardar Configuración","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
