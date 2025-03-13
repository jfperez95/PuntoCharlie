using System.ComponentModel.DataAnnotations;

namespace Puntocharlie.Data.Dtos
{
    public class CrearCitaDto
    {
        public string NombreCliente { get; set; }
        public DateTime FechaCita { get; set; }
        public int IdTecnico { get; set; }
    }
}
