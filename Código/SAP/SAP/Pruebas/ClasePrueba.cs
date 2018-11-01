using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAP.BaseDeDatos.Core;
using SAP.BaseDeDatos;
using MySql.Data;
using System.Windows.Forms;
using Dapper;
using Dapper.Contrib.Extensions;

namespace SAP.Pruebas
{
    class ClasePrueba
    {
        public static bool Probar() {
            try
            {

                //Ejemplo de Guardar un usuario
                Usuario user = new Usuario() { Nombre = "Nombre", Apellidos = "A", NombreUsuario = "ejemp", Password = "12345678", Tipo = 'C' };
                if (Usuario.Guardar(ref user))
                {
                    MessageBox.Show("Usuario guardado correctamente", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show("Error al guardar usuario", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //******************************

                //List<Usuario> usuarios = new List<Usuario>();
                //ConsultarMuchosRegistros(ref usuarios);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return true;
        }

        /*
         * Ejemplos de acceso a base de datos
         * La palabra ref es para pasarlo como referencia
         */
        public static bool ConsultarUnRegistro( ref Usuario usuario)
        {
            var conn = ConexionBaseDeDatos.ConseguirConexion();
            try
            {
                conn.Open();
                usuario = conn.Query<Usuario>("SELECT * FROM usuarios WHERE ID=1 LIMIT 1").FirstOrDefault();
                if (usuario == null) {
                    return false;
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

        public static bool ConsultarMuchosRegistros(ref List<Usuario> usuarios)
        {
            var conn = ConexionBaseDeDatos.ConseguirConexion();
            try
            {
                conn.Open();
                usuarios = conn.Query<Usuario>("SELECT * FROM usuarios").ToList();
                if (usuarios.Count == 0)
                {
                    return false;
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

        public static bool Guardar(ref Usuario usuario)
        {
            var conn = ConexionBaseDeDatos.ConseguirConexion();
            try
            {
                conn.Open();
                if (usuario.Id == 0)
                {
                    usuario.Id = conn.Insert(usuario);
                }
                else {
                    conn.Update(usuario);
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

        public static bool Eliminar(ref Usuario usuario)
        {
            var conn = ConexionBaseDeDatos.ConseguirConexion();
            try
            {
                conn.Open();       
                conn.Delete(usuario);               
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
