using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAP.BaseDeDatos;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace SAP.Facturacion
{
    class CFDI
    {
        public const int RESULT_CORRECTO = 0;
        public const int RESULT_ERROR_GENERAL = 1;
        public const int RESULT_ERROR_TIMBRADO = 2;

        private string _rutaXML;

        public CFDI() {
            _rutaXML = Application.StartupPath + @"\Data\_temp.xml";
        }

        public int GenerarYTimbrar(ref Factura factura, Venta venta) {

            string rutaCertificado = Application.StartupPath + @"\Data\CSD10_AAA010101AAA.cer";
            string rutaKey = Application.StartupPath + @"\Data\CSD10_AAA010101AAA.key";
            string clavePrivada = "12345678a";

            string inicio, fin, serie, numeroCertificado;
            SelloDigital.leerCER(rutaCertificado, out inicio, out fin, out serie, out numeroCertificado);

            //Llenamos la clase COMPROBANTE--------------------------------------------------------
            Comprobante comprobante = new Comprobante();
            comprobante.Version = "3.3";
            comprobante.Serie = "A";
            comprobante.Folio = "" + factura.Id;
            comprobante.Fecha = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            comprobante.FormaPago = "99";
            comprobante.NoCertificado = numeroCertificado;
            comprobante.SubTotal = (decimal)venta.Total;
            comprobante.Descuento = 1;
            comprobante.Moneda = "MXN";
            comprobante.Total = (decimal)venta.Total;
            comprobante.TipoDeComprobante = "I";
            comprobante.MetodoPago = "PUE";
            comprobante.LugarExpedicion = "20131";


            ComprobanteEmisor emisor = new ComprobanteEmisor();
            emisor.Rfc = "AAA010101AAA";
            emisor.Nombre = "Papeleria de S.A de C.V";
            emisor.RegimenFiscal = "601";

            ComprobanteReceptor receptor = new ComprobanteReceptor();
            receptor.Nombre = "Publico General";
            receptor.Rfc = "AAA010101AAA";
            receptor.UsoCFDI = "P01";

            comprobante.Emisor = emisor;
            comprobante.Receptor = receptor;

            List<ComprobanteConcepto> conceptos = new List<ComprobanteConcepto>();
            ComprobanteConcepto concepto = null;

            foreach (VentaDetalle detalle in venta.Detalles) {
                concepto = new ComprobanteConcepto();

                concepto.NoIdentificacion = "" + detalle.IdProducto;
                concepto.ClaveProdServ = "92111704";
                concepto.ClaveUnidad = "C81";
                concepto.Descripcion = detalle.Producto.Nombre;
                concepto.ValorUnitario = (decimal)detalle.PrecioUnidad;
                concepto.Cantidad = 1;
                concepto.Importe = (decimal)(detalle.PrecioUnidad * detalle.Cantidad);
                concepto.Descuento = 0;

                conceptos.Add(concepto);
            }

            //Se crea el archivo XML
            CrearXML(comprobante);

            string cadenaOriginal = "";
            string pathxsl = Application.StartupPath + @"Data\cadenaoriginal_3_3.xslt";
            System.Xml.Xsl.XslCompiledTransform transformador = new System.Xml.Xsl.XslCompiledTransform(true);
            transformador.Load(pathxsl);

            using (StringWriter sw = new StringWriter())
            {
                using (XmlWriter xwo = XmlWriter.Create(sw, transformador.OutputSettings))
                {
                    transformador.Transform(_rutaXML, xwo);
                    cadenaOriginal = sw.ToString();
                }
            }

            SelloDigital selloDigital = new SelloDigital();
            comprobante.Certificado = selloDigital.Certificado(rutaCertificado);
            comprobante.Sello = selloDigital.Sellar(cadenaOriginal, rutaKey, clavePrivada);

            CrearXML(comprobante);

            //Timbrado

            byte[] bytesXML = File.ReadAllBytes(_rutaXML);
            WsEmisionTimbrado33.wsResponseBO response = new WsEmisionTimbrado33.WsEmisionTimbrado33Client().EmitirTimbrar("AAA010101AAA.Test.User", "Prueba$1", 5906390, bytesXML);

            factura.IdVenta = venta.Id;
            factura.Fecha = Convert.ToDateTime(comprobante.Fecha);

            if (!response.isError)
            {
                File.WriteAllBytes(_rutaXML, response.XML);
                File.WriteAllBytes(Application.StartupPath + @"\documento.pdf", response.PDF);

                factura.ArchivoXML = response.XML;
                factura.ArchivoXML = response.PDF;

                return RESULT_CORRECTO;
            }
            else {
                return RESULT_ERROR_TIMBRADO;
            }
        }

        private void CrearXML(Comprobante comprobante)
        {
            //Se serealiza la clase para crear el archivo XML
            XmlSerializerNamespaces xmlNameSpace = new XmlSerializerNamespaces();
            xmlNameSpace.Add("cfdi", "http://www.sat.gob.mx/cfd/3");
            xmlNameSpace.Add("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
            xmlNameSpace.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");


            XmlSerializer oXmlSerializar = new XmlSerializer(typeof(Comprobante));

            string sXml = "";
            using (var sww = new StringWriterWithEncoding(Encoding.UTF8))
            {
                using (XmlWriter writter = XmlWriter.Create(sww))
                {
                    oXmlSerializar.Serialize(writter, comprobante, xmlNameSpace);
                    sXml = sww.ToString();
                }

            }
            File.WriteAllText(_rutaXML, sXml);
        }


    }
}
