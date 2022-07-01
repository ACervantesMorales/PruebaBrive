using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Capa_de_Servicios_WebAPI.Controllers
{
    public class SucursalController : ApiController
    {
        [HttpGet]
        [Route("api/Sucursal/GetAll")]
        public IHttpActionResult GetAll()
        {
            Capa_de_Modelo.Auxiliar auxiliar = Capa_de_Negocio.Sucursal.GetAll();

            if (auxiliar.Correct)
            {
                return Content(HttpStatusCode.OK, auxiliar);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, auxiliar);
            }
        }

        [HttpPost]
        [Route("api/Sucursal/Add")]
        public IHttpActionResult Post([FromBody] Capa_de_Modelo.Sucursal sucursal)
        {
            Capa_de_Modelo.Auxiliar auxiliar = Capa_de_Negocio.Sucursal.Add(sucursal);

            if (auxiliar.Correct)
            {
                return Content(HttpStatusCode.OK, auxiliar);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, auxiliar);
            }
        }

        [HttpGet]
        [Route("api/Sucursal/GetById/{IdSucursal}")]
        public IHttpActionResult GetById(int IdSucursal)
        {
            Capa_de_Modelo.Auxiliar auxiliar = Capa_de_Negocio.Sucursal.GetById(IdSucursal);

            if (auxiliar.Correct)
            {
                return Content(HttpStatusCode.OK, auxiliar);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, auxiliar);
            }
        }

        [HttpGet]
        [Route("api/Sucursal/Delete/{IdSucursal}")]
        public IHttpActionResult Delete(int IdSucursal)
        {
            Capa_de_Modelo.Auxiliar auxiliar = Capa_de_Negocio.Sucursal.Delete(IdSucursal);

            if (auxiliar.Correct)
            {
                return Content(HttpStatusCode.OK, auxiliar);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, auxiliar);
            }
        }

        [HttpPost]
        [Route("api/Sucursal/Update/{IdSucursal}")]
        public IHttpActionResult Update(int IdSucursal, [FromBody] Capa_de_Modelo.Sucursal sucursal)
        {
            sucursal.IdSucursal = IdSucursal;
            Capa_de_Modelo.Auxiliar auxiliar = Capa_de_Negocio.Sucursal.Update(sucursal);

            if (auxiliar.Correct)
            {
                return Content(HttpStatusCode.OK, auxiliar);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, auxiliar);
            }
        }
    }
}