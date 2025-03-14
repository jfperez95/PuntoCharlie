using System.ComponentModel.DataAnnotations;

namespace Puntocharlie.Models
{
    public class PuntoServicio
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public bool abreDomingo { get; set; }
    }
}
