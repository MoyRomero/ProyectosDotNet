using ClimaApiCore.DTOs;
using System.Text.Json;
using System.Xml;

namespace ClimaApiCore.Servicios
{
	public class ipServicio
	{
		private readonly HttpClient httpClient;

		public ipServicio(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<dynamic> GetApiDataAsync(string Index)
		{
			try
			{
				var request = new HttpRequestMessage(HttpMethod.Get, "https://ipinfo.io/json?token=ipinfo.io");

				var response = await httpClient.SendAsync(request);

				response.EnsureSuccessStatusCode();

				if(Index == "Index")
				{
					return FormatearJson(await response.Content.ReadAsStringAsync());
					return response.Content.ReadAsStringAsync();
				}

				return FormatearJsonCoordenadas(await response.Content.ReadAsStringAsync());
			}
			catch (HttpRequestException e)
			{
				// Maneja errores de solicitud HTTP aquí
				Console.WriteLine($"Request error: {e.Message}");
				throw;
			}
			catch (Exception e)
			{
				// Maneja otros errores aquí
				Console.WriteLine($"An error occurred: {e.Message}");
				throw;
			}
		}

		internal ipDatosDTO FormatearJson(string json)
		{			
			return JsonSerializer.Deserialize<ipDatosDTO>(json);
		}

		internal CoordenadasDTO FormatearJsonCoordenadas(string json)
		{
			CoordenadasDTO coord = JsonSerializer.Deserialize<CoordenadasDTO>(json);
			coord.lat = coord.loc.Split(",")[0];
			coord.lon = coord.loc.Split(",")[1];
			return coord;

		}

		//public async Task<string> GetApiDataAsync()
		//{
		//	var request = new HttpRequestMessage(HttpMethod.Get, "https://ipinfo.io/json?token=ipinfo.io");

		//	var response = await httpClient.SendAsync(request);

		//	string respuesta =  response.StatusCode.ToString();

		//	response.EnsureSuccessStatusCode();

		//	return await response.Content.ReadAsStringAsync();
		//}
	}
}
