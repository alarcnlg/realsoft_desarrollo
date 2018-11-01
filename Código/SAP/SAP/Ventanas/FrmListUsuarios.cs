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
            _datos.Add(ModuloGeneral.UsuarioActivo);
            DtgvListado.DataSource = _datos;
        }
    }
}
