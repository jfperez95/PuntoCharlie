using Puntocharlie.Data.Dtos;
using Puntocharlie.Models;

namespace Puntocharlie.Repositorio.IRepositorio
{
    public interface ICitaRespositorio
    {
        ICollection<CitaDto> GetCitas();
        CitaDto GetCita(int idCita);
        Cita GetCitaDelete(int idCita);
        bool ExisteCita(DateTime fecha);
        bool ExisteCita(int idCita);
        bool CrearCita(Cita cita);
        bool ActualizarCita(Cita cita);
        bool BorrarCita(Cita cita);
        bool Guardar();
    }
}
