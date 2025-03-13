using Puntocharlie.Data;
using Puntocharlie.Data.Dtos;
using Puntocharlie.Repositorio.IRepositorio;

namespace Puntocharlie.Repositorio
{
    public class PuntoServicioRepositorio:IPuntoServicioRepositorio
    {
        private readonly ApplicationDbContext _bd;
        public PuntoServicioRepositorio(ApplicationDbContext db)
        {
            _bd = db;
        }

        public ICollection<PuntoServicioDto> GetPuntosServicio()
        {
            return _bd.PuntoServicios.Select(p => new PuntoServicioDto
            {
                Id = p.Id,
                Nombre = p.Nombre
            }).OrderBy(p => p.Nombre).ToList();
        }
    }
}
