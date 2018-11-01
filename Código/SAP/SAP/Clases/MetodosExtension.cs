using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Clases
{
    static class MetodosExtension
    {
        public static void CargarFormulario(this FrmMDI frmMDI,Form form) {
            form.MdiParent = frmMDI;
            form.Show();
        }
    }
}
