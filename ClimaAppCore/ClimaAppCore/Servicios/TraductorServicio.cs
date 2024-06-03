namespace ClimaApiCore.Servicios
{
	public class TraductorServicio
	{
		private readonly HttpClient httpClient;

		public TraductorServicio(HttpClient httpClient)
        {
			this.httpClient = httpClient;
		}

		public async Task<string> PostTraducirAsync(Dictionary<string, string> queryParams, Dictionary<string, string> headers)
		{
			// URL de la API
			string url = "https://google-translate1.p.rapidapi.com/language/translate/v2";

			// Crear el contenido de la solicitud
			var content = new FormUrlEncodedContent(queryParams);

			// Crear la solicitud
			var request = new HttpRequestMessage(HttpMethod.Post, url)
			{
				Content = content
			};

			// Añadir encabezados
			if (headers != null)
			{
				foreach (var header in headers)
				{
					if (header.Key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
					{
						request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(header.Value);
					}
					else if (header.Key.Equals("Accept-Encoding", StringComparison.OrdinalIgnoreCase))
					{
						request.Headers.AcceptEncoding.ParseAdd(header.Value);
					}
					else
					{
						request.Headers.Add(header.Key, header.Value);
					}
				}
			}

			//return "";

			var response = await httpClient.SendAsync(request);
			response.EnsureSuccessStatusCode();
			
			return await response.Content.ReadAsStringAsync();
		}
	}
}

