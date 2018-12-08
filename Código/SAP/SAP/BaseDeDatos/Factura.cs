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

        public static bool ConsultarReporte(ref List<Factura> facturas, DateTime fechaDel, DateTime fechaAl) {
            try
            {
                //facturas.Add(new Factura() { Id = 1, Folio = "123", NoVenta = 3, Fecha = DateTime.Now, Total = 245, FechaCancelacion = DateTime.Now, Estado = 'A' });
                //facturas.Add(new Factura() { Id = 1, Folio = "789", NoVenta = 4, Fecha = DateTime.Now, Total = 300, FechaCancelacion = DateTime.Now, Estado = 'A' });
                //facturas.Add(new Factura() { Id = 1, Folio = "820", NoVenta = 4, Fecha = DateTime.Now, Total = 126, FechaCancelacion = DateTime.Now, Estado = 'C' });
                //MySqlConnection conn = ConexionBaseDeDatos.ConseguirConexion();

                //ConsultaBuilder consultaBuilder = new ConsultaBuilder("ventas v");
                //consultaBuilder.AgregarCampo("v.*, d.*");
                //consultaBuilder.AgregarJoin("INNER JOIN ventadetalles d ON d.IDVENTA = v.ID");
                //consultaBuilder.AgregarCriterio("v.ID=@ID");

                //Venta ventaConsulta = null;

                //venta = conn.Query<Venta, VentaDetalle, Venta>(consultaBuilder.ToString(),
                //    (ventasel, detalle) => {
                //        if (ventaConsulta == null)
                //        {
                //            ventaConsulta = ventasel;
                //            ventaConsulta.Detalles = new List<VentaDetalle>();
                //        }
                //        ventaConsulta.Detalles.Add(detalle);
                //        return ventaConsulta;
                //    }, new { ID = venta.Id }).FirstOrDefault();

            }
            catch (Exception ex)
            {
                ConexionBaseDeDatos.Error = ex.Message;
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
