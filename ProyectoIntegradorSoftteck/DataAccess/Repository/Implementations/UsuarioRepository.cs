using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.Controllers;
using ProyectoIntegradorSoftteck.DataAccess;
using ProyectoIntegradorSoftteck.DataAccess.Repository.Interfaces;
using ProyectoIntegradorSoftteck.DTOs;
using ProyectoIntegradorSoftteck.Entities;
using System.Net;

namespace ProyectoIntegradorSoftteck.DataAccess.Repository.Implementations
{


    public class UsuarioRepository :  Repository<Usuario>,IUsuarioRepository
    {

        private readonly ContextDB _context;

        public UsuarioRepository(ContextDB context): base(context)
        {
            
        }

//        Ver de apadtar para login
        //public async Task<Usuario?> AutenticateCredentials(AutenticateDto dto)
        //{
        //    return await _context.Users.SingleOrDefaultAsync(x => x.Email == dto.Email && x.Password == dto.Password);
        //}





        public async Task<bool> BorrarUsuario(int dni)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Dni == dni);
                if (usuario != null)
                {
                    _context.Usuarios.Remove(usuario);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }



        }



        public async Task<bool> InsertarUsuario(Usuario usuario)
        {
            bool respuesta;

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



        public async Task<bool> ModificarUsuario(Usuario usuario)
        {
            //buscar el con el id que vino por parametro en la base y setearle el resto de los cambios,
            //despues hacer un update en la se y un savechange
            throw new NotImplementedException();
        }

        public async Task<Usuario> ObtenerUsuarioPorId(int dni)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.Dni == dni);
                if (usuario != null)
                {
                    return usuario;
                }
            }
            catch (Exception ex)
            {

            }

            return null; 
        }

        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            try
            {
                listaUsuarios = await _context.Usuarios.ToListAsync();

            }
            catch (Exception)
            {

            }

            return listaUsuarios;


        }

    }
}