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
    [Table("facturas")]
    class Factura
    {
        public long Id { get; set; }
        public long IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public byte[] ArchivoXML { get; set; }
        public byte[] ArchivoPDF { get; set; }
        public char Estado { get; set; }

        public static bool Guardar(ref Factura factura)
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                factura.Estado = 'A';
                factura.Id = conn.Insert(factura);
            }
            catch (Exception ex)
            {
                ConexionBaseDeDatos.Error = ex.Message;
                return false;
            }
            return true;
        }

        public static bool ConsultarXML(long id, ref byte[] datos)
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                datos = (byte[]) conn.ExecuteScalar("SELECT ARCHIVOXML FROM facturas WHERE ID=@ID", new { ID = id });
            }
            catch (Exception ex)
            {
                ConexionBaseDeDatos.Error = ex.Message;
                return false;
            }
            return true;
        }

        public static bool ConsultarPDF(long id, ref byte[] datos)
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                datos = (byte[])conn.ExecuteScalar("SELECT ARCHIVOPDF FROM facturas WHERE ID=@ID", new { ID = id });
            }
            catch (Exception ex)
            {
                ConexionBaseDeDatos.Error = ex.Message;
                return false;
            }
            return true;
        }

        public static bool ConsultarReporte(ref List<Factura> facturas, DateTime fechaDel, DateTime fechaAl) {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();

                ConsultaBuilder consultaBuilder = new ConsultaBuilder("facturas");
                consultaBuilder.AgregarCriterio($"FECHA BETWEEN '{fechaDel.ToString("yyyy-MM-dd")}' AND '{fechaAl.ToString("yyyy-MM-dd")}'");

                facturas = conn.Query<Factura>(consultaBuilder.ToString()).ToList();
            }
            catch (Exception ex)
            {
                ConexionBaseDeDatos.Error = ex.Message;
                return false;
            }
            return true;
        }

        public static bool ConsultarListado(ref List<Factura> facturas, string campoCriterio = "", string datoCriterio = "", bool soloActivas = false)
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                ConsultaBuilder consultaBuilder = new ConsultaBuilder("facturas");
                if (soloActivas == true)
                {
                    consultaBuilder.AgregarCriterio("ESTADO = 'A'");
                }
                DynamicParameters parametros = null;

                if (campoCriterio.Length > 0 && datoCriterio.Length > 0)
                {
                    parametros = new DynamicParameters();
                    parametros.Add("@DATO", $"%{datoCriterio}%", System.Data.DbType.String);
                    consultaBuilder.AgregarCriterio($"{campoCriterio} LIKE @DATO");
                }

                facturas = conn.Query<Factura>(consultaBuilder.ToString(), parametros).ToList();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool ConsultarSiguienteID(ref long id)
        {
            try
            {
                MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();
                id = (long)conn.ExecuteScalar("SELECT IFNULL(MAX(ID),0) + 1 FROM FACTURAS");
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
