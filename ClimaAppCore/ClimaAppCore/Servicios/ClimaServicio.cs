using System.Net.Http;

namespace ClimaApiCore.Servicios
{
	public class ClimaServicio
	{
		private readonly HttpClient httpClient;

		public ClimaServicio(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<string> GetApiDataAsync(Dictionary<string, dynamic> queryParams, Dictionary<string, string> headers)
		{
			// Extract URL and parameters from queryParams
			string url = queryParams["url"];
			var parameters = queryParams["params"] as Dictionary<string, string>;

			// Build the full URL with query parameters
			if (parameters != null && parameters.Any())
			{
				var query = string.Join("&", parameters.Select(kvp => $"{kvp.Key}={kvp.Value}"));
				url = $"{url}?{query}";
			}

			var request = new HttpRequestMessage(HttpMethod.Get, url);

			// Add headers
			if (headers != null)
			{
				foreach (var header in headers)
				{
					request.Headers.Add(header.Key, header.Value);
				}
			}

			var response = await httpClient.SendAsync(request);

			response.EnsureSuccessStatusCode();

			return await response.Content.ReadAsStringAsync();
		}
	}
}
