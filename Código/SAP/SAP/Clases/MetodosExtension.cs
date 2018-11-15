using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SAP;

namespace SAP.Clases
{
    static class MetodosExtension
    {

        public static void AgregarColumna(this DataGridView dtgv, string nombre, string textoCabecera, Type tipo, int ancho = 0, bool soloLectura = false, 
                                            bool visible = true, string formato = "", DataGridViewContentAlignment alignment = DataGridViewContentAlignment.MiddleLeft, 
                                            DataGridViewAutoSizeColumnMode autoSizeColumnMode = DataGridViewAutoSizeColumnMode.None) {
            int index = dtgv.Columns.Add(nombre, textoCabecera);
            dtgv.Columns[index].ValueType = tipo;
            dtgv.Columns[index].Name = nombre;
            dtgv.Columns[index].HeaderText = textoCabecera;
            dtgv.Columns[index].Width = ancho;
            dtgv.Columns[index].ReadOnly = soloLectura;
            dtgv.Columns[index].Visible = visible;
            dtgv.Columns[index].DefaultCellStyle.Alignment = alignment;
            dtgv.Columns[index].DefaultCellStyle.Format = formato;
            dtgv.Columns[index].AutoSizeMode = autoSizeColumnMode;

        }

        public static void AgregarCelda(this DataGridView dtgv, object valor)
        {
            List<object> row = null;
        
            if (dtgv.Tag == null)
            {
                dtgv.Tag = new List<object>();
            }
            row = (List<object>)dtgv.Tag;

            row.Add(valor);

            if (row.Count == dtgv.ColumnCount)
            {
                dtgv.Rows.Add(row.ToArray());
                dtgv.Tag = null;
            }
        }

        public static void AgregarItem(this ComboBox cmb, string nombre, object valor)
        {
            DataTable dt = null;

            if (cmb.DataSource == null)
            {
                dt = new DataTable();
                dt.Columns.Add("NOMBRE");
                dt.Columns.Add("VALOR");
                cmb.DataSource = dt;
                cmb.DisplayMember = "NOMBRE";
                cmb.ValueMember = "VALOR";
            }
            else
            {
                dt = (DataTable)cmb.DataSource;
            }

            dt.Rows.Add(new[] { nombre, valor });
        }

        public static void CargarFormulario(this FrmMDI frmMDI, Form form)
        {
            form.MdiParent = frmMDI;
            form.Show();
        }


    }
}
