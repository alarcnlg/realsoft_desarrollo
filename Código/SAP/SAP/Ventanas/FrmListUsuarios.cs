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

namespace SAP.Ventanas
{
    public partial class FrmListUsuarios : Form
    {
        private List<Usuario> _datos;

        public FrmListUsuarios()
        {
            InitializeComponent();
            _datos = new List<Usuario>();
        }

        private void FrmListUsuarios_Load(object sender, EventArgs e)
        {
            DtgvListado.DataSource = _datos;
            FormatearDataGridView();
            CargarDataSourceComboBoxBusqueda();

            _consultar();
        }

        private void _consultar() {
            if (!Usuario.ConsultarListado(ref _datos, CmbCampos.SelectedValue.ToString(), TxtBuscar.Text)) {
                MessageBox.Show("Error al consultar Usuarios", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            DtgvListado.DataSource = _datos;

        }

        private void CargarDataSourceComboBoxBusqueda()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NOMBRE", typeof(string));
            dt.Columns.Add("CLAVE", typeof(string));

            string[] nombres = {"Nombre","Apellidos","Nombre de Usuario"};
            string[] claves = { "Nombre", "Apellidos", "NombreUsuario" };

            DataRow row = null;
            for (int i = 0; i < nombres.Length; i++) {
                row = dt.NewRow();
                row["NOMBRE"] = nombres[i];
                row["CLAVE"] = claves[i];
                dt.Rows.Add(row);
            }

            CmbCampos.DataSource = dt;
            CmbCampos.DisplayMember = "NOMBRE";
            CmbCampos.ValueMember = "CLAVE";
        }

        private void FormatearDataGridView() {
            DtgvListado.ReadOnly = true;
            DtgvListado.RowHeadersVisible = false;
            DtgvListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DtgvListado.AllowUserToResizeRows = false;

            DtgvListado.Columns[0].Visible = false;
            DtgvListado.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DtgvListado.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DtgvListado.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DtgvListado.Columns[3].HeaderText = "Usuario";

            DtgvListado.Columns[4].Visible = false;
            DtgvListado.Columns[5].Visible = false;

            DtgvListado.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DtgvListado.Columns[6].HeaderText = "Tipo";
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
    }
}
