using AlkemyUmsa.Helper;
using AlkemyUmsa.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using ProyectoIntegradorSoftteck.DTOs;
using ProyectoIntegradorSoftteck.Entities;
using ProyectoIntegradorSoftteck.Services.Interfaces;
using System.Runtime.InteropServices;

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

        /// <summary>
        /// Obtiene una lista paginada de proyectos.
        /// </summary>
        /// <remarks>
        /// Este endpoint permite obtener una lista paginada de proyectos. Se requiere autorización como "ConsultorOAdministrador" para acceder a esta función.
        /// </remarks>
        /// <param name="pag">Número de página para la paginación (opcional).</param>
        /// <returns>Una respuesta HTTP con la lista paginada de proyectos.</returns>
        /// <response code="200">Se ha obtenido la lista paginada de proyectos correctamente.</response>
        /// <response code="401">No se ha autorizado el acceso a esta función.</response>
        /// <response code="500">Se ha producido un error interno en el servidor.</response>

        [HttpGet()]
        [Authorize(Policy = "ConsultorOAdministrador")]
        public async Task<IActionResult> ObtenerServicios(int? pag)
        {
            try
            {
                var servicios = await _unitOfWork.ServicioRepository.ObtenerServicios();
                int pageToShow = pag == null ? 1 : (int)pag;

                if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

                var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();

                var paginateServicios = PaginateHelper.Paginate(servicios, pageToShow, url);

                return ResponseFactory.CreateSuccessResponse(200, paginateServicios);
            }
            catch (Exception ex)
            {                
                return ResponseFactory.CreateErrorResponse(500, "Se ha producido un error interno en el servidor.", ex.Message);
            }
        }

       


        /// <summary>
        /// Obtiene una lista de servicios activos disponibles en la aplicación.
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los consultores y administradores obtener una lista de servicios activos disponibles en la aplicación.
        /// </remarks>
        /// <returns>
        /// Una respuesta que contiene una lista de servicios activos o un mensaje de error en caso de que no haya servicios activos disponibles o se produzca un error en la consulta.
        /// </returns>
        /// <response code="200">Se devuelve cuando se obtiene la lista de servicios activos con éxito.</response>
        /// <response code="404">Se devuelve cuando no se encuentran servicios activos disponibles o se produce un error en la consulta.</response>
        [HttpGet("activos")]
        [Authorize(Policy = "ConsultorOAdministrador")]
        public async Task<IActionResult> ObtenerServiciosActivos()
        {
            var respuesta = await _unitOfWork.ServicioRepository.ObtenerServiciosActivos();

            if (respuesta != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, respuesta);
            }

            return ResponseFactory.CreateErrorResponse(404, "Error al consultar lista de servicios Activos");

        }



        /// <summary>
        /// Obtiene los detalles de un servicio por su identificador.
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los consultores y administradores obtener los detalles de un servicio específico mediante su identificador único.
        /// </remarks>
        /// <param name="id">El identificador único del servicio.</param>
        /// <returns>
        /// Una respuesta que contiene los detalles del servicio si se encuentra, o un mensaje de error si el servicio no existe o se produce un error en la consulta.
        /// </returns>
        /// <response code="200">Se devuelve cuando se obtienen los detalles del servicio con éxito.</response>
        /// <response code="404">Se devuelve cuando el servicio no existe o se produce un error en la consulta.</response>
        [HttpGet("{id}")]
        [Authorize(Policy = "ConsultorOAdministrador")]
        public async Task<IActionResult> ObtenerServicio(int id)
        {
            var respuesta = await _unitOfWork.ServicioRepository.ObtenerServicioPorId(id);

            if (respuesta != null)
            {
                   
            return ResponseFactory.CreateSuccessResponse(200, respuesta);


            }
        return ResponseFactory.CreateErrorResponse(404, "Error al buscar el servicio, o servicio no existe");
        }


        /// <summary>
        /// Registra un nuevo servicio en el sistema.
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los administradores registrar un nuevo servicio en el sistema proporcionando los detalles del servicio.
        /// </remarks>
        /// <param name="servicioDto">Los detalles del servicio que se registrarán.</param>
        /// <returns>
        /// Una respuesta que indica si el servicio se registró con éxito o si se produjo un error en el proceso de registro.
        /// </returns>
        /// <response code="201">Se devuelve cuando el servicio se registra con éxito.</response>
        /// <response code="404">Se devuelve cuando se produce un error en el proceso de registro del servicio.</response>
        [HttpPost]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> InsertarServicio(ServicioDto servicioDto)
        {
            var respuesta = await _unitOfWork.ServicioRepository.InsertarServicio(servicioDto);
            if (respuesta)
            {
            return ResponseFactory.CreateSuccessResponse(201, "Servicio registrado con exito");
            }
                return ResponseFactory.CreateErrorResponse(404, "Error al ingresar el servicio");
        }



        /// <summary>
        /// Modifica un servicio existente en el sistema.
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los administradores modificar los detalles de un servicio existente en el sistema.
        /// </remarks>
        /// <param name="id">El identificador único del servicio que se modificará.</param>
        /// <param name="servicioDto">Los nuevos detalles del servicio.</param>
        /// <returns>
        /// Una respuesta que indica si el servicio se modificó con éxito o si se produjo un error en el proceso de modificación.
        /// </returns>
        /// <response code="200">Se devuelve cuando el servicio se modifica con éxito.</response>
        /// <response code="404">Se devuelve cuando se produce un error en el proceso de modificación del servicio.</response>
        [HttpPut("{id}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> ModificarServicio([FromRoute] int id, ServicioDto servicioDto)          
        {
            var respuesta = await _unitOfWork.ServicioRepository.ModificarServicio(new Servicio(servicioDto, id));
            if (respuesta)
            {
             return ResponseFactory.CreateSuccessResponse(200, "Servicio modificado con exito");
            }

             return ResponseFactory.CreateErrorResponse(404, "Error al modificar el servicio, asegurese que el servicio exista");
        }

        /// <summary>
        /// Elimina un servicio existente del sistema (borrado logico).
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los administradores eliminar permanentemente un servicio del sistema. Se debe proporcionar el ID del servicio que se desea eliminar.
        /// </remarks>
        /// <param name="id">El identificador único del servicio que se eliminará.</param>
        /// <returns>
        /// Una respuesta que indica si el servicio se eliminó con éxito o si se produjo un error en el proceso de eliminación.
        /// </returns>
        /// <response code="200">Se devuelve cuando el servicio se elimina con éxito.</response>
        /// <response code="404">Se devuelve cuando se produce un error en el proceso de eliminación del servicio.</response>
        [HttpDelete("{id}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> BorrarServicio(int id)
        {
            var respuesta = await _unitOfWork.ServicioRepository.BorrarServicio(id);

            if (respuesta)
            {
            return ResponseFactory.CreateSuccessResponse(200, "Servicio borrado con exito  (borrado Logico  isActive=false)");
            }
         return ResponseFactory.CreateErrorResponse(404, "No se puede borrar el servicio, consulte que exista el servicio que quiere borrar");
        }
    }
}
