using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_de_Presentacion.Controllers
{
    public class ProductoController : Controller
    {

        [HttpGet]
        public ActionResult GetAll()
        {
            Capa_de_Modelo.Auxiliar auxiliar = Capa_de_Negocio.Producto.GetAll();
            Capa_de_Modelo.Producto producto = new Capa_de_Modelo.Producto();

            if (auxiliar.Correct)
            {
                producto.Productos = auxiliar.Objects;
            }

            return View(producto);
        }

        [HttpGet]
        public ActionResult Form(int? IdProducto)
        {
            Capa_de_Modelo.Auxiliar auxiliar = new Capa_de_Modelo.Auxiliar();
            Capa_de_Modelo.Producto producto = new Capa_de_Modelo.Producto();

            if (IdProducto == null)
            {
                return View();
            }
            else
            {
                auxiliar = Capa_de_Negocio.Producto.GetById(IdProducto.Value);

                if (auxiliar.Correct)
                {
                    producto = (Capa_de_Modelo.Producto)auxiliar.Object;
                    return View(producto);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Form(Capa_de_Modelo.Producto producto)
        {
            Capa_de_Modelo.Auxiliar auxiliar = new Capa_de_Modelo.Auxiliar();
            
            IFormFile file = Request.Form.Files["ImageUser"];

            if (file != null)
            {
                byte[] ImagenBytes = ConvertToBytes(file);
                producto.Imagen = Convert.ToBase64String(ImagenBytes);
            }

            if (producto.IdProducto == 0)
            {
                auxiliar = Capa_de_Negocio.Producto.Add(producto);

                if (auxiliar.Correct)
                {
                    ViewBag.Mensaje = "Se ha registrado correctamente el producto";
                }
                else
                {
                    ViewBag.Mensaje = "Ha ocurrido un problema al intentar registrar el producto: " + auxiliar.ErrorMessage;
                }
            }
            else
            {
                auxiliar = Capa_de_Negocio.Producto.Update(producto);

                if (auxiliar.Correct)
                {
                    ViewBag.Mensaje = "Se ha actualizado correctamente el producto";
                }
                else
                {
                    ViewBag.Mensaje = "Ha ocurrido un problema al intentar actualizar el producto: " + auxiliar.ErrorMessage;
                }
            }

            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int IdProducto)
        {
            Capa_de_Modelo.Auxiliar auxiliar = Capa_de_Negocio.Producto.Delete(IdProducto);

            if (auxiliar.Correct)
            {
                ViewBag.Mensaje = "Se ha eliminado correctamente el producto";
            }
            else
            {
                ViewBag.Mensaje = "Ha ocurrido un problema al intentar eliminar el producto: " + auxiliar.ErrorMessage;
            }

            return PartialView("Modal");
        }


        public static byte[] ConvertToBytes(IFormFile imagen)
        {
            using var fileStream = imagen.OpenReadStream();

            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);

            return bytes;
        }
    }
}