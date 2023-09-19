using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.DataAccess.DataBaseSeeding
{
    public class ServicioSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            /// <summary>
            /// Método utilizado para poblar la base de datos con datos iniciales de servicios.
            /// </summary>
            /// <remarks>
            /// Este método se utiliza para agregar servicios iniciales a la base de datos al realizar la inicialización.
            /// Los datos proporcionados son ejemplos y pueden variar según los requisitos del sistema.
            /// </remarks>
            /// <param name="modelBuilder">El constructor del modelo de entidad que se utiliza para definir los datos iniciales.</param>

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
