using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace ClimaApiCore.Validaciones
{
	public class ValidacionLatLong : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value is string stringValue)
			{
				if (!double.TryParse(stringValue, out double result))
				{
					return new ValidationResult($"El valor: {stringValue} no es válido.");
				}
			}

			return ValidationResult.Success;
		}
	}
}
