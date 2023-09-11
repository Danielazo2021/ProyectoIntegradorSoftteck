
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegradorSoftteck.DTOs;
using ProyectoIntegradorSoftteck.Entities;

using ProyectoIntegradorSoftteck.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoIntegradorSoftteck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("usuario")]
        public  async Task<ActionResult<List<Usuario>>> ObtenerUsuarios()
        {
            var respuesta = await _usuarioService.ObtenerUsuarios();

            if (respuesta != null)
            {
                return Ok(respuesta);
            }
            return BadRequest("Error al consultar lista de usuarios");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> ObtenerUsuario(int id)
        {
            var respuesta = await _usuarioService.ObtenerUsuarioPorId(id);

            if (respuesta != null)
            {
                return Ok(respuesta);
            }
            return BadRequest("Error al buscar el usuario, o usuario no existe");
        }



        [HttpPost]
        public async Task<ActionResult<String>> InsertarUsuario(UsuarioDto usuarioDto)
        {

            var respuesta = await _usuarioService.InsertarUsuario(usuarioDto);
            if (respuesta)
            {
                return Ok("Usuario registrado con exito");
            }
            return BadRequest("Error al ingresar el usuario");
        }
    


  
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> ModificarUsuario(Usuario usuarioDto)
            // momentanemente falta implementar en repository
        {
            var respuesta = await _usuarioService.ModificarUsuario(usuarioDto);
            if (respuesta)
            {
                return Ok("Usuario modificado con exito");
            }

            return BadRequest("Error al modificar el usuario, asegurese que el usuario exista");
        }   


    [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> BorrarUsuario(int id)
        {
            var respuesta = await _usuarioService.BorrarUsuario(id);

            if (respuesta)
            {
                return Ok("Usuario borrado con exito");
            }
            return NotFound("No se puede borrar el usuario, consulte que exista el usuario que quiere borrar");
        }
    }
}
