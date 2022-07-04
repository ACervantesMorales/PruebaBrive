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
			Capa_de_Modelo.Producto producto = new Capa_de_Modelo.Producto();
			Capa_de_Modelo.Sucursal sucursal = new Capa_de_Modelo.Sucursal();
			Capa_de_Modelo.ProductoSucursal productoSucursal = new Capa_de_Modelo.ProductoSucursal();

			Capa_de_Modelo.Auxiliar auxiliarProductos = Capa_de_Negocio.Producto.ProductoGetBySucursal(0);
			Capa_de_Modelo.Auxiliar auxiliarSucursales = Capa_de_Negocio.Sucursal.GetAll();

			productoSucursal.Producto = new Capa_de_Modelo.Producto();
			productoSucursal.Producto.Productos = new List<object>();
			productoSucursal.Sucursal = new Capa_de_Modelo.Sucursal();
			productoSucursal.Sucursal.Sucursales = new List<object>();

			if (auxiliarProductos.Correct && auxiliarSucursales.Correct)
            {
				productoSucursal.Producto.Productos = auxiliarProductos.Objects;
				productoSucursal.Sucursal.Sucursales = auxiliarSucursales.Objects;
            }
			return View(productoSucursal);
        }

		[HttpPost]
		public ActionResult GetAll(Capa_de_Modelo.ProductoSucursal productoSucursal1)
        {
			Capa_de_Modelo.Producto producto = new Capa_de_Modelo.Producto();
			Capa_de_Modelo.Sucursal sucursal = new Capa_de_Modelo.Sucursal();
			Capa_de_Modelo.ProductoSucursal productoSucursal = new Capa_de_Modelo.ProductoSucursal();

			Capa_de_Modelo.Auxiliar auxiliarProductos = Capa_de_Negocio.Producto.ProductoGetBySucursal(productoSucursal1.Sucursal.IdSucursal);
			Capa_de_Modelo.Auxiliar auxiliarSucursales = Capa_de_Negocio.Sucursal.GetAll();

			productoSucursal.Producto = new Capa_de_Modelo.Producto();
			productoSucursal.Producto.Productos = new List<object>();
			productoSucursal.Sucursal = new Capa_de_Modelo.Sucursal();
			productoSucursal.Sucursal.Sucursales = new List<object>();

			if (auxiliarProductos.Correct && auxiliarSucursales.Correct)
			{
				productoSucursal.Producto.Productos = auxiliarProductos.Objects;
				productoSucursal.Sucursal.Sucursales = auxiliarSucursales.Objects;
			}
			return View(productoSucursal);
		}
        

		[HttpGet]
		public ActionResult Carrito(int? IdProducto)
		{
			Capa_de_Modelo.Auxiliar auxiliar = new Capa_de_Modelo.Auxiliar();
			auxiliar.Objects = new List<object>();
			if (IdProducto != null)
			{
				if (Session["Carrito"] == null)
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

				else
				{
					auxiliar.Objects = (List<Object>)Session["Carrito"];

					bool Existe = false;
					var indice = 0;

					foreach (Capa_de_Modelo.Venta ventaProducto in auxiliar.Objects)
					{
						if (ventaProducto.Producto.IdProducto == IdProducto)
						{

							Existe = true;
							indice = auxiliar.Objects.IndexOf(ventaProducto); 

						}
					}

					if (Existe == true)
					{
						foreach (Capa_de_Modelo.Venta ventaProducto in auxiliar.Objects)
						{
							ventaProducto.Cantidad = ventaProducto.Cantidad + 1;
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

			var indice = 0; 

			foreach (Capa_de_Modelo.Venta ventaProducto in auxiliar.Objects)
			{
				if (ventaProducto.Producto.IdProducto == IdProducto)
				{

					indice = auxiliar.Objects.IndexOf(ventaProducto); 

				}
			}

			auxiliar.Objects.RemoveAt(indice);
			Session["Carrito"] = auxiliar.Objects;

			return View("Carrito", auxiliar);
		}

		public ActionResult ModalCompra()
		{

			Session["Carrito"] = null;
			return PartialView("ValidationModal");
		}

		public ActionResult Sumar(int IdProducto)
		{
			Capa_de_Modelo.Auxiliar result = new Capa_de_Modelo.Auxiliar();

			result.Objects = (List<Object>)Session["Carrito"];

			foreach (Capa_de_Modelo.Venta ventaProducto in result.Objects) 
			{
				if (ventaProducto.Producto.IdProducto == IdProducto)
				{

					ventaProducto.Cantidad += 1;

				}
			}
			return View("Carrito", result);
		} 

		public ActionResult Restar(int IdProducto)
		{
			Capa_de_Modelo.Auxiliar result = new Capa_de_Modelo.Auxiliar();

			result.Objects = (List<Object>)Session["Carrito"];

			foreach (Capa_de_Modelo.Venta ventaProducto in result.Objects) 
			{

				if (ventaProducto.Producto.IdProducto == IdProducto)
				{
					ventaProducto.Cantidad -= 1;
				}
			}
			return View("Carrito", result);
		}

		[HttpGet]
		public ActionResult Comprar()
        {
			Session["Carrito"] = null;
			return RedirectToAction("GetAll");
        }

	}
}