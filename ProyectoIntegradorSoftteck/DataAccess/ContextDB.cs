using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.DataAccess.DataBaseSeeding;
using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.DataAccess
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {

        }

        // Propiedades DbSet para cada entidad en la base de datos.
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Trabajo> Trabajos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        // Método OnModelCreating para configurar el modelo de datos y las relaciones entre entidades.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // Se crea una lista de IEntitySeeder para inicializar datos en la base de datos.
            var seeders = new List<IEntitySeeder>
            {
                new UsuarioSeeder(),
                new ServicioSeeder(),
                new ProyectoSeeder(),
                new TrabajoSeeder()
            };

            // Se ejecutan los seeders para inicializar datos en la base de datos.
            foreach (var seeder in seeders)
            {

                seeder.SeedDatabase(modelBuilder);
            }

            // Llamada al método base para configuraciones adicionales si es necesario.
            base.OnModelCreating(modelBuilder);


        }

    }
}
