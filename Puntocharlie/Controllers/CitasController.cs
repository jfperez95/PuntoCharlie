using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Puntocharlie.Data.Dtos;
using Puntocharlie.Models;
using Puntocharlie.Repositorio.IRepositorio;

namespace Puntocharlie.Controllers
{
    [Route("api/citas")]
    [ApiController]
    public class CitasController : ControllerBase
    {
        private readonly ICitaRespositorio _ctRepo;
        private readonly IMapper _mapper;

        public CitasController(ICitaRespositorio ctRepo, IMapper mapper)
        {
            _ctRepo = ctRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCitas()
        {
            var listaCitas = _ctRepo.GetCitas();
            var listaCitasDto = new List<CitaDto>();
            foreach (var lista in listaCitas)
            {
                listaCitasDto.Add(_mapper.Map<CitaDto>(lista));
            }
            return Ok(listaCitasDto);
        }

        [HttpGet("{citaId:int}", Name = "GetCita")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCita(int citaId)
        {
            var itemCita = _ctRepo.GetCita(citaId);

            if (itemCita == null)
            {
                return NotFound();
            }

            var itemCitaDto = _mapper.Map<CitaDto>(itemCita);

            return Ok(itemCitaDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CrearCita([FromBody] CrearCitaDto crearCitaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (crearCitaDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_ctRepo.ExisteCita(crearCitaDto.FechaCita))
            {
                ModelState.AddModelError("", $"Ya hay una cita reservada en esta fecha y hora");
                return StatusCode(404, ModelState);
            }

            var cita = _mapper.Map<Cita>(crearCitaDto);

            if (!_ctRepo.CrearCita(cita))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro del cliente {cita.NombreCliente}");
                return StatusCode(404, ModelState);
            }

            return CreatedAtRoute("GetCita", new { citaId = cita.Id }, cita);
        }

        [HttpPut("{citaId:int}", Name = "ActualizarCita")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult ActualizarCita(int citaId, [FromBody] ActualizarCitaDto actualizarCitaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (actualizarCitaDto == null || citaId != actualizarCitaDto.Id)
            {
                return BadRequest(ModelState);
            }

            var citaExistente = _ctRepo.GetCita(citaId);

            if (citaExistente == null)
            {
                return NotFound($"No se encontro una cita con ID {citaId}");
            }

            var cita = _mapper.Map<Cita>(actualizarCitaDto);

            if (!_ctRepo.ActualizarCita(cita))
            {
                ModelState.AddModelError("", $"Algo salió mal actualizando el registro del cliente {cita.NombreCliente}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{citaId:int}", Name = "BorrarCita")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult BorrarCita(int citaId)
        {

            if (!_ctRepo.ExisteCita(citaId))
            {
                return NotFound($"No se encontro la cita con ID {citaId}");
            }

            var cita = _ctRepo.GetCitaDelete(citaId);

            if (!_ctRepo.BorrarCita(cita))
            {
                ModelState.AddModelError("", $"Algo salió mal borrando el registro del cliente {cita.NombreCliente}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
