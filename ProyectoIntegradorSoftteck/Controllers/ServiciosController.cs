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
    public class ServiciosController : ControllerBase
    {
          private readonly IUnitOfWork _unitOfWork;
           public ServiciosController(IUnitOfWork unitOfWork)
           {
               _unitOfWork = unitOfWork;
           }

           [HttpGet("servicio")]
           public async Task<IActionResult> ObtenerServicios()
           {
               var respuesta = await _unitOfWork.ServicioRepository.ObtenerServicios();

               if (respuesta != null)
               {       
                return ResponseFactory.CreateSuccessResponse(200, respuesta);
               }           

                return ResponseFactory.CreateErrorResponse(404,"Error al consultar lista de servicios");
        
           }


           [HttpGet("{id}")]
           public async Task<IActionResult> ObtenerServicio(int id)
           {
               var respuesta = await _unitOfWork.ServicioRepository.ObtenerServicioPorId(id);

               if (respuesta != null)
               {
                   
                return ResponseFactory.CreateSuccessResponse(200, respuesta);


               }
            return ResponseFactory.CreateErrorResponse(404, "Error al buscar el servicio, o servicio no existe");
           }



           [HttpPost]
           public async Task<IActionResult> InsertarServicio(ServicioDto servicioDto)
           {

               var respuesta = await _unitOfWork.ServicioRepository.InsertarServicio(servicioDto);
               if (respuesta)
               {
                return ResponseFactory.CreateSuccessResponse(200, "Servicio registrado con exito");
               }
                 return ResponseFactory.CreateErrorResponse(404, "Error al ingresar el servicio");
           }




           [HttpPut("{id}")]
           public async Task<IActionResult> ModificarServicio(Servicio servicio)
           // momentanemente falta implementar en repository
           {
               var respuesta = await _unitOfWork.ServicioRepository.ModificarServicio(servicio);
               if (respuesta)
               {
                return ResponseFactory.CreateSuccessResponse(200, "Servicio modificado con exito");
               }

            return ResponseFactory.CreateErrorResponse(404, "Error al modificar el servicio, asegurese que el servicio exista");
           }


           [HttpDelete("{id}")]
           public async Task<IActionResult> BorrarServicio(int id)
           {
               var respuesta = await _unitOfWork.ServicioRepository.BorrarServicio(id);

               if (respuesta)
               {
                return ResponseFactory.CreateSuccessResponse(404, "Servicio borrado con exito");
               }
            return ResponseFactory.CreateErrorResponse(404, "No se puede borrar el servicio, consulte que exista el servicio que quiere borrar");
           }
    }
}
