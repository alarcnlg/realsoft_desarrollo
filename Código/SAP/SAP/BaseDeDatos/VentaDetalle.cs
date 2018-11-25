using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.BaseDeDatos
{
    [Table("ventasdetalles")]
    class VentaDetalle
    {
        public long Id { get; set; }
        public long IdVenta { get; set; }
        public long IdProducto { get; set; }
        public int Cantidad { get; set; }
        public float PrecioUnidad { get; set; }
        public float Total { get; set; }

        [Write(false)]
        [Computed()]
        public Producto Producto { get; set; }
    }
}
