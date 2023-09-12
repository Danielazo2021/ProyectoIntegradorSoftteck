using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.DataAccess.DataBaseSeeding
{
    public class ServicioSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servicio>().HasData(
                 new Servicio
                 {
                     CodServicio = 11,
                     Descr = "Electricidad",
                     Estado = true,
                     ValorHora = 1500
                 },
                 new Servicio
                 {
                     CodServicio = 12,
                     Descr = "Plomeria",
                     Estado = true,
                     ValorHora = 750
                 },
                 new Servicio
                 {
                     CodServicio = 13,
                     Descr = "Carpintería",
                     Estado = true,
                     ValorHora = 900
                 },
                   new Servicio
                   {
                       CodServicio = 14,
                       Descr = "Jardineria",
                       Estado = false,
                       ValorHora = 900
                   });
        }
    }
}
