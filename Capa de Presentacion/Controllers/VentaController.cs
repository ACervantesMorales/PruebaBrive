using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Capa_de_Presentacion.Controllers
{
    public class VentaController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ProductoService.ProductoServiceClient serviceUsuario = new ProductoService.ProductoServiceClient();
            var auxiliar = serviceUsuario.GetAll();

            Capa_de_Modelo.Producto producto = new Capa_de_Modelo.Producto();

            if (auxiliar.Correct)
            {
                producto.Productos = auxiliar.Objects.ToList();
            }

            return View(producto);
        }

		[HttpGet]
		public ActionResult Carrito(int? IdProducto)//int IdProducto
		{
			Capa_de_Modelo.Auxiliar auxiliar = new Capa_de_Modelo.Auxiliar();
			auxiliar.Objects = new List<object>();
			if (IdProducto != null)
			{
				if (Session["Carrito"] == null)
				{ //Inicia sesion para agregar producto al carrito 

					Capa_de_Modelo.Venta ventaProducto = new Capa_de_Modelo.Venta();

					ventaProducto.Producto = new Capa_de_Modelo.Producto();
					ventaProducto.Producto.IdProducto = IdProducto.Value;

					ventaProducto.Cantidad = 1;

					Capa_de_Modelo.Auxiliar resultProducto = Capa_de_Negocio.Producto.GetById(IdProducto.Value);

					if (resultProducto.Correct)
					{
						ventaProducto.Producto = (Capa_de_Modelo.Producto)resultProducto.Object;

						//result.Objects = new List<object>();
						auxiliar.Objects.Add(ventaProducto);
					}

					Session["Carrito"] = auxiliar.Objects;
				}

				else
				{// comprobar si ya existe informacion en el carrito
					auxiliar.Objects = (List<Object>)Session["Carrito"];

					bool Existe = false;
					var indice = 0; //variable para el index

					foreach (Capa_de_Modelo.Venta ventaProducto in auxiliar.Objects)
					{// foreach que recorre el objeto venta producto
						if (ventaProducto.Producto.IdProducto == IdProducto)
						{// if que compara el id de el producto con el de ventaproducto

							Existe = true;
							indice = auxiliar.Objects.IndexOf(ventaProducto);//index 

						}
					}

					if (Existe == true)
					{
						foreach (Capa_de_Modelo.Venta ventaProducto in auxiliar.Objects)
						{
							ventaProducto.Cantidad = ventaProducto.Cantidad + 1;//contador 
						}

					}

					else
					{

						Capa_de_Modelo.Venta ventaProducto = new Capa_de_Modelo.Venta();

						ventaProducto.Producto = new Capa_de_Modelo.Producto();
						ventaProducto.Producto.IdProducto = IdProducto.Value;
						ventaProducto.Cantidad = 1;


						Capa_de_Modelo.Auxiliar resultProducto = Capa_de_Negocio.Producto.GetById(IdProducto.Value);

						if (resultProducto.Correct)
						{
							ventaProducto.Producto = (Capa_de_Modelo.Producto)resultProducto.Object;

							auxiliar.Objects.Add(ventaProducto);

						}

						Session["Carrito"] = auxiliar.Objects;

					}

				}
			}

			return View(auxiliar);
		}

		public ActionResult Eliminar(int IdProducto)
		{
			Capa_de_Modelo.Auxiliar auxiliar = new Capa_de_Modelo.Auxiliar();
			auxiliar.Objects = (List<Object>)Session["Carrito"];

			var indice = 0; //variable para el index

			foreach (Capa_de_Modelo.Venta ventaProducto in auxiliar.Objects)
			{// foreach que recorre el objeto venta producto
				if (ventaProducto.Producto.IdProducto == IdProducto)
				{// if que compara el id de el producto con el de ventaproducto

					indice = auxiliar.Objects.IndexOf(ventaProducto);//index 

				}
			}

			auxiliar.Objects.RemoveAt(indice);
			Session["Carrito"] = auxiliar.Objects;

			return View("Carrito", auxiliar);
		}
	}
}