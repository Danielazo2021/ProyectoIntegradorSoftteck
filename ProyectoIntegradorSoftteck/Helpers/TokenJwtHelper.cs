using Microsoft.IdentityModel.Tokens;
using ProyectoIntegradorSoftteck.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProyectoIntegradorSoftteck.Helpers
{
    public class TokenJwtHelper  
    {
        private IConfiguration _configuration;
        public TokenJwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Genera un token JWT (JSON Web Token) basado en la información de un usuario.
        /// </summary>
        /// <param name="usuario">El objeto de usuario que se utilizará para generar el token.</param>
        /// <returns>El token JWT generado como una cadena.</returns>
        public string GenerateToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]), 
                new Claim(ClaimTypes.NameIdentifier, usuario.CodUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuario.Tipo.ToString()),
                new Claim(ClaimTypes.Name , usuario.Nombre),



            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(securityToken); //devueve el token generado
        }

    }
}
