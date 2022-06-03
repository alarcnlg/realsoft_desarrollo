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
    [Table("compras")]
    class Compra
    {
        public long Id { get; set; }
        public string Folio { get; set; }
        public DateTime Fecha { get; set; }
        public float Total { get; set; }
        public DateTime FechaCancelacion { get; set; }
        public char Estado { get; set; }

        [Write(false)]
        [Computed()]
        public List<CompraDetalle> Detalles { get; set; }

        public static bool Guardar(ref Compra compra)
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                compra.FechaCancelacion = DateTime.Now;
                compra.Estado = 'A';

                compra.Id = conn.Insert(compra);

                for (int i = 0; i < compra.Detalles.Count; i++)
                {
                    compra.Detalles[i].IdCompra = compra.Id;
                    conn.Insert(compra.Detalles[i]);

                    if (!Producto.AgregarInventario(compra.Detalles[i].IdProducto, compra.Detalles[i].Cantidad))
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
                string sql = "UPDATE compras SET ESTADO='C' WHERE ID=@ID";
                conn.Execute(sql, new { ID = id});
            }
            catch (Exception ex)
            {
                ConexionBaseDeDatos.Error = ex.Message;
                return false;
            }
            return true;
        }

        public static bool Consultar(ref Compra compra)
        {

            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();

                ConsultaBuilder consultaBuilder = new ConsultaBuilder("compras c");
                consultaBuilder.AgregarCampo("c.*, d.*");
                consultaBuilder.AgregarJoin("INNER JOIN comprasdetalles d ON d.IDCOMPRA = c.ID");
                consultaBuilder.AgregarCriterio("c.ID=@ID");

                Compra compraConsulta = null;

                compra = conn.Query<Compra, CompraDetalle, Compra>(consultaBuilder.ToString(),
                    (comprasel, detalle) => {
                        if (compraConsulta == null) {
                            compraConsulta = comprasel;
                            compraConsulta.Detalles = new List<CompraDetalle>();
                        }
                        compraConsulta.Detalles.Add(detalle);
                        return compraConsulta;
                    }, new { ID = compra.Id }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                ConexionBaseDeDatos.Error = ex.Message;
                return false;
            }
            return true;
        }

        public static bool ConsultarListado(ref List<Compra> compras, string campoCriterio = "", string datoCriterio = "")
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                ConsultaBuilder consultaBuilder = new ConsultaBuilder("compras");

                DynamicParameters parametros = null;

                if (campoCriterio.Length > 0 && datoCriterio.Length > 0)
                {
                    parametros = new DynamicParameters();
                    parametros.Add("@DATO", $"%{datoCriterio}%", System.Data.DbType.String);
                    consultaBuilder.AgregarCriterio($"{campoCriterio} LIKE @DATO");
                }

                compras = conn.Query<Compra>(consultaBuilder.ToString(), parametros).ToList();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool ConsultarReporte(ref List<Compra> compras, DateTime fechaDel, DateTime fechaAl)
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                ConsultaBuilder consultaBuilder = new ConsultaBuilder("compras");
                consultaBuilder.AgregarCriterio($"FECHA BETWEEN '{fechaDel.ToString("yyyy-MM-dd")}' AND '{fechaAl.ToString("yyyy-MM-dd")}'");

                compras = conn.Query<Compra>(consultaBuilder.ToString()).ToList();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
