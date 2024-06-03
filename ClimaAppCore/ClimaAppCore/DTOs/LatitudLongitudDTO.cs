using ClimaApiCore.Validaciones;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Runtime.InteropServices;

namespace ClimaApiCore.DTOs
{
	public class LatitudLongitudDTO
	{
		[Required(ErrorMessage = "Debe ingresar una Longitud.")]
		[ValidacionLatLong]
		[Display(Name = "LONGITUD")]
		public string? Longitud { get; set; }


		[Required(ErrorMessage = "Debe ingresar una Latitud.")]
		[ValidacionLatLong]
		[Display(Name = "LATITUD")]
		public string? Latitud { get; set; }
	}
}
