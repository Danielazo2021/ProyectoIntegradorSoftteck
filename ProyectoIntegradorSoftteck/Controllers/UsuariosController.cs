
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

    public class UsuariosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuariosController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// Obtiene una lista paginada de usuarios.
        /// </summary>
        /// <remarks>
        /// Este endpoint permite obtener una lista paginada de usuarios. Se requiere autorización como "ConsultorOAdministrador" para acceder a esta función.
        /// </remarks>
        /// <param name="pag">Número de página para la paginación (opcional).</param>
        /// <returns>Una respuesta HTTP con la lista paginada de usuarios.</returns>
        /// <response code="200">Se ha obtenido la lista paginada de usuarios correctamente.</response>
        /// <response code="401">No se ha autorizado el acceso a esta función.</response>
        /// <response code="500">Se ha producido un error interno en el servidor.</response>

        [HttpGet()]
        [Authorize(Policy = "ConsultorOAdministrador")]
        public async Task<IActionResult> ObtenerUsuarios(int?pag)
        {
            try
            {
                var usuarios = await _unitOfWork.UsuarioRepository.ObtenerUsuarios();
                int pageToShow = pag == null ? 1 : (int)pag;

                if (Request.Query.ContainsKey("page")) int.TryParse(Request.Query["page"], out pageToShow);

                var url = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}").ToString();

                var paginateUsuarios = PaginateHelper.Paginate(usuarios, pageToShow, url);

                return ResponseFactory.CreateSuccessResponse(200, paginateUsuarios);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateErrorResponse(500, "Se ha producido un error interno en el servidor.", ex.Message);
            }
        }


        /// <summary>
        /// Obtiene un usuario por su identificador único.
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los consultores y administradores obtener información detallada de un usuario en función de su ID único.
        /// </remarks>
        /// <param name="id">El identificador único del usuario que se desea obtener.</param>
        /// <returns>
        /// Una respuesta que contiene los datos del usuario si se encuentra en el sistema.
        /// </returns>
        /// <response code="200">Se devuelve cuando el usuario se encuentra y se obtiene con éxito.</response>
        /// <response code="404">Se devuelve si el usuario no se encuentra en el sistema o si se produce un error al buscarlo.</response>
        [HttpGet("{id}")]
        [Authorize(Policy = "ConsultorOAdministrador")]
        public async Task<IActionResult> ObtenerUsuario(int id)
        {
            var respuesta = await _unitOfWork.UsuarioRepository.ObtenerUsuarioPorId(id);

            if (respuesta != null)
            {
                return ResponseFactory.CreateSuccessResponse(200, respuesta);
            }
            return ResponseFactory.CreateErrorResponse(404, "Error al buscar el usuario, o usuario no existe");
        }


        /// <summary>
        /// Registra un nuevo usuario en el sistema.
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los administradores agregar un nuevo usuario al sistema proporcionando los datos requeridos.
        /// </remarks>
        /// <param name="usuarioDto">Los datos del usuario que se va a registrar.</param>
        /// <returns>
        /// Una respuesta que indica si el usuario se registró con éxito.
        /// </returns>
        /// <response code="201">Se devuelve cuando el usuario se registra con éxito en el sistema.</response>
        /// <response code="404">Se devuelve si se produce un error al intentar registrar al usuario o si los datos son inválidos.</response>
        [HttpPost]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> InsertarUsuario(UsuarioDto usuarioDto)
        {

            var respuesta = await _unitOfWork.UsuarioRepository.InsertarUsuario(usuarioDto);
            if (respuesta)
            {
                return ResponseFactory.CreateSuccessResponse(201, "Usuario registrado con exito");
            }
            return ResponseFactory.CreateErrorResponse(404, "Error al ingresar el usuario");
        }



        /// <summary>
        /// Modifica los datos de un usuario existente en el sistema.
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los administradores modificar los datos de un usuario existente en el sistema.
        /// </remarks>
        /// <param name="id">El ID del usuario que se va a modificar.</param>
        /// <param name="usuarioDto">Los nuevos datos del usuario.</param>
        /// <returns>
        /// Una respuesta que indica si los datos del usuario se modificaron con éxito.
        /// </returns>
        /// <response code="200">Se devuelve cuando los datos del usuario se modifican con éxito en el sistema.</response>
        /// <response code="404">Se devuelve si se produce un error al intentar modificar al usuario o si el usuario no existe.</response>
        [HttpPut("{id}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> ModificarUsuario([FromRoute] int id, UsuarioDto usuarioDto)        
        {
            var respuesta = await _unitOfWork.UsuarioRepository.ModificarUsuario(new Usuario(usuarioDto, id));
            if (respuesta)
            {
                return ResponseFactory.CreateSuccessResponse(200, "Usuario modificado con exito");
            }

            return ResponseFactory.CreateErrorResponse(404, "Error al modificar el usuario, asegurese que el usuario exista");
        }

        /// <summary>
        /// Elimina un usuario del sistema.
        /// </summary>
        /// <remarks>
        /// Esta acción permite a los administradores eliminar un usuario existente en el sistema.
        /// </remarks>
        /// <param name="id">El ID del usuario que se va a eliminar.</param>
        /// <returns>
        /// Una respuesta que indica si el usuario se eliminó con éxito del sistema.
        /// </returns>
        /// <response code="200">Se devuelve cuando el usuario se elimina con éxito del sistema.</response>
        /// <response code="404">Se devuelve si se produce un error al intentar eliminar al usuario o si el usuario no existe.</response>
        [HttpDelete("{id}")]
        [Authorize(Policy = "Administrador")]
        public async Task<IActionResult> BorrarUsuario(int id)
        {
            var respuesta = await _unitOfWork.UsuarioRepository.BorrarUsuario(id);

            if (respuesta)
            {
                return ResponseFactory.CreateSuccessResponse(200, "Usuario borrado con exito");
            }
            return ResponseFactory.CreateErrorResponse(404, "No se puede borrar el usuario, consulte que exista el usuario que quiere borrar");
        }
    }
}
