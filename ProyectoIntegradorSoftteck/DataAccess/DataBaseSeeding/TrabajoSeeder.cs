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
                  CodTrabajo = 1,
                  Fecha = new DateTime(2023,5,1),
                  Cod_proyecto = 3,
                  Cod_servicio= 1,
                  CantHoras = 120,
                  ValorHora= 150000,
                  Costo=18000000
              },
               new Trabajo
               {
                   CodTrabajo = 2,
                   Fecha = new DateTime(2023, 7, 11),
                   Cod_proyecto = 2,
                   Cod_servicio = 1,
                   CantHoras = 50,
                   ValorHora = 150000,
                   Costo = 7500000
               },
                new Trabajo
                {
                    CodTrabajo = 3,
                    Fecha = new DateTime(2023, 7, 18),
                    Cod_proyecto = 2,
                    Cod_servicio = 2,
                    CantHoras = 20,
                    ValorHora = 75000,
                    Costo = 1500000
                });
        }
    }
}
