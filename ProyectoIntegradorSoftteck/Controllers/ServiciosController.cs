using Microsoft.AspNetCore.Mvc;
using ProyectoIntegradorSoftteck.DTOs;
using ProyectoIntegradorSoftteck.Entities;
using ProyectoIntegradorSoftteck.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoIntegradorSoftteck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
          private readonly IUnitOfWork _unitOfWork;
           public ServiciosController(IUnitOfWork unitOfWork)
           {
               _unitOfWork = unitOfWork;
           }

           [HttpGet("servicio")]
           public async Task<ActionResult<List<Servicio>>> ObtenerServicios()
           {
               var respuesta = await _unitOfWork.ServicioRepository.ObtenerServicios();

               if (respuesta != null)
               {
                   return Ok(respuesta);
               }
               return BadRequest("Error al consultar lista de servicios");
           }


           [HttpGet("{id}")]
           public async Task<ActionResult<Servicio>> ObtenerServicio(int id)
           {
               var respuesta = await _unitOfWork.ServicioRepository.ObtenerServicioPorId(id);

               if (respuesta != null)
               {
                   return Ok(respuesta);
               }
               return BadRequest("Error al buscar el servicio, o servicio no existe");
           }



           [HttpPost]
           public async Task<ActionResult<String>> InsertarServicio(ServicioDto servicioDto)
           {

               var respuesta = await _unitOfWork.ServicioRepository.InsertarServicio(servicioDto);
               if (respuesta)
               {
                   return Ok("Servicio registrado con exito");
               }
               return BadRequest("Error al ingresar el servicio");
           }




           [HttpPut("{id}")]
           public async Task<ActionResult<Servicio>> ModificarServicio(Servicio servicio)
           // momentanemente falta implementar en repository
           {
               var respuesta = await _unitOfWork.ServicioRepository.ModificarServicio(servicio);
               if (respuesta)
               {
                   return Ok("Servicio modificado con exito");
               }

               return BadRequest("Error al modificar el servicio, asegurese que el servicio exista");
           }


           [HttpDelete("{id}")]
           public async Task<ActionResult<bool>> BorrarServicio(int id)
           {
               var respuesta = await _unitOfWork.ServicioRepository.BorrarServicio(id);

               if (respuesta)
               {
                   return Ok("Servicio borrado con exito");
               }
               return NotFound("No se puede borrar el servicio, consulte que exista el servicio que quiere borrar");
           }
    }
}
