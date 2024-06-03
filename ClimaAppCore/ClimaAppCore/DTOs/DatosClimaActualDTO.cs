using System.ComponentModel.DataAnnotations;

namespace ClimaApiCore.DTOs
{
	public class DatosClimaActualDTO
	{
		public int count { get; set; }
		public List<ClimaData> data { get; set; }
	}

	public class ClimaData
	{
		[Display(Name = "CIUDAD")]
		public string city_name { get; set; }


		[Display(Name = "CÓDIGO PAÍS")]
		public string country_code { get; set; }


		[Display(Name = "FECHA")]
		public string datetime { get; set; }


		[Display(Name = "TEMPERATURA")]
		public float temp { get; set; }


		[Display(Name = "ZONA HORARIA")]
		public string timezone { get; set; }
	}
}
