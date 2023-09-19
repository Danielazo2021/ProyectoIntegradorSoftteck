using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.Entities;
using ProyectoIntegradorSoftteck.Helpers;

namespace ProyectoIntegradorSoftteck.DataAccess.DataBaseSeeding
{
    public class UsuarioSeeder : IEntitySeeder
    {
        public void SeedDatabase(ModelBuilder modelBuilder)
        {
            /// <summary>
            /// Método utilizado para poblar la base de datos con datos iniciales de usuarios.
            /// </summary>
            /// <remarks>
            /// Este método se utiliza para agregar usuarios iniciales a la base de datos al realizar la inicialización.
            /// Los datos proporcionados son ejemplos y pueden variar según los requisitos del sistema.
            /// </remarks>
            /// <param name="modelBuilder">El constructor del modelo de entidad que se utiliza para definir los datos iniciales.</param>

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
