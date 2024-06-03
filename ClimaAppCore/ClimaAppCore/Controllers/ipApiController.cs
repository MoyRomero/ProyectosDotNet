using ClimaApiCore.DTOs;
using ClimaApiCore.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ClimaApiCore.Controllers
{
	public class ipApiController : Controller
	{
		private readonly ipServicio ipServicio;

		public ipApiController(ipServicio ipServicio)
		{
			this.ipServicio = ipServicio;
		}

		public async Task<IActionResult> Index()
		{
			return View(await ipServicio.GetApiDataAsync("Index"));
		}

		public async Task<ipDatosDTO> ObtenerDatosIp()
		{
			return await ipServicio.GetApiDataAsync("Index");
		}

	}
}
