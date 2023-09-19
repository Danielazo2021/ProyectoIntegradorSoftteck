using ProyectoIntegradorSoftteck.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegradorSoftteck.Entities
{
    /// <summary>
    /// Clase que representa un servicio en la aplicación.
    /// </summary>
    [Table("services")]
    public class Servicio
    {
        /// <summary>
        /// Constructor de la clase con parámetros.
        /// </summary>
        /// <param name="dto">DTO con los datos del servicio.</param>
        /// <param name="id">Identificador único del servicio.</param>
        public Servicio(ServicioDto dto, int id)
        {
            CodServicio = id;
            Descr = dto.Descr;
            Estado = dto.Estado;
            ValorHora = dto.ValorHora;

        }

        /// <summary>
        /// Constructor de la clase con parámetros.
        /// </summary>
        /// <param name="dto">DTO con los datos del servicio.</param>
        public Servicio(ServicioDto dto)
        {
            Descr= dto.Descr;
            Estado= dto.Estado;
            ValorHora= dto.ValorHora;
            
        }

        /// <summary>
        /// Constructor vacío de la clase.
        /// </summary>
        public Servicio()
        {
            
        }


        [Key]
        [Column("service_id")]
        public int CodServicio { get; set; }

        [Required]
        [Column("description")]
        public string Descr { get; set; }

        [Required]
        [Column("state")]
        public bool Estado { get; set; }

        [Required]
        [Column("value_hour")]
        public double ValorHora { get; set; }
       
    }
}
