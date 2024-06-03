using ClimaApiCore.DTOs;
using ClimaApiCore.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ClimaApiCore.Controllers
{
	public class ClimaApiController : Controller
	{
		private readonly ClimaServicio climaServicio;
		private readonly ipServicio ipServicio;

		public ClimaApiController(ClimaServicio climaServicio, ipServicio ipServicio)
		{
			this.climaServicio = climaServicio;
			this.ipServicio = ipServicio;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.Coordenadas = await ipServicio.GetApiDataAsync(null);

			return View();
		}

		public async Task GetClimaActual(string Lon, string Lat)
		{
			//"lat", "16.876068121931812"
			//"lon", "-99.90764297530852"

			var queryParams = new Dictionary<string, dynamic>
				 {
					{ "url", "https://weatherbit-v1-mashape.p.rapidapi.com/current" },

					{ "params", new Dictionary<string,string>{
																{ "lat", Lat },
																{ "lon", Lon }
															 }
					}
				 };

			var headers = new Dictionary<string, string>
				{
					{ "X-RapidAPI-Key", "aea8e88785msh0ef263db4492f51p1037ccjsn2c8924655f88" },
					{ "X-RapidAPI-Host", "weatherbit-v1-mashape.p.rapidapi.com" }
				};

			//var data = await climaServicio.GetApiDataAsync(queryParams, headers);

			string data = "{\"count\":1,\"data\":[{\"app_temp\":40.4,\"aqi\":91,\"city_name\":\"Acapulco de Juárez\",\"clouds\":92,\"country_code\":\"MX\",\"datetime\":\"2024-05-29:21\",\"dewpt\":25.4,\"dhi\":105.28,\"dni\":836.91,\"elev_angle\":41.92,\"ghi\":657.76,\"gust\":3.6,\"h_angle\":45,\"lat\":16.8761,\"lon\":-99.9076,\"ob_time\":\"2024-05-29 22:27\",\"pod\":\"d\",\"precip\":0,\"pres\":976.5,\"rh\":66,\"slp\":1009.8315,\"snow\":0,\"solar_rad\":261.4,\"sources\":[\"analysis\",\"radar\",\"satellite\"],\"state_code\":\"12\",\"station\":\"MMAA\",\"sunrise\":\"12:04\",\"sunset\":\"01:08\",\"temp\":32.5,\"timezone\":\"America/Mexico_City\",\"ts\":1717021646,\"uv\":1.9376764,\"vis\":16,\"weather\":{\"icon\":\"a03d\",\"description\":\"Haze\",\"code\":721},\"wind_cdir\":\"WSW\",\"wind_cdir_full\":\"west-southwest\",\"wind_dir\":242,\"wind_spd\":3.6}]}";

			if (data != null)
			{
				ViewBag.DatosClima = FormatearDatos(data);
			}
			else
			{
				RedirectToAction("Error");
			}
		}

		internal DatosClimaActualDTO FormatearDatos(string CadenaDatos)
		{
			return JsonSerializer.Deserialize<DatosClimaActualDTO>(CadenaDatos);
		}

		[HttpPost]
		public async Task<IActionResult> Index(LatitudLongitudDTO LL)
		{
			if (!ModelState.IsValid)
			{
				return View(LL);
			}
			else
			{
				await GetClimaActual(LL.Longitud, LL.Latitud);

				return View(LL);
			}
		}
	}
}
