using Microsoft.EntityFrameworkCore;

namespace ProyectoIntegradorSoftteck.DataAccess.DataBaseSeeding
{
    public interface IEntitySeeder
    {
        void SeedDatabase(ModelBuilder modelBuilder);
    }
}
