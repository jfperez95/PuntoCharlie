using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Puntocharlie.Data.Dtos;
using Puntocharlie.Repositorio.IRepositorio;

namespace Puntocharlie.Controllers
{
    [Route("api/puntoservicio")]
    [ApiController]
    public class PuntoServicioController : ControllerBase
    {
        private readonly IPuntoServicioRepositorio _psRepo;
        private readonly IMapper _mapper;

        public PuntoServicioController(IPuntoServicioRepositorio psRepo, IMapper mapper)
        {
            _psRepo = psRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCitas()
        {
            var listaPuntosServicio = _psRepo.GetPuntosServicio();
            var listaPuntosServicioDto = new List<PuntoServicioDto>();
            foreach (var lista in listaPuntosServicio)
            {
                listaPuntosServicioDto.Add(_mapper.Map<PuntoServicioDto>(lista));
            }
            return Ok(listaPuntosServicioDto);
        }
    }
}
