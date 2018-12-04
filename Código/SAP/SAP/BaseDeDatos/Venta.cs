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
    [Table("ventas")]
    class Venta
    {
        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public float Total { get; set; }
        public DateTime FechaCancelacion { get; set; }
        public char Estado { get; set; }

        [Write(false)]
        [Computed()]
        public List<VentaDetalle> Detalles { get; set; }

        public static bool Guardar(ref Venta venta)
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                venta.FechaCancelacion = DateTime.Now;
                venta.Estado = 'A';

                venta.Id = conn.Insert(venta);

                for (int i = 0; i < venta.Detalles.Count; i++)
                {
                    venta.Detalles[i].IdVenta = venta.Id;
                    conn.Insert(venta.Detalles[i]);

                    if (!Producto.RestarInventario(venta.Detalles[i].IdProducto, venta.Detalles[i].Cantidad))
                    {
                        throw new Exception(ConexionBaseDeDatos.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                ConexionBaseDeDatos.Error = ex.Message;
                return false;
            }
            return true;
        }

        public static bool Cancelar(long id)
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                string sql = "UPDATE ventas SET ESTADO='C' WHERE ID=@ID";
                conn.Execute(sql, new { ID = id });
            }
            catch (Exception ex)
            {
                ConexionBaseDeDatos.Error = ex.Message;
                return false;
            }
            return true;
        }

        public static bool Consultar(ref Venta venta)
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();

                ConsultaBuilder consultaBuilder = new ConsultaBuilder("ventas v");
                consultaBuilder.AgregarCampo("v.*, d.*");
                consultaBuilder.AgregarJoin("INNER JOIN ventadetalles d ON d.IDVENTA = v.ID");
                consultaBuilder.AgregarCriterio("v.ID=@ID");

                Venta ventaConsulta = null;

                venta = conn.Query<Venta, VentaDetalle, Venta>(consultaBuilder.ToString(),
                    (ventasel, detalle) => {
                        if (ventaConsulta == null)
                        {
                            ventaConsulta = ventasel;
                            ventaConsulta.Detalles = new List<VentaDetalle>();
                        }
                        ventaConsulta.Detalles.Add(detalle);
                        return ventaConsulta;
                    }, new { ID = venta.Id }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                ConexionBaseDeDatos.Error = ex.Message;
                return false;
            }
            return true;
        }

        public static bool ConsultarListado(ref List<Venta> ventas, string campoCriterio = "", string datoCriterio = "")
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                ConsultaBuilder consultaBuilder = new ConsultaBuilder("ventas");

                DynamicParameters parametros = null;

                if (campoCriterio.Length > 0 && datoCriterio.Length > 0)
                {
                    parametros = new DynamicParameters();
                    parametros.Add("@DATO", $"%{datoCriterio}%", System.Data.DbType.String);
                    consultaBuilder.AgregarCriterio($"{campoCriterio} LIKE @DATO");
                }

                ventas = conn.Query<Venta>(consultaBuilder.ToString(), parametros).ToList();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool ConsultarReporte(ref List<Venta> ventas, DateTime fechaDel, DateTime fechaAl)
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                ConsultaBuilder consultaBuilder = new ConsultaBuilder("ventas");
                consultaBuilder.AgregarCriterio($"FECHA BETWEEN '{fechaDel.ToString("yyyy-MM-dd")}' AND '{fechaAl.ToString("yyyy-MM-dd")}'");

                ventas = conn.Query<Venta>(consultaBuilder.ToString(), new { FECHADEL = fechaDel.ToShortDateString(), FECHAAL = fechaAl.ToShortDateString() }).ToList();
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
