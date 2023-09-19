using AlkemyUmsa.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegradorSoftteck.DTOs;
using ProyectoIntegradorSoftteck.Helpers;
using ProyectoIntegradorSoftteck.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoIntegradorSoftteck.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private TokenJwtHelper _tokenJwtHelper;
        private readonly IUnitOfWork _unitOfWork;
        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _tokenJwtHelper = new TokenJwtHelper(configuration);
        }

        /// <summary>
        /// Punto de ingreso para el Login de la aplicación.
        /// </summary>
        /// <remarks>
        /// Permite a los usuarios autenticarse en la aplicación proporcionando sus credenciales.
        /// </remarks>
        /// <param name="dto">Los datos de autenticación del usuario.</param>
        /// <returns>Devuelve el usuario con el Token JWT si la autenticación es exitosa o un mensaje de error si las credenciales son incorrectas.</returns>
        /// <response code="200">Se devuelve cuando la autenticación es exitosa. Incluye el usuario autenticado y el Token JWT.</response>
        /// <response code="401">Se devuelve cuando las credenciales son incorrectas o la autenticación falla.</response>
        [HttpPost]
        [AllowAnonymous]
    
        public async Task<IActionResult> Login(AuthenticateDto dto)
        {
            var userCredentials = await _unitOfWork.UsuarioRepository.AuthenticateCredentials(dto);
            if (userCredentials is null)
            {
                return ResponseFactory.CreateErrorResponse (401, "Las credenciales son incorrectas");
                
            }
            var token = _tokenJwtHelper.GenerateToken(userCredentials);

            var user = new UsuarioLoginDto()
            {
               Nombre = dto.Nombre,
                Token = token
            };

            return ResponseFactory.CreateSuccessResponse(200, user);
          

        }
    }
}
