using ProyectoIntegradorSoftteck.DTOs;
using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.Services.Interfaces
{
    public interface IUsuarioService
    {
 
        Task<bool> InsertarUsuario(UsuarioDto usuario);
        Task<Usuario> ObtenerUsuarioPorId(int id);
        Task<List<Usuario>> ObtenerUsuarios();
        Task<bool> BorrarUsuario(int id);
        Task<bool> ModificarUsuario(Usuario usuario);

    }
}
