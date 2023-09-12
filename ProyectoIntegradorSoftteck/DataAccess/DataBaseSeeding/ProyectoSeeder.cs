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
                 Nombre = "Renovacion estudio Gomez",
                 Direccion = "Libertad 180 Carloz Paz",
                 Estado = 2
             },
             new Proyecto
             {
                 CodProyecto = 12,
                 Nombre = "Ampliacion Anfiteatro RC",
                 Direccion = "Av San Martin S/N Rio Cuarto",
                 Estado = 1
             },
             new Proyecto
             {
                 CodProyecto = 13,
                 Nombre = "Renovacion Teatro Colon",
                 Direccion = "Colon 1050 Cordoba Capital",
                 Estado = 3
             });
        }
    }
}
