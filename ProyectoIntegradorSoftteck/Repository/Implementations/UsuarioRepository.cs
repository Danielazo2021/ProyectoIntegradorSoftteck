using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.DataAccess;
using ProyectoIntegradorSoftteck.DTOs;
using ProyectoIntegradorSoftteck.Entities;
using ProyectoIntegradorSoftteck.Repository.Interfaces;

namespace ProyectoIntegradorSoftteck.Repository.Implementations
{


    public class UsuarioRepository : IUsuarioRepository
    {       

        private readonly ContextDB _context;

        public UsuarioRepository(ContextDB context)
        {
            _context = context;
        }

        public async Task<bool> Insertar(Usuario usuario)
        {
            bool respuesta;



            /// aca deberia llegar ya el usuario entity, la conversion la jhacemos en el servicio
            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                respuesta = true;

            }
            catch (Exception)
            {
                respuesta = false;
            }
            return respuesta;

        }

        public Task<bool> ModificarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> ObtenerPorId(int codigoUsuarioIngresado)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.CodUsuario == codigoUsuarioIngresado);
            if (usuario != null)
            {
                return usuario;
            }
            else
            {

            }
            return null; // vemos que devolvemos
        }

        public Task<List<Usuario>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}