using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Puntocharlie.Data.Dtos;
using Puntocharlie.Repositorio.IRepositorio;

namespace Puntocharlie.Controllers
{
    [Route("api/tecnico")]
    [ApiController]
    public class TecnicosController : ControllerBase
    {

        private readonly ITecnicoRepositorio _tecRepo;
        private readonly IMapper _mapper;

        public TecnicosController(ITecnicoRepositorio tecRepo, IMapper mapper)
        {
            _tecRepo = tecRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCitas()
        {
            var listaTecnicos = _tecRepo.GetTecnicos();
            var listaTecnicosDto = new List<TecnicoDto>();
            foreach (var lista in listaTecnicos)
            {
                listaTecnicosDto.Add(_mapper.Map<TecnicoDto>(lista));
            }
            return Ok(listaTecnicosDto);
        }
    }
}
