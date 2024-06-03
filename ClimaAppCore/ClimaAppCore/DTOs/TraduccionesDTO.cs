namespace ClimaApiCore.DTOs
{
	public class Traduccion
	{
		public string translatedText { get; set; }
	}

	public class Data
	{
		public List<Traduccion> translations { get; set; }
	}

	public class TraduccionesDTO
	{
		public Data data { get; set; }
	}
}
