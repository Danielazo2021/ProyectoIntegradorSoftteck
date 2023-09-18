using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.DataAccess.DataBaseSeeding
{
    public class ProyectoSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proyecto>().HasData(
             new Proyecto
             {
                 CodProyecto = 11,
                 Nombre = "Optimización de Procesos de Refinamiento de Petróleo CrudoManolita y Cia",
                 Direccion = "Libertad 180 Carloz Paz",
                 Estado = Estado.Terminado
             },
             new Proyecto
             {
                 CodProyecto = 12,
                 Nombre = "Programa de Mantenimiento y Actualización de Equipos",
                 Direccion = "Av San Martin S/N Rio Cuarto",
                 Estado = Estado.Pendiente
             },
             new Proyecto
             {
                 CodProyecto = 13,
                 Nombre = "Modernización de la Refinería para Carmelo SA",
                 Direccion = "Colon 1050 Cordoba Capital",
                 Estado = Estado.Confirmado
             });
        }
    }
}
