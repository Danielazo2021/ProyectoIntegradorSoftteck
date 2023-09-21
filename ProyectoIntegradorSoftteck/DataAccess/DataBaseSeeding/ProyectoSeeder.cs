using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.DataAccess.DataBaseSeeding
{
    public class ProyectoSeeder : IEntitySeeder
    {
        /// <summary>
        /// Método utilizado para poblar la base de datos con datos iniciales.
        /// </summary>
        /// <remarks>
        /// Este método se utiliza para agregar datos iniciales a la base de datos al realizar la inicialización.
        /// Los datos proporcionados son ejemplos y pueden variar según los requisitos del sistema.
        /// </remarks>
        /// <param name="modelBuilder">El constructor del modelo de entidad que se utiliza para definir los datos iniciales.</param>
       public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proyecto>().HasData(
             new Proyecto
             {
                 CodProyecto = 11,
                 Nombre = "Optimización de Procesos de Refinamiento de Petróleo CrudoManolita y Cia",
                 Direccion = "Libertad 180 Carloz Paz",
                 Estado = Estado.Terminado.ToString()
             },
             new Proyecto
             {
                 CodProyecto = 12,
                 Nombre = "Programa de Mantenimiento y Actualización de Equipos",
                 Direccion = "Av San Martin S/N Rio Cuarto",
                 Estado = Estado.Pendiente.ToString()
             },
             new Proyecto
             {
                 CodProyecto = 13,
                 Nombre = "Modernización de la Refinería para Carmelo SA",
                 Direccion = "Colon 1050 Cordoba Capital",
                 Estado = Estado.Confirmado.ToString()
             }); ;
        }
    }
}
