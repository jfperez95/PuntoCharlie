using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Puntocharlie.Models
{
    public class Tecnico
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdPuntoServicio { get; set; }
        [ForeignKey("IdPuntoServicio")]
        public PuntoServicio PuntoServicio { get; set; }
    }
}
