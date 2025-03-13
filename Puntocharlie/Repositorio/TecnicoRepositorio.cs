using Puntocharlie.Data;
using Puntocharlie.Data.Dtos;
using Puntocharlie.Repositorio.IRepositorio;

namespace Puntocharlie.Repositorio
{
    public class TecnicoRepositorio : ITecnicoRepositorio
    {
        private readonly ApplicationDbContext _bd;
        public TecnicoRepositorio(ApplicationDbContext db)
        {
            _bd = db;
        }

        public ICollection<TecnicoDto> GetTecnicos()
        {
            return _bd.Tecnicos.Select(t=> new TecnicoDto
            {
                Id = t.Id,
                Nombre = t.Nombre
            }).OrderBy(t => t.Nombre).ToList();
        }
    }
}
