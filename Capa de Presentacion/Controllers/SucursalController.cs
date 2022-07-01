using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Capa_de_Presentacion.Controllers
{
    public class SucursalController : Controller
    {
        string URL = System.Configuration.ConfigurationManager.AppSettings["URL"];

        [HttpGet]
        public ActionResult GetAll()
        {
            Capa_de_Modelo.Sucursal sucursal = new Capa_de_Modelo.Sucursal();
            sucursal.Sucursales = new List<object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
                var responseTask = client.GetAsync("Sucursal/GetAll");
                responseTask.Wait();

                var resultAPI = responseTask.Result;
                if (resultAPI.IsSuccessStatusCode)
                {
                    var readTask = resultAPI.Content.ReadAsAsync<Capa_de_Modelo.Auxiliar>();
                    readTask.Wait();

                    foreach(var resultItem in readTask.Result.Objects)
                    {
                        Capa_de_Modelo.Sucursal sucursalItem = Newtonsoft.Json.JsonConvert.DeserializeObject<Capa_de_Modelo.Sucursal>(resultItem.ToString());
                        sucursal.Sucursales.Add(sucursalItem);
                    }
                }
            }
                return View(sucursal);
        }


        [HttpGet]
        public ActionResult Form(int? IdSucursal)
        {

            if(IdSucursal == null)
            {
                return View();
            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(URL);
                    var responseTask = client.GetAsync("Sucursal/GetById/" + IdSucursal);
                    responseTask.Wait();

                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<Capa_de_Modelo.Auxiliar>();
                        readTask.Wait();

                        Capa_de_Modelo.Sucursal sucursal = Newtonsoft.Json.JsonConvert.DeserializeObject<Capa_de_Modelo.Sucursal>(readTask.Result.Object.ToString());
                        return View(sucursal);
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Form(Capa_de_Modelo.Sucursal sucursal)
        {
            if (sucursal.IdSucursal == 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(URL);
                    var responseTask = client.PostAsJsonAsync<Capa_de_Modelo.Sucursal>("Sucursal/Add", sucursal);
                    responseTask.Wait();

                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Se agrego la sucursal correctamente";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Hubo un problema al intentar registrar la sucursal";
                    }
                }
            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(URL);
                    var responseTask = client.PostAsJsonAsync<Capa_de_Modelo.Sucursal>("Sucursal/Update/" + sucursal.IdSucursal, sucursal);
                    responseTask.Wait();

                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "Se actualizó correctamente la sucursal";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Hubo un problema al intentar actualizar la sucursal";
                    }
                }
            }
            return PartialView("Modal");
        }

        [HttpGet]
        public ActionResult Delete(int IdSucursal)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);

                var responseTask = client.GetAsync("Sucursal/Delete/" + IdSucursal);
                responseTask.Wait();

                var resultAPI = responseTask.Result;

                if (resultAPI.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "Se ha eliminado correctamente la sucursal";
                }
                else
                {
                    ViewBag.Mensaje = "Ha ocurrido un error al intentar eliminar la sucursal";
                }
            }
            return PartialView("Modal");
        }
    }
}