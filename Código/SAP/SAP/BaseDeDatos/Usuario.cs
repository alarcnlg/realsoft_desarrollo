using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using SAP.BaseDeDatos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;

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

        [Write(false)]
        [Computed()]
        public string NombreTipo {
            get {
                return Tipo=='A'?"Administrador":"Cajero";
            }
        }

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

        public static bool ConsultarListado(ref List<Usuario> usuarios,string campoCriterio = "", string datoCriterio = "")
        {
            MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
            try
            {

                conn.Open();
                if (campoCriterio.Length > 0 && datoCriterio.Length > 0)
                {
                    DynamicParameters parametros = new DynamicParameters();
                    parametros.Add("@DATO", $"%{datoCriterio}%", System.Data.DbType.String);
                    usuarios = conn.Query<Usuario>($"SELECT * FROM usuarios WHERE {campoCriterio} LIKE @DATO ORDER BY NOMBRE",parametros).ToList();
                }
                else {
                    usuarios = conn.Query<Usuario>("SELECT * FROM usuarios ORDER BY NOMBRE").ToList();
                }
               
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }

    }
}
