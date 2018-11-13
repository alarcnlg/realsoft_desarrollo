using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using SAP.BaseDeDatos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

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
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                ConsultaBuilder consultaBuilder = new ConsultaBuilder("usuarios");

                consultaBuilder.AgregarCriterio("NOMBREUSUARIO=@NOMBREUSUARIO");
                consultaBuilder.AgregarCriterio("PASSWORD=@PASSWORD");

                usuario = conn.Query<Usuario>(consultaBuilder.ToString(),
                    new { NOMBREUSUARIO = usuario.NombreUsuario, PASSWORD = usuario.Password }).FirstOrDefault();
                if (usuario == null)
                {
                    ConexionBaseDeDatos.Error = "Nombre de Usuario o Contraseña incorrecto";
                    return false;
                }
            }
            catch(Exception ex)
            {
                ConexionBaseDeDatos.Error = ex.Message;
                return false;
            }
            return true;
        }

        public static bool Guardar(ref Usuario usuario)
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion(); conn = ConexionBaseDeDatos.ConseguirConexion();
                if (usuario.Id == 0)
                {
                    usuario.Id = conn.Insert(usuario);
                }
                else
                {
                    conn.Update(usuario);
                }
            }
            catch (Exception ex)
            {
                ConexionBaseDeDatos.Error = ex.Message;
                return false;
            }
            return true;
        }

        public static bool Eliminar(long id)
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                conn.Delete(new Usuario { Id = id });
            }
            catch (Exception ex)
            {
                ConexionBaseDeDatos.Error = ex.Message;
                return false;
            }
            return true;
        }

        public static bool Consultar(ref Usuario usuario)
        {
           
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                usuario = conn.Get<Usuario>(usuario.Id);
            }
            catch (Exception ex)
            {
                ConexionBaseDeDatos.Error = ex.Message;
                return false;
            }
            return true;
        }

        public static bool ConsultarListado(ref List<Usuario> usuarios,string campoCriterio = "", string datoCriterio = "")
        {   
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                ConsultaBuilder consultaBuilder = new ConsultaBuilder("usuarios");
                consultaBuilder.AgregarOrderBy("NOMBRE");

                DynamicParameters parametros = null;

                if (campoCriterio.Length > 0 && datoCriterio.Length > 0)
                {
                    parametros = new DynamicParameters();
                    parametros.Add("@DATO", $"%{datoCriterio}%", System.Data.DbType.String);
                    consultaBuilder.AgregarCriterio($"{campoCriterio} LIKE @DATO");
                }

                usuarios = conn.Query<Usuario>(consultaBuilder.ToString(), parametros).ToList();
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
