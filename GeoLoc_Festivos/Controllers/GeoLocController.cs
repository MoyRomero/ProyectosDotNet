using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GeoLoc_Festivos.Controllers
{
    public class GeoLocController : Controller
    {
        // GET: GeoLoc
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> ConsumirApi(string MiDireccionIp)
        {
            using(HttpClient client = new HttpClient())
            {
                string UrlApi = $"http://ip-api.com/json/{MiDireccionIp}";

                try
                {
                    HttpResponseMessage respuesta = await client.GetAsync(UrlApi);

                    if(respuesta.IsSuccessStatusCode)
                    {
                        string contenido = await respuesta.Content.ReadAsStringAsync();

                        return Json(contenido, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("Error al obtener datos de la API GeoLoc." + respuesta, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json("Error al comunicarse con la API GeoLoc" + ex,JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}