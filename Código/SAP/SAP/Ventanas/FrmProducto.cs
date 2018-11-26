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
    public partial class FrmProducto : Form
    {
        private Producto _modelo;
        public FrmProducto(long id = 0)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;

            _modelo = new Producto();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            if (_modelo.Id == 0)
            {
                Text = "Nuevo Producto";
            }
            else
            {
                Text = "Editar Producto";
            }

            _consultar();

        }

        private void _consultar()
        {
            if (_modelo.Id == 0) return;
            if (!Producto.Consultar(ref _modelo))
            {
                MessageBox.Show("Error al consultar Producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _llenarDatos();
        }

        private void _guardar()
        {
            if (!_validar()) return;
            if (!Producto.Guardar(ref _modelo))
            {
                MessageBox.Show("Error al guardar Producto", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Producto guardado correctamente", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            TxtCodigoBarras.Text = _modelo.CodigoBarras;
            TxtNombre.Text = _modelo.Nombre;
            TxtMarca.Text = _modelo.Marca;
            TxtDescripcion.Text = _modelo.Descripcion;
            TxtPrecio.Text = _modelo.Precio.ToString();
            TxtCantidad.Text = _modelo.Cantidad.ToString();

        }

        private bool _validar()
        {
            if (TxtCodigoBarras.Text.Length == 0)
            {
                MessageBox.Show("El Codigo de Barras es requerido", "No validado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (TxtNombre.Text.Length == 0)
            {
                MessageBox.Show("El Nombre es requerido", "No validado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (TxtMarca.Text.Length == 0)
            {
                MessageBox.Show("La Marca es requerida", "No validado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (TxtDescripcion.Text.Length == 0)
            {
                MessageBox.Show("La Descripcion es requerida", "No validado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (TxtPrecio.Text.Length == 0)
            {
                MessageBox.Show("El Precio es requerido", "No validado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (TxtCantidad.Text.Length == 0)
            {
                MessageBox.Show("La Cantidad es requerida", "No validado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            _modelo.CodigoBarras = TxtCodigoBarras.Text;
            _modelo.Nombre = TxtNombre.Text;
            _modelo.Marca = TxtMarca.Text;
            _modelo.Descripcion = TxtDescripcion.Text;
            _modelo.Precio = float.Parse(TxtPrecio.Text);
            _modelo.Cantidad = int.Parse(TxtCantidad.Text);
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
