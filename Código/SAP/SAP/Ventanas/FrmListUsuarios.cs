using SAP.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAP.Clases;

namespace SAP.Ventanas
{
    public partial class FrmListUsuarios : Form
    {
        private List<Usuario> _modelo;

        public FrmListUsuarios()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;

            _modelo = new List<Usuario>();
        }

        private void FrmListUsuarios_Load(object sender, EventArgs e)
        {
            CmbCampos.AgregarItem("Nombre", "Nombre");
            CmbCampos.AgregarItem("Apellidos", "Apellidos");
            CmbCampos.AgregarItem("Nombre de Usuario", "NombreUsuario");

            _inicializarInterfaz();

            _consultar();
        }

        private void _consultar() {
            if (!Usuario.ConsultarListado(ref _modelo, CmbCampos.SelectedValue.ToString(), TxtBuscar.Text)) {
                MessageBox.Show("Error al consultar Usuarios", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            _llenaDatos();

        }

        private void _inicializarInterfaz()
        {
            DtgvListado.ReadOnly = true;
            DtgvListado.RowHeadersVisible = false;
            DtgvListado.MultiSelect = false;
            DtgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DtgvListado.AllowUserToResizeRows = false;
            DtgvListado.AllowUserToDeleteRows = false;
            DtgvListado.AllowUserToAddRows = false;
            DtgvListado.AutoGenerateColumns = false;

            DtgvListado.AgregarColumna("ID", "ID", typeof(long), visible: false);
            DtgvListado.AgregarColumna("NOMBRE", "Nombre", typeof(string), autoSizeColumnMode : DataGridViewAutoSizeColumnMode.Fill);
            DtgvListado.AgregarColumna("APELLIDOS", "Apellidos", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            DtgvListado.AgregarColumna("NOMBREUSUARIO", "Nombre de Usuario", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);
            DtgvListado.AgregarColumna("TIPO", "Tipo", typeof(string), autoSizeColumnMode: DataGridViewAutoSizeColumnMode.Fill);

        }

        private void _llenaDatos()
        {
            DtgvListado.Rows.Clear();

            for (int i = 0; i < _modelo.Count; i++)
            {
                DtgvListado.AgregarCelda(_modelo[i].Id);
                DtgvListado.AgregarCelda(_modelo[i].Nombre);
                DtgvListado.AgregarCelda(_modelo[i].Apellidos);
                DtgvListado.AgregarCelda(_modelo[i].NombreUsuario);
                DtgvListado.AgregarCelda(_modelo[i].Tipo == 'A'? "Administrador":"Cajero");
            }

        }

        private void TxtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') {
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
            if (MessageBox.Show("¿Está seguro de Eliminar este Usuario?", "Eliminar", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                if (!Usuario.Eliminar(_modelo[DtgvListado.SelectedRows[0].Index].Id)) {
                    MessageBox.Show("Error al eliminar Usuario", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Usuario eliminado correctamente", "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _consultar();
            }
         
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (DtgvListado.SelectedRows.Count != 1) return;
            FrmUsuario frm = new FrmUsuario(_modelo[DtgvListado.SelectedRows[0].Index].Id);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _consultar();
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmUsuario frm = new FrmUsuario();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _consultar();
            }
        }
    }
}
