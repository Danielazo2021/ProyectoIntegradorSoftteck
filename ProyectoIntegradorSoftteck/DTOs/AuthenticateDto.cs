namespace ProyectoIntegradorSoftteck.DTOs
{
    /// <summary>
    /// Clase de transferencia de datos (DTO) utilizada para autenticar a un usuario.
    /// </summary>
    public class AuthenticateDto
    {
       
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
    }
}
