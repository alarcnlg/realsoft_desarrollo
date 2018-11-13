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
    public partial class FrmUsuario : Form
    {
        private Usuario _modelo;

        public FrmUsuario(long id = 0)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;

            _modelo = new Usuario();
            _modelo.Id = id;
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            CmbTipoUsuario.AgregarItem("Administrador", "A");
            CmbTipoUsuario.AgregarItem("Cajero", "C");

            if (_modelo.Id == 0)
            {
                Text = "Nuevo Usuario";
            }
            else
            {
                Text = "Editar Usuario";
            }

            _consultar();
        }

        private void _consultar()
        {
            if (_modelo.Id == 0) return;
            if (!Usuario.Consultar(ref _modelo))
            {
                MessageBox.Show("Error al consultar Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _llenarDatos();
        }

        private void _guardar() {
            if (!_validar()) return;
            if (!Usuario.Guardar(ref _modelo)) {
                MessageBox.Show("Error al guardar Usuario", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Usuario guardado correctamente", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (ModuloGeneral.UsuarioActivo.Id == _modelo.Id)
            {
                MessageBox.Show("Se reiniciará el Sistema para aplicar los cambios realizados", "Reinicio de sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ModuloGeneral.FrmLogin.Visible = true;
                ModuloGeneral.FrmMDI.CerraAplicacion = false;
                ModuloGeneral.FrmMDI.Close();
            }
            DialogResult = DialogResult.OK;
        }

        private void _llenarDatos()
        {
            TxtNombre.Text = _modelo.Nombre;
            TxtApellidos.Text = _modelo.Apellidos;
            TxtNombreUsuario.Text = _modelo.NombreUsuario;
            TxtPassword.Text = "";

            CmbTipoUsuario.SelectedValue = _modelo.Tipo;
        }

        private bool _validar()
        {
            if (TxtNombre.Text.Length == 0)
            {
                MessageBox.Show("El Nombre es requerido", "No validado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (TxtApellidos.Text.Length == 0)
            {
                MessageBox.Show("Los Apellidos son requeridos", "No validado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (TxtNombreUsuario.Text.Length == 0)
            {
                MessageBox.Show("El Nombre de Usuario es requerido", "No validado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            _modelo.Nombre = TxtNombre.Text;
            _modelo.Apellidos = TxtApellidos.Text;
            _modelo.NombreUsuario = TxtNombreUsuario.Text;
            if (TxtPassword.Text.Length > 0)
            {
                _modelo.Password = TxtPassword.Text;
            }
            _modelo.Tipo = Convert.ToChar(CmbTipoUsuario.SelectedValue.ToString());
            return true;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            _guardar();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
