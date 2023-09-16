using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.Entities;
using ProyectoIntegradorSoftteck.Helpers;

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
                  Tipo = Tipo.Administrador,
                  Contrasena = PasswordEncryptHelper.EncryptPassword("1234", "Marcio")
              },
               new Usuario
               {
                   CodUsuario = 12,
                   Nombre = "Daniel",
                   Dni = 1010100,
                   Tipo = Tipo.Administrador,
                   Contrasena = PasswordEncryptHelper.EncryptPassword("2020", "Daniel")
               },
                new Usuario
                {
                    CodUsuario = 13,
                    Nombre = "Pepito",
                    Dni = 3030300,
                    Tipo = Tipo.Consultor,
                    Contrasena = PasswordEncryptHelper.EncryptPassword("0000", "Pepito")
                });
        }
    }
}
