using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ClimaApiCore.DTOs
{
    public class TextoParaTraducir
    {
        [Display(Name = "TEXTO PARA TRADUCIR")]
        [MaxLength(2, ErrorMessage = "El texto debe tener menos de 2 carctéres.")]
        [MinLength(1, ErrorMessage = "El texto no puede ser vacío.")]
        [Required(ErrorMessage = "El texto no puede ser vacío.")]
        public string? text { get; set; }
    }
}