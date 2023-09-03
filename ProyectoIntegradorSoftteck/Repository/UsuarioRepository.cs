
using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.DataAccess;
using ProyectoIntegradorSoftteck.Entities;
using ProyectoIntegradorSoftteck.Repository;

namespace APPIntegrator.Repository{


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