
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

        public async Task<Boolean> Insertar(Usuario usuario)
        {
            bool respuesta;
            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                respuesta = true;

            }catch (Exception)
            {
                respuesta=false;                                
            }
            return respuesta;
          
        }


        public async Task<Usuario> ObtenerPorId(int codigoUsuarioIngresado)
        {
            var usuario=  await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.CodUsuario == codigoUsuarioIngresado);
            if (usuario != null)
            {
                return usuario;
            }
            else
            {

            }
                return null; // vemos que devolvemos
        }
    }
}