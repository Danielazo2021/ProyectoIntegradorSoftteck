
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegradorSoftteck.DTOs;
using ProyectoIntegradorSoftteck.Entities;
using ProyectoIntegradorSoftteck.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoIntegradorSoftteck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("ok");
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> ObtenerUsuario(int id)
        {
            var usuario = await _usuarioRepository.ObtenerPorId(id);

            if (usuario == null)
            {
                return NotFound(); // Retorna un código 404 si el usuario no se encuentra
            }

            return usuario;
        }



        [HttpPost]
        public async Task<ActionResult<Usuario>> InsertarUsuario(UsuarioDto usuarioDto)
        {
            try
            {
                var usuario = new Usuario {
                    Nombre=usuarioDto.Nombre,
                    Dni=usuarioDto.Dni,
                    Tipo=usuarioDto.Tipo,
                    Contrasena=usuarioDto.Contrasena
                };

                await _usuarioRepository.Insertar(usuario);
                return Ok(190);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

  
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok("ok");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok("ok");
        }
    }
}
