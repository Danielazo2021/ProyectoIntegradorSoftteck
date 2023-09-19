using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.DataAccess.DataBaseSeeding
{
    public class TrabajoSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            /// <summary>
            /// Método utilizado para poblar la base de datos con datos iniciales de trabajos.
            /// </summary>
            /// <remarks>
            /// Este método se utiliza para agregar trabajos iniciales a la base de datos al realizar la inicialización.
            /// Los datos proporcionados son ejemplos y pueden variar según los requisitos del sistema.
            /// </remarks>
            /// <param name="modelBuilder">El constructor del modelo de entidad que se utiliza para definir los datos iniciales.</param>

            modelBuilder.Entity<Trabajo>().HasData(
              new Trabajo
              {
                  CodTrabajo = 11,
                  Fecha = new DateTime(23,5,1),
                  Cod_proyecto = 13,
                  Cod_servicio= 11,
                  CantHoras = 120,
                  ValorHora= 150000,
                  Costo=18000000
              },
               new Trabajo
               {
                   CodTrabajo = 12,
                   Fecha = new DateTime(23, 7, 11),
                   Cod_proyecto = 12,
                   Cod_servicio = 11,
                   CantHoras = 50,
                   ValorHora = 150000,
                   Costo = 7500000
               },
                new Trabajo
                {
                    CodTrabajo = 13,
                    Fecha = new DateTime(23, 7, 18),
                    Cod_proyecto = 12,
                    Cod_servicio = 12,
                    CantHoras = 20,
                    ValorHora = 75000,
                    Costo = 1500000
                });
        }
    }
}
