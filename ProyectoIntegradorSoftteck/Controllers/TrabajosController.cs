using AlkemyUmsa.Infrastructure;
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
        public async Task<IActionResult> ObtenerTrabajos()
        {
            var respuesta = await _unitOfWork.TrabajoRepository.ObtenerTrabajos();

            if (respuesta != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, respuesta);
            }
            return ResponseFactory.CreateErrorResponse(404, "Error al consultar lista de trabajos");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerTrabajo(int id)
        {
            var respuesta = await _unitOfWork.TrabajoRepository.ObtenerTrabajoPorId(id);

            if (respuesta != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, respuesta);
            }
            return ResponseFactory.CreateErrorResponse(404, "Error al buscar el trabajo, o trabajo no existe");
        }



        [HttpPost]
        public async Task<IActionResult> InsertarTrabajo(TrabajoDto trabajoDto)
        {

            var respuesta = await _unitOfWork.TrabajoRepository.InsertarTrabajo(trabajoDto);
            if (respuesta)
            {
                return ResponseFactory.CreateSuccessResponse(200, "Trabajo registrado con exito");
            }
            return ResponseFactory.CreateErrorResponse(404, "Error al ingresar el trabajo");
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarTrabajo(Trabajo trabajo)
        // momentanemente falta implementar en repository
        {
            var respuesta = await _unitOfWork.TrabajoRepository.ModificarTrabajo(trabajo);
            if (respuesta)
            {
                return ResponseFactory.CreateSuccessResponse(200, "Trabajo modificado con exito");
            }

            return ResponseFactory.CreateErrorResponse(404, "Error al modificar el trabajo, asegurese que el trabajo exista");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarTrabajo(int id)
        {
            var respuesta = await _unitOfWork.TrabajoRepository.BorrarTrabajo(id);

            if (respuesta)
            {
                return ResponseFactory.CreateSuccessResponse(200, "Trabajo borrado con exito");
            }
            return ResponseFactory.CreateErrorResponse(404, "No se puede borrar el trabajo, consulte que exista el trabajo que quiere borrar");
        }
    }
}
