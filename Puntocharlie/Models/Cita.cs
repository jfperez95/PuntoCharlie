using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Puntocharlie.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaCita { get; set; }
        public int IdTecnico { get; set; }
        [ForeignKey("IdTecnico")]
        public Tecnico Tecnico { get; set; }
    }
}
