using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.Repository
{
    public interface IUsuarioRepository
    {
        public interface IUsuarioRepository
        {
            Task<Usuario> Insertar(Usuario usuario);
            Task<Usuario?> ObtenerPorId(int id);
        }

    }
}
