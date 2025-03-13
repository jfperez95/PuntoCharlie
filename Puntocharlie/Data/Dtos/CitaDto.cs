using Puntocharlie.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Puntocharlie.Data.Dtos
{
    public class CitaDto
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaCita { get; set; }
        public string NombreTecnico { get; set; }
        public string NombrePuntoServicio { get; set; }
    }
}
