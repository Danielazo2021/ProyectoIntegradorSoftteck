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

        public async Task<Usuario> ObtenerUsuarioPorId(int cod) 
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuario => usuario.CodUsuario == cod);
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

        public async Task<bool> ModificarUsuario(Usuario usuarioModificado)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(x => x.CodUsuario == usuarioModificado.CodUsuario);

            if (user == null) { return false; }

            user.Nombre = usuarioModificado.Nombre;
            user.Dni = usuarioModificado.Dni;
            user.Tipo = usuarioModificado.Tipo;
            user.Contrasena = usuarioModificado.Contrasena;

            _context.Usuarios.Update(user);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<bool> BorrarUsuario(int cod)
        {
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.CodUsuario == cod);
                if (usuario != null)
                {
                    usuario.IsActive = false;
                    _context.Usuarios.Update(usuario);
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


        /// <summary>
        /// Autentica las credenciales del usuario.
        /// </summary>
        /// <remarks>
        /// Este método permite autenticar a un usuario utilizando un nombre de usuario y una contraseña proporcionados en el objeto DTO (Data Transfer Object) 'dto'. La contraseña se encripta antes de la comparación.
        /// </remarks>
        /// <param name="dto">DTO que contiene el nombre de usuario y la contraseña para la autenticación.</param>
        /// <returns>Un objeto de tipo 'Usuario' si las credenciales son válidas, o 'null' si no se encuentra un usuario que coincida.</returns>

        public async Task<Usuario?> AuthenticateCredentials(AuthenticateDto dto)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(x => x.UserName == dto.UserName && x.Email== dto.Email   && x.Contrasena == PasswordEncryptHelper.EncryptPassword(dto.Contrasenia, dto.Email));
        }

    }
}