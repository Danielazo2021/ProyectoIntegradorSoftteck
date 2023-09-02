
using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.DataAccess;
using ProyectoIntegradorSoftteck.Entities;

namespace APPIntegrator.Repository
{


    public interface IUsuarioRepository
    {
        Task<Usuario> Insertar(Usuario usuario);
        Task<Usuario?> ObtenerPorId(int id);
    }

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ContextDB _context;

        public UsuarioRepository(ContextDB context)
        {
            _context = context;
        }

        public async Task<Usuario> Insertar(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return usuario;
            }catch (Exception ex)
            {
                Console.WriteLine($"Algo paso aca {ex}");

                throw;
            }
          
        }


        public async Task<Usuario?> ObtenerPorId(int codigoUsuarioIngresado)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.CodUsuario == codigoUsuarioIngresado);
        }
    }
}