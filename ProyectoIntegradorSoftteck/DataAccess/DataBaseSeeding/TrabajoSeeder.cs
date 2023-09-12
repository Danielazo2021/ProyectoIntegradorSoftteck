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
                  CodTrabajo = 11,
                  Fecha = new DateTime(23,5,1),
                  cod_proyecto = 13,
                  cod_servicio = 11,
                  CantHoras = 120,
                  ValorHora= 1500,
                  Costo=180000
              },
               new Trabajo
               {
                   CodTrabajo = 12,
                   Fecha = new DateTime(23, 7, 11),
                   cod_proyecto = 12,
                   cod_servicio = 11,
                   CantHoras = 50,
                   ValorHora = 1500,
                   Costo = 75000
               },
                new Trabajo
                {
                    CodTrabajo = 13,
                    Fecha = new DateTime(23, 7, 18),
                    cod_proyecto = 12,
                    cod_servicio = 12,
                    CantHoras = 20,
                    ValorHora = 750,
                    Costo = 15000
                });
        }
    }
}
