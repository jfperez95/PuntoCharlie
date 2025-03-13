using AutoMapper;
using Puntocharlie.Data.Dtos;
using Puntocharlie.Models;

namespace Puntocharlie.PuntoChaelieMapper
{
    public class PuntoCharlieMapper : Profile
    {   
        public PuntoCharlieMapper()
        {
            CreateMap<Cita, CitaDto>().ReverseMap();
            CreateMap<Cita, CrearCitaDto>().ReverseMap();
            CreateMap<Cita, ActualizarCitaDto>().ReverseMap();
            CreateMap<Tecnico, TecnicoDto>().ReverseMap();
            CreateMap<PuntoServicio, PuntoServicioDto>().ReverseMap();

        }
    }
}
