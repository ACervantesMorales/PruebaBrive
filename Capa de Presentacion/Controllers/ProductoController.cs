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
        public ActionResult Form(int? IdProducto)
        {
            ProductoService.ProductoServiceClient serviceUsuario = new ProductoService.ProductoServiceClient();
            Capa_de_Modelo.Producto producto = new Capa_de_Modelo.Producto();

            if (IdProducto == null)
            {
                return View(producto);
            }
            else
            {
                var auxiliar = serviceUsuario.GetById(IdProducto.Value);

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
            ProductoService.ProductoServiceClient serviceUsuario = new ProductoService.ProductoServiceClient();

            HttpPostedFileBase file = Request.Files["ImageProducto"];

            if (file.ContentLength > 0)
            {
                producto.Imagen = ConvertToBytes(file);
            }

            if (producto.IdProducto == 0)
            {
                var auxiliar = serviceUsuario.Add(producto);

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
                var auxiliar = serviceUsuario.Update(producto);

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
            ProductoService.ProductoServiceClient serviceUsuario = new ProductoService.ProductoServiceClient();
            var auxiliar = Capa_de_Negocio.Producto.Delete(IdProducto);

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

        public byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
            data = reader.ReadBytes((int)Imagen.ContentLength);

            return data;
        }
    }
}