using Microsoft.EntityFrameworkCore;
using Puntocharlie.Models;

namespace Puntocharlie.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PuntoServicio> PuntoServicios { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }
        public DbSet<Cita> Citas { get; set; }
    }
}
