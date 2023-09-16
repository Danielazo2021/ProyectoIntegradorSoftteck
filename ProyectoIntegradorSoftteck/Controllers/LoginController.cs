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
        /// Punto de ingreso para el Login de la aplicacion
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>devuelvio el login</returns>
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
