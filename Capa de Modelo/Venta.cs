using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Modelo
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public Capa_de_Modelo.Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public List<object> Ventas { get; set; }
    }
}
