using Puntocharlie.Data.Dtos;
using Puntocharlie.Models;

namespace Puntocharlie.Repositorio.IRepositorio
{
    public interface ITecnicoRepositorio
    {
        ICollection<TecnicoDto> GetTecnicos();
    }
}
