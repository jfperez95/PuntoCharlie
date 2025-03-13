using Microsoft.EntityFrameworkCore;
using Puntocharlie.Data;
using Puntocharlie.Data.Dtos;
using Puntocharlie.Models;
using Puntocharlie.Repositorio.IRepositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Puntocharlie.Repositorio
{
    public class CitaRepositorio : ICitaRespositorio
    {
        private readonly ApplicationDbContext _bd;
        public CitaRepositorio(ApplicationDbContext db)
        {
            _bd = db;
        }

        public bool ActualizarCita(Cita cita)
        {
            var CitaExistente = _bd.Citas.Find(cita.Id);
            if (CitaExistente != null)
            {
                _bd.Entry(CitaExistente).CurrentValues.SetValues(cita);
            }
            else
            {
                _bd.Citas.Update(cita);
            }
            return Guardar();
        }

        public bool BorrarCita(Cita cita)
        {
            _bd.Citas.Remove(cita);
            return Guardar();
        }

        public bool CrearCita(Cita cita)
        {
            _bd.Citas.Add(cita);
            return Guardar();
        }

        public bool ExisteCita(DateTime fecha)
        {
            bool valor = _bd.Citas.Any(c => c.FechaCita == fecha);
            return valor;
        }

        public bool ExisteCita(int idCita)
        {
            return _bd.Citas.Any(c => c.Id == idCita);
        }

        public CitaDto GetCita(int idCita)
        {
            var respuesta = _bd.Citas.Include(c=> c.Tecnico).ThenInclude(t=> t.PuntoServicio).
                Where(c => c.Id == idCita).Select(c => new CitaDto
                {
                    Id = c.Id,
                    NombreCliente = c.NombreCliente,
                    FechaCita = c.FechaCita,
                    NombreTecnico = c.Tecnico.Nombre,
                    NombrePuntoServicio = c.Tecnico.PuntoServicio.Nombre
                }).FirstOrDefault();
            return respuesta;
        }

        public Cita GetCitaDelete(int idCita)
        {
            return _bd.Citas.FirstOrDefault(c => c.Id == idCita);
        }

        public ICollection<CitaDto> GetCitas()
        {
            return _bd.Citas.Include(c => c.Tecnico).ThenInclude(t => t.PuntoServicio).
                Select(c => new CitaDto
                {
                    Id = c.Id,
                    NombreCliente = c.NombreCliente,
                    FechaCita = c.FechaCita,
                    NombreTecnico = c.Tecnico.Nombre,
                    NombrePuntoServicio = c.Tecnico.PuntoServicio.Nombre
                }).ToList();
        }

        public bool Guardar()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }
    }
}
