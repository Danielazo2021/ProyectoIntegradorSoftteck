using ProyectoIntegradorSoftteck.DTOs;
using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.Repository.Interfaces
{

    public interface IUsuarioRepository //hacemos uno por clase para que sea mas modular
    {
        Task<bool> InsertarUsuario(Usuario usuario);
        Task<Usuario> ObtenerUsuarioPorId(int id);
        Task<List<Usuario>> ObtenerUsuarios();
        Task<bool> BorrarUsuario(int dni);
        Task<bool> ModificarUsuario(Usuario usuario);

    }


}
