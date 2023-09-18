
using AlkemyUmsa.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegradorSoftteck.DTOs;
using ProyectoIntegradorSoftteck.Entities;

using ProyectoIntegradorSoftteck.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoIntegradorSoftteck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuariosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuariosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        ///  Devuelve todo los usuarios
        /// </summary>
        /// <returns>retorna todos los usuarios</returns>

        [HttpGet()]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            var respuesta = await _unitOfWork.UsuarioRepository.ObtenerUsuarios();

            if (respuesta != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, respuesta);
            }
            return ResponseFactory.CreateErrorResponse(404, "Error al consultar lista de usuarios");
        }

        [HttpGet("{pagina}/{registrosPorPagina}")]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerUsuariosPaginado([FromRoute] int pagina, [FromRoute] int registrosPorPagina)
        {
            var respuesta = await _unitOfWork.UsuarioRepository.ObtenerUsuariosPaginado(pagina, registrosPorPagina);

            if (respuesta != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, respuesta);
            }
            return ResponseFactory.CreateErrorResponse(404, "Error al consultar lista de usuarios");
        }

        


        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerUsuario(int id)
        {
            var respuesta = await _unitOfWork.UsuarioRepository.ObtenerUsuarioPorId(id);

            if (respuesta != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, respuesta);
            }
            return ResponseFactory.CreateErrorResponse(404, "Error al buscar el usuario, o usuario no existe");
        }



        [HttpPost]
        public async Task<IActionResult> InsertarUsuario(UsuarioDto usuarioDto)
        {

            var respuesta = await _unitOfWork.UsuarioRepository.InsertarUsuario(usuarioDto);
            if (respuesta)
            {
                return ResponseFactory.CreateSuccessResponse(201, "Usuario registrado con exito");
            }
            return ResponseFactory.CreateErrorResponse(404, "Error al ingresar el usuario");
        }
    


  
        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarUsuario([FromRoute] int id, UsuarioDto usuarioDto)        
        {
            var respuesta = await _unitOfWork.UsuarioRepository.ModificarUsuario(new Usuario(usuarioDto, id));
            if (respuesta)
            {
                return ResponseFactory.CreateSuccessResponse(200, "Usuario modificado con exito");
            }

            return ResponseFactory.CreateErrorResponse(404, "Error al modificar el usuario, asegurese que el usuario exista");
        }   


    [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarUsuario(int id)
        {
            var respuesta = await _unitOfWork.UsuarioRepository.BorrarUsuario(id);

            if (respuesta)
            {
                return ResponseFactory.CreateSuccessResponse(200, "Usuario borrado con exito");
            }
            return ResponseFactory.CreateErrorResponse(404, "No se puede borrar el usuario, consulte que exista el usuario que quiere borrar");
        }
    }
}
