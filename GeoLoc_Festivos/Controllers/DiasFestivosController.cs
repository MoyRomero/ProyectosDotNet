using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GeoLoc_Festivos.Controllers
{
    public class DiasFestivosController : Controller
    {
        // GET: DiasFestivos
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> ObtenerDiasFestivos(string CodigoPais)
        {
            if(CodigoPais == null || CodigoPais.Length > 2 || CodigoPais == "" || CodigoPais == " ")
            {
                return Json("Error al realizar la consulta, Codigo de país enviado: " + CodigoPais, JsonRequestBehavior.AllowGet);
            }
            using(HttpClient client = new HttpClient())
            {
                try
                {
                    string UrlApi = $"https://date.nager.at/api/v3/PublicHolidays/2023/{CodigoPais}";

                    HttpResponseMessage respuesta = await client.GetAsync(UrlApi);

                    if(respuesta.IsSuccessStatusCode)
                    {
                        string contenido = await respuesta.Content.ReadAsStringAsync();

                        return Json(contenido, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json($"Error al comunicarse con la API: {respuesta}");
                    }
                }
                catch (Exception ex)
                {
                    return Json("Ocurrió un Error." + ex, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}