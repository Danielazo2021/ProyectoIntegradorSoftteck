namespace ProyectoIntegradorSoftteck.DTOs
{
    /// <summary>
    /// Clase de transferencia de datos (DTO) utilizada para autenticar a un usuario.
    /// </summary>
    public class AuthenticateDto
    {
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
    }
}
