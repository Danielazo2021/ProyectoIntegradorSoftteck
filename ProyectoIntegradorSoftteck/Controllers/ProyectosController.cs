﻿using AlkemyUmsa.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegradorSoftteck.DTOs;
using ProyectoIntegradorSoftteck.Entities;
using ProyectoIntegradorSoftteck.Services.Interfaces;
using System.Runtime.InteropServices;

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

        /// <summary>
        /// Obtiene una lista de todos los proyectos disponibles en la aplicación.
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los consultores y administradores obtener una lista completa de todos los proyectos registrados en la aplicación.
        /// </remarks>
        /// <returns>Una respuesta que contiene la lista de proyectos o un mensaje de error en caso de fallo.</returns>
        /// <response code="200">Se devuelve cuando la solicitud se procesa correctamente. Incluye la lista de proyectos.</response>
        /// <response code="400">Se devuelve cuando se produce un error durante la solicitud.</response>

        [HttpGet()]
        [Authorize(Policy = "ConsultorOAdministrador")]
        public async Task<IActionResult> ObtenerProyectos()
        {
            var respuesta = await _unitOfWork.ProyectoRepository.ObtenerProyectos();

            if (respuesta != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, respuesta);

            }
            return ResponseFactory.CreateErrorResponse(400, "Error al consultar lista de proyectos");

        }


        /// <summary>
        /// Obtiene una lista paginada de proyectos.
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los consultores y administradores obtener una lista paginada de proyectos registrados en la aplicación.
        /// </remarks>
        /// <param name="pagina">Número de página solicitada.</param>
        /// <param name="registrosPorPagina">Cantidad de registros por página.</param>
        /// <returns>
        /// Una respuesta que contiene la lista paginada de proyectos o un mensaje de error en caso de fallo.
        /// </returns>
        /// <response code="200">Se devuelve cuando la solicitud se procesa correctamente. Incluye la lista paginada de proyectos.</response>
        /// <response code="400">Se devuelve cuando se produce un error durante la solicitud.</response>
        [HttpGet("{pagina}/{registrosPorPagina}")]
        [Authorize(Policy = "ConsultorOAdministrador")]
        public async Task<IActionResult> ObtenerProyectosPaginado([FromRoute] int pagina, [FromRoute] int registrosPorPagina)
        {
            var respuesta = await _unitOfWork.ProyectoRepository.ObtenerProyectosPaginado(pagina, registrosPorPagina);

            if (respuesta != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, respuesta);

            }
            return ResponseFactory.CreateErrorResponse(400, "Error al consultar lista de proyectos");

        }


        /// <summary>
        /// Obtiene una lista de proyectos por estado.
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los consultores y administradores obtener una lista de proyectos que coinciden con un estado específico.
        /// </remarks>
        /// <param name="estado">El estado de los proyectos que se desean obtener.</param>
        /// <returns>
        /// Una respuesta que contiene la lista de proyectos que coinciden con el estado especificado o un mensaje de error en caso de fallo.
        /// </returns>
        /// <response code="200">Se devuelve cuando la solicitud se procesa correctamente. Incluye la lista de proyectos por estado.</response>
        /// <response code="400">Se devuelve cuando se produce un error durante la solicitud o no se encuentran proyectos con el estado especificado.</response>
         [HttpGet("por_estado")]
        [Authorize(Policy = "ConsultorOAdministrador")]
        public async Task<IActionResult> ObtenerProyectosPorEstado(Estado estado)
        {
            var respuesta = await _unitOfWork.ProyectoRepository.ObtenerProyectosPorEstado(estado);

            if (respuesta != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, respuesta);

            }
            return ResponseFactory.CreateErrorResponse(400, "Error al consultar lista de proyectos");

        }

        /// <summary>
        /// Obtiene un proyecto por su identificador único.
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los consultores y administradores buscar y obtener información detallada de un proyecto específico mediante su identificador único.
        /// </remarks>
        /// <param name="id">El identificador único del proyecto.</param>
        /// <returns>
        /// Una respuesta que contiene los detalles del proyecto o un mensaje de error en caso de fallo o si el proyecto no existe.
        /// </returns>
        /// <response code="200">Se devuelve cuando la solicitud se procesa correctamente. Incluye los detalles del proyecto.</response>
        /// <response code="404">Se devuelve cuando no se encuentra el proyecto especificado.</response>
        [HttpGet("{id}")]
        [Authorize(Policy = "ConsultorOAdministrador")]
        public async Task<IActionResult> ObtenerProyectoById([FromRoute] int id)
        {
            var respuesta = await _unitOfWork.ProyectoRepository.ObtenerProyectoPorId(id);

            if (respuesta != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, respuesta);
            }
           
            return ResponseFactory.CreateErrorResponse(404, "Error al buscar el proyecto, o proyecto no existe");
        }


        /// <summary>
        /// Registra un nuevo proyecto en la aplicación.
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los administradores registrar un nuevo proyecto en la aplicación.
        /// </remarks>
        /// <param name="proyecto">Los datos del proyecto que se desea registrar.</param>
        /// <returns>
        /// Una respuesta que indica si el proyecto se registró exitosamente o un mensaje de error en caso de fallo.
        /// </returns>
        /// <response code="200">Se devuelve cuando el proyecto se registra con éxito en la aplicación.</response>
        /// <response code="404">Se devuelve cuando se produce un error durante el registro del proyecto.</response>
        [HttpPost]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> InsertarProyecto(ProyectoDto proyecto)
        {

            var respuesta = await _unitOfWork.ProyectoRepository.InsertarProyecto(proyecto);
            if (respuesta)
            {
                return ResponseFactory.CreateSuccessResponse(200, "Proyecto registrado con exito");
                
            }
            return ResponseFactory.CreateErrorResponse(404, "Error al ingresar el proyecto");
        }


        /// <summary>
        /// Modifica un proyecto existente en la aplicación.
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los administradores modificar un proyecto existente en la aplicación mediante su identificador único.
        /// </remarks>
        /// <param name="id">El identificador único del proyecto que se desea modificar.</param>
        /// <param name="proyectoDto">Los nuevos datos del proyecto.</param>
        /// <returns>
        /// Una respuesta que indica si el proyecto se modificó exitosamente o un mensaje de error en caso de fallo o si el proyecto no existe.
        /// </returns>
        /// <response code="200">Se devuelve cuando el proyecto se modifica con éxito en la aplicación.</response>
        /// <response code="404">Se devuelve cuando se produce un error durante la modificación del proyecto o si el proyecto no existe.</response>
        [HttpPut("{id}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> ModificarProyecto([FromRoute] int id, ProyectoDto proyectoDto)
        {
            var respuesta = await _unitOfWork.ProyectoRepository.ModificarProyecto( new Proyecto (proyectoDto, id));
            if (respuesta)
            {
                return ResponseFactory.CreateSuccessResponse(200, "Proyecto modificado con exito");
            }

            return ResponseFactory.CreateErrorResponse(404, "Error al modificar el proyecto, asegurese que el proyecto exista");
        }

        /// <summary>
        /// Elimina un proyecto existente de la aplicación.
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los administradores eliminar un proyecto existente en la aplicación mediante su identificador único.
        /// </remarks>
        /// <param name="id">El identificador único del proyecto que se desea eliminar.</param>
        /// <returns>
        /// Una respuesta que indica si el proyecto se eliminó exitosamente o un mensaje de error en caso de fallo o si el proyecto no existe.
        /// </returns>
        /// <response code="200">Se devuelve cuando el proyecto se elimina con éxito en la aplicación.</response>
        /// <response code="404">Se devuelve cuando se produce un error durante la eliminación del proyecto o si el proyecto no existe.</response>
        [HttpDelete("{id}")]
        [Authorize(Policy = "Administrador")]
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
