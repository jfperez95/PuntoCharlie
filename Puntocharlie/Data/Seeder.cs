using Puntocharlie.Models;

namespace Puntocharlie.Data
{
    public class Seeder
    {
        public static async Task SeederAsync(ApplicationDbContext context)
        {
            if (!context.PuntoServicios.Any())  //Evita insertar puntos de servicio duplicados
            {
                context.PuntoServicios.AddRange(
                    new PuntoServicio { Nombre = "Punto 1", Direccion = "Calle 1", abreDomingo = true },
                    new PuntoServicio { Nombre = "Punto 2", Direccion = "Calle 2", abreDomingo = false },
                    new PuntoServicio { Nombre = "Punto 3", Direccion = "Calle 3", abreDomingo = false }
                );
            }

            if (!context.Tecnicos.Any())  //Evita insertar técnicos duplicados
            {
                context.Tecnicos.AddRange(
                    new Tecnico { Nombre = "Tecnico 1", IdPuntoServicio = 1 },
                    new Tecnico { Nombre = "Tecnico 2", IdPuntoServicio = 1 },
                    new Tecnico { Nombre = "Tecnico 3", IdPuntoServicio = 2 },
                    new Tecnico { Nombre = "Tecnico 4", IdPuntoServicio = 2 },
                    new Tecnico { Nombre = "Tecnico 5", IdPuntoServicio = 3 },
                    new Tecnico { Nombre = "Tecnico 6", IdPuntoServicio = 3 }
                );
            }

            await context.SaveChangesAsync();
        }
    }
}
