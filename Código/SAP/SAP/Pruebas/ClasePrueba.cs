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
                List<Producto> prods = new List<Producto>();
                Producto prod = new Producto();
                prod.Nombre = "Lapiz";
                prod.Descripcion = "Azul";
                prod.CodigoBarras = "11111";
                prod.Precio = 20f;
                prod.Cantidad = 0;

                Producto.Guardar(ref prod);
                Producto.Consultar(ref prod);
                Producto.ConsultarListado(ref prods);
                Producto.Eliminar(prod.Id);

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
