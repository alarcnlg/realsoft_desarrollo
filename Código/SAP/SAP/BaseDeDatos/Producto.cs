using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using SAP.BaseDeDatos.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.BaseDeDatos
{
    [Table("productos")]
    public class Producto
    {
        public long Id { get; set; }
        public string CodigoBarras { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public int Cantidad { get; set; }

        public static bool Guardar(ref Producto producto)
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion(); 
                if (producto.Id == 0)
                {
                    producto.Id = conn.Insert(producto);
                }
                else
                {
                    conn.Update(producto);
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
                conn.Execute("UPDATE productos SET ESTADO='E' WHERE ID=@ID", new { ID = id });
            }
            catch (Exception ex)
            {
                ConexionBaseDeDatos.Error = ex.Message;
                return false;
            }
            return true;
        }

        public static bool Consultar(ref Producto producto)
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                producto = conn.Get<Producto>(producto.Id);
            }
            catch (Exception ex)
            {
                ConexionBaseDeDatos.Error = ex.Message;
                return false;
            }
            return true;
        }

        public static bool ConsultarListado(ref List<Producto> productos, string campoCriterio = "", string datoCriterio = "")
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                ConsultaBuilder consultaBuilder = new ConsultaBuilder("productos");
                consultaBuilder.AgregarCriterio("ESTADO='A'");
                consultaBuilder.AgregarOrderBy("NOMBRE");

                DynamicParameters parametros = null;

                if (campoCriterio.Length > 0 && datoCriterio.Length > 0)
                {
                    parametros = new DynamicParameters();
                    parametros.Add("@DATO", $"%{datoCriterio}%", System.Data.DbType.String);
                    consultaBuilder.AgregarCriterio($"{campoCriterio} LIKE @DATO");
                }

                productos = conn.Query<Producto>(consultaBuilder.ToString(), parametros).ToList();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public static bool ConsultarReporte(ref List<Producto> productos, DateTime fechaDel, DateTime fechaAl)
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                ConsultaBuilder consultaBuilder = new ConsultaBuilder("productos");
                consultaBuilder.AgregarCriterio("ESTADO='A'");
                consultaBuilder.AgregarOrderBy("NOMBRE");
                productos = conn.Query<Producto>(consultaBuilder.ToString()).ToList();
            }
            catch 
            {
                return false;
            }
            return true;
        }

        public static bool AgregarInventario(long id, int cantidad)
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                ConsultaBuilder consultaBuilder = new ConsultaBuilder("productos");
                consultaBuilder.AgregarCampo("CANTIDAD");
                consultaBuilder.AgregarCriterio("ID=@ID");

                string sql = "UPDATE productos SET CANTIDAD=@CANTIDAD WHERE ID=@ID";

                int cantidadActual = (int) conn.ExecuteScalar(consultaBuilder.ToString(), new { ID = id});

                conn.Execute(sql, new { ID = id, CANTIDAD = cantidadActual + cantidad });
            }
            catch (Exception ex)
            {
                ConexionBaseDeDatos.Error = ex.Message;
                return false;
            }
            return true;
        }

        public static bool RestarInventario(long id, int cantidad)
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                ConsultaBuilder consultaBuilder = new ConsultaBuilder("productos");
                consultaBuilder.AgregarCampo("CANTIDAD");
                consultaBuilder.AgregarCriterio("ID=@ID");

                string sql = "UPDATE productos SET CANTIDAD=@CANTIDAD WHERE ID=@ID";

                int cantidadActual = (int)conn.ExecuteScalar(consultaBuilder.ToString(), new { ID = id });

                conn.Execute(sql, new { ID = id, CANTIDAD = cantidadActual - cantidad });
            }
            catch (Exception ex)
            {
                ConexionBaseDeDatos.Error = ex.Message;
                return false;
            }
            return true;
        }

        public static bool ValidarExistencia(long id, int cantidad)
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                ConsultaBuilder consultaBuilder = new ConsultaBuilder("productos");
                consultaBuilder.AgregarCampo("(CANTIDAD - @CANTIDAD) AS CANTIDAD");
                consultaBuilder.AgregarCriterio("ID=@ID");
                int cant = Convert.ToInt32(conn.ExecuteScalar(consultaBuilder.ToString(), new { ID = id, CANTIDAD = cantidad }));
                if (cant < 0) return false;
            }
            catch (Exception ex)
            {
                ConexionBaseDeDatos.Error = ex.Message;
                return false;
            }
            return true;
        }
    }
}
