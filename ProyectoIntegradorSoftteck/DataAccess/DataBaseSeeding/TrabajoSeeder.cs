using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.DataAccess.DataBaseSeeding
{
    public class TrabajoSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trabajo>().HasData(
              new Trabajo
              {
                  CodTrabajo = 1,
                  Fecha = new DateTime(23,5,1),
                  cod_proyecto = 3,
                  cod_servicio = 1,
                  CantHoras = 120,
                  ValorHora= 1500,
                  Costo=180000
              },
               new Trabajo
               {
                   CodTrabajo = 2,
                   Fecha = new DateTime(23, 7, 11),
                   cod_proyecto = 2,
                   cod_servicio = 1,
                   CantHoras = 50,
                   ValorHora = 1500,
                   Costo = 75000
               },
                new Trabajo
                {
                    CodTrabajo = 3,
                    Fecha = new DateTime(23, 7, 18),
                    cod_proyecto = 2,
                    cod_servicio = 2,
                    CantHoras = 20,
                    ValorHora = 750,
                    Costo = 15000
                });
        }
    }
}
