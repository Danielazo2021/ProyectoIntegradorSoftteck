using Microsoft.AspNetCore.Mvc;
using ProyectoIntegradorSoftteck.DTOs;
using ProyectoIntegradorSoftteck.Entities;
using ProyectoIntegradorSoftteck.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoIntegradorSoftteck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrabajosController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public TrabajosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("trabajo")]
        public async Task<ActionResult<List<Trabajo>>> ObtenerTrabajos()
        {
            var respuesta = await _unitOfWork.TrabajoRepository.ObtenerTrabajos();

            if (respuesta != null)
            {
                return Ok(respuesta);
            }
            return BadRequest("Error al consultar lista de trabajos");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Servicio>> ObtenerTrabajo(int id)
        {
            var respuesta = await _unitOfWork.TrabajoRepository.ObtenerTrabajoPorId(id);

            if (respuesta != null)
            {
                return Ok(respuesta);
            }
            return BadRequest("Error al buscar el trabajo, o trabajo no existe");
        }



        [HttpPost]
        public async Task<ActionResult<String>> InsertarTrabajo(TrabajoDto trabajoDto)
        {

            var respuesta = await _unitOfWork.TrabajoRepository.InsertarTrabajo(trabajoDto);
            if (respuesta)
            {
                return Ok("Trabajo registrado con exito");
            }
            return BadRequest("Error al ingresar el trabajo");
        }




        [HttpPut("{id}")]
        public async Task<ActionResult<Trabajo>> ModificarTrabajo(Trabajo trabajo)
        // momentanemente falta implementar en repository
        {
            var respuesta = await _unitOfWork.TrabajoRepository.ModificarTrabajo(trabajo);
            if (respuesta)
            {
                return Ok("Trabajo modificado con exito");
            }

            return BadRequest("Error al modificar el trabajo, asegurese que el trabajo exista");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> BorrarTrabajo(int id)
        {
            var respuesta = await _unitOfWork.TrabajoRepository.BorrarTrabajo(id);

            if (respuesta)
            {
                return Ok("Trabajo borrado con exito");
            }
            return NotFound("No se puede borrar el trabajo, consulte que exista el trabajo que quiere borrar");
        }
    }
}
