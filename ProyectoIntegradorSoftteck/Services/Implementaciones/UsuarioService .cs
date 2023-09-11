using ProyectoIntegradorSoftteck.DTOs;
using ProyectoIntegradorSoftteck.Entities;

using ProyectoIntegradorSoftteck.Services.Interfaces;
using ProyectoIntegradorSoftteck.DataAccess.Repository.Interfaces;

namespace ProyectoIntegradorSoftteck.Services.Implementaciones
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> BorrarUsuario(int id)
        {
            bool respuesta = await _usuarioRepository.Borrar(id);

            return respuesta;
        }

        public async Task<bool> InsertarUsuario(UsuarioDto usuario)
        {
               
            Usuario usuarioEntity = new Usuario
            {
                Nombre = usuario.Nombre,
                Contrasena = usuario.Contrasena,
                Dni = usuario.Dni,
                Tipo = usuario.Tipo
            };

            
           bool respuesta = await _usuarioRepository.Insertar(usuarioEntity);

            return respuesta;

        }

        public async Task<bool> ModificarUsuario(Usuario usuario)
        {
                        
           bool respuesta = await _usuarioRepository.Modificar(usuario);

            return respuesta;
        }

        public async  Task<Usuario> ObtenerUsuarioPorId(int id)
        {
            var respuesta = await _usuarioRepository.ObtenerPorDni(id);
            if(respuesta == null)
            {
                return null;
            }
                Usuario usuarioEntity = new Usuario
                {
                    //no debo devolver el cod de suaurio porque solo es como se almacena en la BD, no es de interes de la consulta
                  CodUsuario=respuesta.CodUsuario,
                    Nombre = respuesta.Nombre,
                    Contrasena = respuesta.Contrasena,
                    Dni = respuesta.Dni,
                    Tipo = respuesta.Tipo
                };             


            return usuarioEntity;
        }

        public async Task<List<Usuario>> ObtenerUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            var respuesta = await _usuarioRepository.ObtenerTodos(); 
            foreach(var usuario in respuesta)
            {
                Usuario usuarioEntity = new Usuario
                {
                    CodUsuario= usuario.CodUsuario,
                    Nombre = usuario.Nombre,
                    Contrasena = usuario.Contrasena,
                    Dni = usuario.Dni,
                    Tipo = usuario.Tipo
                };
                listaUsuarios.Add(usuarioEntity);

            }     

            return listaUsuarios;
        }
     }

}
