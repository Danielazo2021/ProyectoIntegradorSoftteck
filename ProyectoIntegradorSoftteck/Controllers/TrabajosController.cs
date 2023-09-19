using AlkemyUmsa.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    
    public class TrabajosController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public TrabajosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Obtiene una lista de todos los trabajos registrados en el sistema.
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los consultores y administradores obtener una lista completa de todos los trabajos registrados en el sistema.
        /// </remarks>
        /// <returns>
        /// Una respuesta que contiene la lista de trabajos o un mensaje de error si no se pudo obtener la lista.
        /// </returns>
        /// <response code="200">Se devuelve cuando se obtiene la lista de trabajos con éxito.</response>
        /// <response code="404">Se devuelve cuando no se pudo obtener la lista de trabajos.</response>
        [HttpGet()]
        [Authorize(Policy = "ConsultorOAdministrador")]
        public async Task<IActionResult> ObtenerTrabajos()
        {
            var respuesta = await _unitOfWork.TrabajoRepository.ObtenerTrabajos();

            if (respuesta != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, respuesta);
            }
            return ResponseFactory.CreateErrorResponse(404, "Error al consultar lista de trabajos");
        }

        /// <summary>
        /// Obtiene una lista paginada de trabajos registrados en el sistema.
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los consultores y administradores obtener una lista paginada de trabajos registrados en el sistema, según los parámetros proporcionados.
        /// </remarks>
        /// <param name="pagina">El número de página deseado.</param>
        /// <param name="registrosPorPagina">El número de registros por página.</param>
        /// <returns>
        /// Una respuesta que contiene la lista paginada de trabajos o un mensaje de error si no se pudo obtener la lista.
        /// </returns>
        /// <response code="200">Se devuelve cuando se obtiene la lista paginada de trabajos con éxito.</response>
        /// <response code="404">Se devuelve cuando no se pudo obtener la lista paginada de trabajos.</response>
        [HttpGet("{pagina}/{registrosPorPagina}")]
        [Authorize(Policy = "ConsultorOAdministrador")]
        public async Task<IActionResult> ObtenerTrabajosPaginado([FromRoute] int pagina, [FromRoute] int registrosPorPagina)
        {
            var respuesta = await _unitOfWork.TrabajoRepository.ObtenerTrabajosPaginado(pagina, registrosPorPagina);

            if (respuesta != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, respuesta);
            }
            return ResponseFactory.CreateErrorResponse(404, "Error al consultar lista de trabajos");
        }



        /// <summary>
        /// Obtiene un trabajo específico por su identificador.
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los consultores y administradores obtener los detalles de un trabajo registrado en el sistema mediante su identificador único.
        /// </remarks>
        /// <param name="id">El identificador único del trabajo que se desea obtener.</param>
        /// <returns>
        /// Una respuesta que contiene los detalles del trabajo o un mensaje de error si no se pudo encontrar el trabajo con el identificador proporcionado.
        /// </returns>
        /// <response code="200">Se devuelve cuando se obtienen los detalles del trabajo con éxito.</response>
        /// <response code="404">Se devuelve cuando no se pudo encontrar el trabajo con el identificador proporcionado.</response>
        [HttpGet("{id}")]
        [Authorize(Policy = "ConsultorOAdministrador")]
        public async Task<IActionResult> ObtenerTrabajo(int id)
        {
            var respuesta = await _unitOfWork.TrabajoRepository.ObtenerTrabajoPorId(id);

            if (respuesta != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, respuesta);
            }
            return ResponseFactory.CreateErrorResponse(404, "Error al buscar el trabajo, o trabajo no existe");
        }


        /// <summary>
        /// Registra un nuevo trabajo en el sistema.
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los administradores registrar un nuevo trabajo en el sistema proporcionando los detalles del trabajo, como su nombre, descripción, fecha de inicio y fecha de finalización.
        /// </remarks>
        /// <param name="trabajoDto">Los detalles del trabajo que se desea registrar.</param>
        /// <returns>
        /// Una respuesta que indica si el trabajo se registró con éxito o si hubo un error en el proceso.
        /// </returns>
        /// <response code="200">Se devuelve cuando el trabajo se registra con éxito en el sistema.</response>
        /// <response code="404">Se devuelve cuando se produce un error al intentar registrar el trabajo.</response>
        [HttpPost]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> InsertarTrabajo(TrabajoDto trabajoDto)
        {

            var respuesta = await _unitOfWork.TrabajoRepository.InsertarTrabajo(trabajoDto);
            if (respuesta)
            {
                return ResponseFactory.CreateSuccessResponse(200, "Trabajo registrado con exito");
            }
            return ResponseFactory.CreateErrorResponse(404, "Error al ingresar el trabajo");
        }



        /// <summary>
        /// Modifica los detalles de un trabajo existente en el sistema.
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los administradores actualizar los detalles de un trabajo existente en el sistema, identificado por su ID único. Los detalles que se pueden modificar incluyen el nombre, la descripción, la fecha de inicio y la fecha de finalización del trabajo.
        /// </remarks>
        /// <param name="id">El ID único del trabajo que se desea modificar.</param>
        /// <param name="trabajoDto">Los nuevos detalles del trabajo que se utilizarán para la modificación.</param>
        /// <returns>
        /// Una respuesta que indica si el trabajo se modificó con éxito o si hubo un error en el proceso.
        /// </returns>
        /// <response code="200">Se devuelve cuando el trabajo se modifica con éxito en el sistema.</response>
        /// <response code="404">Se devuelve cuando se produce un error al intentar modificar el trabajo o si el trabajo no existe.</response>
        [HttpPut("{id}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> ModificarTrabajo([FromRoute] int id, TrabajoDto trabajoDto)
        {
            var respuesta = await _unitOfWork.TrabajoRepository.ModificarTrabajo(new Trabajo (trabajoDto, id));
            if (respuesta)
            {
                return ResponseFactory.CreateSuccessResponse(200, "Trabajo modificado con exito");
            }

            return ResponseFactory.CreateErrorResponse(404, "Error al modificar el trabajo, asegurese que el trabajo exista");
        }

        /// <summary>
        /// Elimina un trabajo del sistema.
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los administradores eliminar un trabajo específico del sistema utilizando su ID único. Una vez eliminado, el trabajo no se podrá recuperar. Asegúrese de proporcionar el ID correcto del trabajo que desea eliminar.
        /// </remarks>
        /// <param name="id">El ID único del trabajo que se desea eliminar.</param>
        /// <returns>
        /// Una respuesta que indica si el trabajo se eliminó con éxito o si hubo un error en el proceso.
        /// </returns>
        /// <response code="200">Se devuelve cuando el trabajo se elimina con éxito del sistema.</response>
        /// <response code="404">Se devuelve cuando se produce un error al intentar eliminar el trabajo o si el trabajo no existe.</response>
        [HttpDelete("{id}")]
        [Authorize(Policy = "Administrador")]
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
