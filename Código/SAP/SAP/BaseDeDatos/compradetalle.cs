using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.BaseDeDatos
{
    [Table("comprasdetalles")]
    class CompraDetalle
    {
        public long Id { get; set; }
        public long IdCompra { get; set; }
        public long IdProducto { get; set; }
        public int Cantidad { get; set; }
        public float CostoUnidad { get; set; }

        [Write(false)]
        [Computed()]
        public Producto Producto { get; set; }
        
    }
}
