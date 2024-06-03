using ClimaApiCore.DTOs;
using ClimaApiCore.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ClimaApiCore.Controllers
{
    public class TraductorController : Controller
	{
		private readonly TraductorServicio traductorServicio;

		public TraductorController(TraductorServicio traductorServicio)
        {
			this.traductorServicio = traductorServicio;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(TextoParaTraducir Texto)
		{
			if (!ModelState.IsValid)
			{
				return View(Texto);
			}
			else
			{
				ViewBag.TextoTraducido = await PostTraducirTexto(Texto.text);

				return View(Texto);
			}
		}

		public async Task<TraduccionesDTO> PostTraducirTexto(string Texto)
		{
			// Asigna un valor de prueba a Texto

			var queryParams = new Dictionary<string, string>
			{
				{ "q", Texto },
				{ "target", "es" },
				{ "source", "en" }
			};

			var headers = new Dictionary<string, string>
			{
				{ "Content-Type", "application/x-www-form-urlencoded" },
				{ "Accept-Encoding", "gzip" },
				{ "X-RapidAPI-Key", "aea8e88785msh0ef263db4492f51p1037ccjsn2c8924655f88" },
				{ "X-RapidAPI-Host", "google-translate1.p.rapidapi.com" }
			};

			string data = await traductorServicio.PostTraducirAsync(queryParams, headers);

			return JsonSerializer.Deserialize<TraduccionesDTO>(data);
		}
	}
}
