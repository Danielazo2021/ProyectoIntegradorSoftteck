using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.Controllers;
using ProyectoIntegradorSoftteck.DataAccess;
using ProyectoIntegradorSoftteck.DataAccess.Repository.Interfaces;
using ProyectoIntegradorSoftteck.DTOs;
using ProyectoIntegradorSoftteck.Entities;
using ProyectoIntegradorSoftteck.Helpers;
using System.ComponentModel;
using System.Net;

namespace ProyectoIntegradorSoftteck.DataAccess.Repository.Implementations
{
    public class UsuarioRepository :  Repository<Usuario>,IUsuarioRepository
    {               
        public UsuarioRepository(ContextDB context): base(context)
        {
        }       

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



        public async Task<bool> InsertarUsuario(UsuarioDto usuarioDto)
        {
            bool respuesta;

            try
            {
                var usuarioNvo = new Usuario(usuarioDto);
                
                _context.Usuarios.Add(usuarioNvo);
                await _context.SaveChangesAsync();
                respuesta = true;

            }
            catch (Exception)
            {
                respuesta = false;
            }
            return respuesta;

        }


        public async Task<bool> ModificarUsuario(Usuario usuario, int dni)
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
        public async Task<Usuario?> AuthenticateCredentials(AuthenticateDto dto)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(x => x.Nombre == dto.Nombre && x.Contrasena == PasswordEncryptHelper.EncryptPassword(dto.Contrasena, dto.Nombre));
        }

    }
}