using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.DTOs
{
    /// <summary>
    /// Clase de transferencia de datos (DTO) utilizada para representar la información de un usuario.
    /// </summary>
    public class UsuarioDto
    {  
        public string Nombre { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Dni { get; set; }
        public Tipo Tipo { get; set; }
        public string Contrasena { get; set; }

    }
}
