using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.Repository
{
 
        public interface IUsuarioRepository
        {
            Task<Boolean> Insertar(Usuario usuario);
            Task<Usuario> ObtenerPorId(int id);
        }

    
}
