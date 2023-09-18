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
