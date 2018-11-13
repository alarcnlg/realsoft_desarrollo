using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.BaseDeDatos.Core
{
    class ConexionBaseDeDatos
    {
        public static string Error;

        private static MySqlConnection _instancia;

        public static MySqlConnection ConseguirConexion() {
            if (_instancia == null) {
                //_instancia = new MySqlConnection(@"Server=localhost;Database=DAP;Uid=root;Pwd=1234;ConvertZeroDateTime=True;");
                _instancia = new MySqlConnection(ModuloGeneral.ConnectionString);
            }
            return _instancia;
        }
    }
}
