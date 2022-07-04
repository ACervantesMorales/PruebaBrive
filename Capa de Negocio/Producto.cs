using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocio
{
    public class Producto
    {
        public static Capa_de_Modelo.Auxiliar Add(Capa_de_Modelo.Producto producto)
        {
            Capa_de_Modelo.Auxiliar auxiliar = new Capa_de_Modelo.Auxiliar();
            try
            {
                using (Capa_de_Datos.PruebaBriveEntities1 context = new Capa_de_Datos.PruebaBriveEntities1()) 
                {
                    var query = context.ProductoAdd(producto.Nombre, producto.Precio, producto.Descripcion, producto.Stock, producto.Imagen);

                    if(query > 0)
                    {
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

        public static Capa_de_Modelo.Auxiliar Update(Capa_de_Modelo.Producto producto)
        {
            Capa_de_Modelo.Auxiliar auxiliar = new Capa_de_Modelo.Auxiliar();
            try
            {
                using (Capa_de_Datos.PruebaBriveEntities1 context = new Capa_de_Datos.PruebaBriveEntities1())
                {
                    var query = context.ProductoUpdate(producto.IdProducto, producto.Nombre, producto.Precio, producto.Stock, producto.Descripcion, producto.Imagen);

                    if(query > 0)
                    {
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

        public static Capa_de_Modelo.Auxiliar Delete(int IdProducto)
        {
            Capa_de_Modelo.Auxiliar auxiliar = new Capa_de_Modelo.Auxiliar();
            try
            {
                using (Capa_de_Datos.PruebaBriveEntities1 context = new Capa_de_Datos.PruebaBriveEntities1())
                {
                    var query = context.ProductoDelete(IdProducto);

                    if(query > 0)
                    {
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

        public static Capa_de_Modelo.Auxiliar GetAll()
        {
            Capa_de_Modelo.Auxiliar auxiliar = new Capa_de_Modelo.Auxiliar();
            try
            {
                using (Capa_de_Datos.PruebaBriveEntities1 context = new Capa_de_Datos.PruebaBriveEntities1())
                {
                    var query = context.ProductoGetAll().ToList();

                    if(query != null)
                    {
                        auxiliar.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            Capa_de_Modelo.Producto producto = new Capa_de_Modelo.Producto();
                            producto.IdProducto = obj.IdProducto;
                            producto.Nombre = obj.Nombre;
                            producto.Precio = obj.Precio;
                            producto.Descripcion = obj.Descripcion;
                            producto.Stock = obj.Stock;
                            producto.Imagen = obj.Imagen;

                            auxiliar.Objects.Add(producto);
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

        public static Capa_de_Modelo.Auxiliar GetById(int IdProducto)
        {
            Capa_de_Modelo.Auxiliar auxiliar = new Capa_de_Modelo.Auxiliar();
            try
            {
                using (Capa_de_Datos.PruebaBriveEntities1 context = new Capa_de_Datos.PruebaBriveEntities1())
                {
                    var query = context.ProductoGetById(IdProducto).FirstOrDefault();

                    if(query != null)
                    {
                        Capa_de_Modelo.Producto producto = new Capa_de_Modelo.Producto();
                        producto.IdProducto = query.IdProducto;
                        producto.Nombre = query.Nombre;
                        producto.Precio = query.Precio;
                        producto.Descripcion = query.Descripcion;
                        producto.Stock = query.Stock;
                        producto.Imagen = query.Imagen;

                        auxiliar.Object = producto;
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
        public static Capa_de_Modelo.Auxiliar ProductoGetBySucursal(int? IdSucursal)
        {
            Capa_de_Modelo.Auxiliar auxiliar = new Capa_de_Modelo.Auxiliar();
            try
            {
                using (Capa_de_Datos.PruebaBriveEntities1 context = new Capa_de_Datos.PruebaBriveEntities1())
                {
                    var query = context.GetProductoBySucursal(IdSucursal).ToList();

                    if (query != null)
                    {
                        auxiliar.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            Capa_de_Modelo.Producto producto = new Capa_de_Modelo.Producto();
                            producto.IdProducto = obj.IdProducto;
                            producto.Nombre = obj.Nombre;
                            producto.Precio = obj.Precio;
                            producto.Descripcion = obj.Descripcion;
                            producto.Stock = obj.Stock;
                            producto.Imagen = obj.Imagen;

                            auxiliar.Objects.Add(producto);
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
