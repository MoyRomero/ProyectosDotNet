using System.ComponentModel.DataAnnotations;

namespace ClimaApiCore.DTOs
{
	public class ipDatosDTO
	{
        [Display(Name="DIRECCIÓN IP")]
        public string ip { get; set; }


        [Display(Name="NOMBRE DEL HOST")]
        public string hostname { get; set; }


        [Display(Name="CIUDAD")]
        public string city { get; set; }


        [Display(Name="REGIÓN")]
        public string region { get; set; }


        [Display(Name="PAÍS")]
        public string country { get; set; }


        [Display(Name="LON, LAT")]
        public string loc { get; set; }


        [Display(Name="CÓDIGO POSTAL")]
        public string postal { get; set; }


        [Display(Name="ZONA HORARIA")]
        public string timezone { get; set; }
    }
}
