using ProyectoIntegradorSoftteck.DTOs;
using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.Repository.Interfaces
{

    public interface IUsuarioRepository //hacemos uno por clase para que sea mas modular
    {
        Task<bool> Insertar(Usuario usuario);
        Task<Usuario> ObtenerPorId(int id);
        Task<List<Usuario>> ObtenerTodos();
        Task<bool> ModificarUsuario(Usuario usuario);
    }


}
