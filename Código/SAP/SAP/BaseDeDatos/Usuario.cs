using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.BaseDeDatos
{
    [Table("usuarios")]
    class Usuario
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public char Tipo { get; set; }


        public static bool Ingresar(ref Usuario usuario) {
            return true;
        }

        public static bool Guardar(ref Usuario usuario)
        {
            return true;
        }

        public static bool Eliminar(ref Usuario usuario)
        {
            return true;
        }

        public static bool Consultar(ref Usuario usuario)
        {
            return true;
        }

        public static bool ConsultarListado(ref List<Usuario> usuarios)
        {
            return true;
        }

    }
}
