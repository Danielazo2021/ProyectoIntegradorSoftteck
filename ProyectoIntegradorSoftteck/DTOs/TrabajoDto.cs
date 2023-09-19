using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.DTOs
{
    /// <summary>
    /// Clase de transferencia de datos (DTO) utilizada para representar la información de un trabajo.
    /// </summary>
    public class TrabajoDto
    {
 
        public DateTime Fecha { get; set; }
        public int CodProyecto { get; set; }
        public int CodServicio { get; set; }
        public int CantHoras { get; set; }
        public double ValorHora { get; set; }
        public double Costo { get; set; }
        public int Cod_proyecto { get; set; }
        public int Cod_servicio { get; set; }   

    }
}
