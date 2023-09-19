using ProyectoIntegradorSoftteck.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegradorSoftteck.Entities
{
    /// <summary>
    /// Clase que representa un proyecto en la aplicación.
    /// </summary>
    [Table("projects")]
    public class Proyecto
    {
        /// <summary>
        /// Constructor de la clase con parámetros.
        /// </summary>
        /// <param name="dto">DTO con los datos del proyecto.</param>
        /// <param name="id">Identificador único del proyecto.</param>
        public Proyecto(ProyectoDto dto, int id)
        {
            CodProyecto = id;
            Nombre = dto.Nombre;
            Direccion = dto.Direccion;
            Estado = dto.Estado;

        }

        /// <summary>
        /// Constructor de la clase con parámetros.
        /// </summary>
        /// <param name="dto">DTO con los datos del proyecto.</param>
        public Proyecto(ProyectoDto dto)
        {
            Nombre = dto.Nombre;
            Direccion = dto.Direccion;
            Estado = dto.Estado;
                
        }
        /// <summary>
        /// Constructor vacío de la clase.
        /// </summary>
        public Proyecto()
        {
                
        }

        [Key]
        [Column("project_id")]
        public int CodProyecto { get; set; }

        [Required]
        [Column("name")]
        public string Nombre { get; set; }

        [Required]
        [Column("adress")]
        public string Direccion { get; set; }

        /// <summary>
        /// Estado del proyecto, puede ser "Pendiente," "Confirmado" o "Terminado."
        /// </summary>
        [Required]
        [Column("state")]
        public Estado Estado { get; set; }

      
    }
}
