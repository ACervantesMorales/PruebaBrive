//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Capa_de_Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Venta
    {
        public int IdVenta { get; set; }
        public Nullable<int> IdProducto { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<decimal> Total { get; set; }
    
        public virtual Producto Producto { get; set; }
    }
}
