using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Modelo
{
    public class ProductoSucursal
    {
        public int IdProductoSucursal { get; set; }
        public Capa_de_Modelo.Producto Producto { get; set; }
        public Capa_de_Modelo.Sucursal Sucursal { get; set; }
        public List<object> ProductosSucursal { get; set; }
        public List<object> Sucursales { get; set; }
    }
}
