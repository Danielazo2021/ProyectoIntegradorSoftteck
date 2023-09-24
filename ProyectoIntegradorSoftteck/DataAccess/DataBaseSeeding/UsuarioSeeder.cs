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
                  CodUsuario = 1,
                  Nombre = "Marcio",
                  UserName="ProfeMarcio",
                  Email="marcio@marcio.com",
                  Dni = 2020200,
                  Tipo = Tipo.Administrador,
                  Contrasena = PasswordEncryptHelper.EncryptPassword("1234", "marcio@marcio.com")
              },
               new Usuario
               {
                   CodUsuario = 2,
                   Nombre = "Daniel",
                   UserName="Danielazo",
                   Email="daniel@daniel.com",
                   Dni = 1010100,
                   Tipo = Tipo.Administrador,
                   Contrasena = PasswordEncryptHelper.EncryptPassword("2020", "daniel@daniel.com")
               },
                new Usuario
                {
                    CodUsuario = 3,
                    Nombre = "Pepe",
                    UserName="Pepito",
                    Email="pepe@pepe.com",
                    Dni = 3030300,
                    Tipo = Tipo.Consultor,
                    Contrasena = PasswordEncryptHelper.EncryptPassword("0000", "pepe@pepe.com")
                });
        }
    }
}
