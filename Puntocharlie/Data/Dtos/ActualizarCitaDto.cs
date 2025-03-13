namespace Puntocharlie.Data.Dtos
{
    public class ActualizarCitaDto
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaCita { get; set; }
        public int IdTecnico { get; set; }
    }
}
