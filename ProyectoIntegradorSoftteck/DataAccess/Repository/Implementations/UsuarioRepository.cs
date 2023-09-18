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

        public async Task<List<Usuario>> ObtenerUsuariosPaginado(int pagina, int registrosPorPagina)
        {
            try
            {
                var query = _context.Usuarios.AsQueryable();

                var usuarios = await query
                    .OrderBy(p => p.CodUsuario)
                    .Skip((pagina - 1) * registrosPorPagina)
                    .Take(registrosPorPagina)
                    .ToListAsync();

                return usuarios;
            }
            catch (Exception)
            {

                throw;
            }
        }
        

        public async Task<Usuario?> AuthenticateCredentials(AuthenticateDto dto)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(x => x.Nombre == dto.Nombre && x.Contrasena == PasswordEncryptHelper.EncryptPassword(dto.Contrasena, dto.Nombre));
        }

    }
}