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
                     Descr = "Refinamiento de Petróleo Crudo",
                     Estado = true,
                     ValorHora = 150000
                 },
                 new Servicio
                 {
                     CodServicio = 12,
                     Descr = "Desulfuración de Combustibles",
                     Estado = true,
                     ValorHora = 75000
                 },
                 new Servicio
                 {
                     CodServicio = 13,
                     Descr = "Mantenimiento y Reparación de Equipos de Refinería",
                     Estado = true,
                     ValorHora = 90000
                 },
                   new Servicio
                   {
                       CodServicio = 14,
                       Descr = "Consultoría en Eficiencia Energética y Ambiental",
                       Estado = false,
                       ValorHora = 90000
                   });
        }
    }
}
