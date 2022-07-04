using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capa_de_Presentacion.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(Capa_de_Modelo.Usuario usuario)
        {
            Capa_de_Modelo.Auxiliar auxiliar = Capa_de_Negocio.Usuario.GetByUserName(usuario.UserName);

            Capa_de_Modelo.Usuario usuario1 = new Capa_de_Modelo.Usuario();
            usuario1 = ((Capa_de_Modelo.Usuario)auxiliar.Object);

            if (auxiliar.Correct) { 
                if(usuario.Password == usuario1.Password)
                {
                    Session["Usuario"] = usuario1;
                    if (usuario1.Rol.IdRol == 1)
                    {
                        Capa_de_Modelo.Usuario usuario3 = new Capa_de_Modelo.Usuario();
                        usuario3 = (Capa_de_Modelo.Usuario)(Session["Usuario"]);
                        return RedirectToAction("GetAll", "Producto");
                    }
                    else
                    {
                        return RedirectToAction("GetAll", "Venta");
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Los datos del usuario son incorrectos.";
                    return RedirectToAction("Login");
                }
            }
            else
            {
                ViewBag.Mensaje = "Los datos del usuario son incorrectos.";
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public ActionResult CerrarSesion()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Login");
        }
    }
}