using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocio
{
    public class ProductoSucursal
    {
        public static Capa_de_Modelo.Auxiliar ProductoGetBySucursal(int? IdSucursal)
        {
            Capa_de_Modelo.Auxiliar auxiliar = new Capa_de_Modelo.Auxiliar();
            try
            {
                using (Capa_de_Datos.PruebaBriveEntities1 context = new Capa_de_Datos.PruebaBriveEntities1())
                {
                    var query = context.ProductoGetByIdSucursal(IdSucursal).ToList();

                    if(query != null)
                    {
                        auxiliar.Objects = new List<object>();
                        foreach (var obj in query) 
                        {
                            Capa_de_Modelo.ProductoSucursal productoSucursal = new Capa_de_Modelo.ProductoSucursal();
                            productoSucursal.Producto = new Capa_de_Modelo.Producto();
                            productoSucursal.Producto.IdProducto = obj.IdProducto;
                            productoSucursal.Producto.Nombre = obj.Nombre1;
                            productoSucursal.Producto.Precio = obj.Precio;
                            productoSucursal.Producto.Descripcion = obj.Descripcion;
                            productoSucursal.Producto.Stock = obj.Stock;
                            productoSucursal.Sucursal = new Capa_de_Modelo.Sucursal();
                            productoSucursal.Sucursal.IdSucursal = obj.IdSucursal.Value;
                            productoSucursal.Sucursal.Nombre = obj.Nombre;
                            productoSucursal.Sucursal.Ubicacion = obj.Ubicacion;

                            auxiliar.Objects.Add(productoSucursal);
                        }
                        auxiliar.Correct = true;
                    }
                    else
                    {
                        auxiliar.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                auxiliar.Correct = false;
                auxiliar.ErrorMessage = ex.Message;
                auxiliar.Ex = ex;
            }
            return auxiliar;
        }
    }
}
