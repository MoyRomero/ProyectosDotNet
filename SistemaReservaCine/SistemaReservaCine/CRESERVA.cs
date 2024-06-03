using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaReservaCine
{
    internal class CRESERVA
    {
        public int IDCliente { get; set; }
        public int IDFuncion { get; set;}
        public int IDTipoEntrada { get; set;}
        public int IDButaca { get; set;}
        public decimal Precio { get; set; }
        public string NombreComCliente { get; set; }
        public string NombreCine { get; set;}
        public string NombreSala { get; set;}
        public string TituloPelicula { get; set; }
        public string TipoEntradaNom { get; set; }
        public DateTime FechaFuncion { get; set; }
    }
}
