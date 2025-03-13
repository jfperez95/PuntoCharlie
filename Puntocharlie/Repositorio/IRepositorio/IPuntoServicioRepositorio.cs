using Puntocharlie.Data.Dtos;

namespace Puntocharlie.Repositorio.IRepositorio
{
    public interface IPuntoServicioRepositorio
    {
        ICollection<PuntoServicioDto> GetPuntosServicio();
    }
}
