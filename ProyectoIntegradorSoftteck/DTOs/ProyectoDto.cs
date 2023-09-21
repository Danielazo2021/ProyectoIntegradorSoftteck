using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.DTOs
{
    /// <summary>
    /// Clase de transferencia de datos (DTO) utilizada para representar la información de un proyecto.
    /// </summary>
    public class ProyectoDto
        {
     
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public Estado Estado { get; set; }
        }
}
