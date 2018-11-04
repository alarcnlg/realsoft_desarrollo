using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAP.Clases
{
    class ArchivoConfiguracion
    {
        public string Servidor { get; set; }
        public int Puerto { get; set; }
        public string BaseDeDatos { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }

        private string _ruta;

        public ArchivoConfiguracion() {
            _ruta = Application.StartupPath + @"\sap.conf";

            Servidor = "localhost";
            Puerto = 3306;
            BaseDeDatos = "SAP";
            Usuario = "root";
            Password = "";
        }

        public bool EsExistente() {
            return File.Exists(_ruta);
        }

        public bool GuardarDatos() {
            FileStream fileStream = null;
            BinaryWriter binaryWriter = null;
            try
            {
                fileStream = new FileStream(_ruta, FileMode.OpenOrCreate, FileAccess.Write);
                binaryWriter = new BinaryWriter(fileStream);

                binaryWriter.Write(Servidor);
                binaryWriter.Write(Puerto);
                binaryWriter.Write(BaseDeDatos);
                binaryWriter.Write(Usuario);
                binaryWriter.Write(Password);

            }
            catch
            {
                return false;
            }
            finally {
                if (fileStream != null) fileStream.Close();
                if (binaryWriter != null) binaryWriter.Close();
            }
            return true;
        }

        public bool CargarDatos()
        {
            if (!EsExistente()) return false;
            FileStream fileStream = null;
            BinaryReader binaryReader = null;
            try
            {
                fileStream = new FileStream(_ruta, FileMode.Open, FileAccess.Read);
                binaryReader = new BinaryReader(fileStream);

                Servidor = binaryReader.ReadString();
                Puerto = binaryReader.ReadInt32();
                BaseDeDatos = binaryReader.ReadString();
                Usuario = binaryReader.ReadString();
                Password = binaryReader.ReadString();

            }
            catch
            {
                return false;
            }
            finally
            {
                if (fileStream != null) fileStream.Close();
                if (binaryReader != null) binaryReader.Close();
            }
            return true;
        }

        public string CrearConnectionString() {
            return $@"Server={Servidor};Database={BaseDeDatos};Uid={Usuario};Pwd={Password};ConvertZeroDateTime=True;";
        }

    }
}
