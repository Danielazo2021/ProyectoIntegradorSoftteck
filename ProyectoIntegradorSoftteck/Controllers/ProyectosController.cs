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
    public class ProyectosController : ControllerBase
    {

         private readonly IUnitOfWork _unitOfWork;
        public ProyectosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("proyecto")]
        public async Task<IActionResult> ObtenerProyectos()
        {
            var respuesta = await _unitOfWork.ProyectoRepository.ObtenerProyectos();

            if (respuesta != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, respuesta);
              
            }
            return ResponseFactory.CreateErrorResponse(400, "Error al consultar lista de proyectos");
          
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerProyecto(int id)
        {
            var respuesta = await _unitOfWork.ProyectoRepository.ObtenerProyectoPorId(id);

            if (respuesta != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, respuesta);
            }
           
            return ResponseFactory.CreateErrorResponse(404, "Error al buscar el proyecto, o proyecto no existe");
        }



        [HttpPost]
        public async Task<IActionResult> InsertarProyecto(ProyectoDto proyecto)
        {

            var respuesta = await _unitOfWork.ProyectoRepository.InsertarProyecto(proyecto);
            if (respuesta)
            {
                return ResponseFactory.CreateSuccessResponse(200, "Proyecto registrado con exito");
                
            }
            return ResponseFactory.CreateErrorResponse(404, "Error al ingresar el proyecto");
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarProyecto(Proyecto proyecto)
        // momentanemente falta implementar en repository
        {
            var respuesta = await _unitOfWork.ProyectoRepository.ModificarProyecto(proyecto);
            if (respuesta)
            {
                return ResponseFactory.CreateSuccessResponse(200, "Proyecto modificado con exito");
            }

            return ResponseFactory.CreateErrorResponse(404, "Error al modificar el proyecto, asegurese que el proyecto exista");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarProyecto(int id)
        {
            var respuesta = await _unitOfWork.ProyectoRepository.BorrarProyecto(id);

            if (respuesta)
            {
                return ResponseFactory.CreateSuccessResponse(200, "Proyecto borrado con exito");
            }
            return ResponseFactory.CreateErrorResponse(404, "No se puede borrar el proyecto, consulte que exista el proyecto que quiere borrar");
        }
    }
}
