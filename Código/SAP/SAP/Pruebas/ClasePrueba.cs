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
using SAP.Ventanas;

namespace SAP.Pruebas
{
    class ClasePrueba
    {
        public static bool Probar() {
            try {

                DataGridView dtgv = new DataGridView();

                //Constructor de la ventana o evento Load
                BaseDeDatos.Compra compra = new BaseDeDatos.Compra();
                compra.Detalles = new List<CompraDetalle>();
                /////////////////////////////////////////

                // Conseguir datos dtgv = Nombre del datagridview
                CompraDetalle compraDetalle = null;

                float total = 0;
                for (int i = 0; i < dtgv.RowCount; i++)
                {
                    compraDetalle = new CompraDetalle();
                    compraDetalle.IdProducto = Convert.ToInt32(dtgv.Rows[i].Cells["IDPRODUCTO"].Value);
                    compraDetalle.Cantidad = Convert.ToInt32(dtgv.Rows[i].Cells["CANTIDAD"].Value);
                    compraDetalle.CostoUnidad = float.Parse(dtgv.Rows[i].Cells["COSTO"].Value.ToString());
                    total += compraDetalle.Cantidad * compraDetalle.CostoUnidad;
                    compra.Detalles.Add(compraDetalle);
                }
                compra.Total = total;
                /////////////////////////////////////////

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
