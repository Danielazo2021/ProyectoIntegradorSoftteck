using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.DataAccess.DataBaseSeeding
{
    public class UsuarioSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
              new Usuario
              {
                  CodUsuario = 11,
                  Nombre = "Marcio",
                  Dni = 2020200,
                  Tipo = 1,
                  Contrasena = "encriptar"
              },
               new Usuario
               {
                   CodUsuario = 12,
                   Nombre = "Daniel",
                   Dni = 1010100,
                   Tipo = 1,
                   Contrasena = "encriptar"
               },
                new Usuario
                {
                    CodUsuario = 13,
                    Nombre = "Pepito",
                    Dni = 3030300,
                    Tipo = 2,
                    Contrasena = "encriptar"
                });
        }
    }
}
