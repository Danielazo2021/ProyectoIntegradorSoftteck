using ProyectoIntegradorSoftteck.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ProyectoIntegradorSoftteck.Entities
{
    /// <summary>
    /// Clase que representa un trabajo en la aplicación.
    /// </summary>
    [Table("works")]
    public class Trabajo
    {
        /// <summary>
        /// Constructor para crear un objeto Trabajo a partir de un objeto TrabajoDto.
        /// </summary>
        /// <param name="dto">Objeto TrabajoDto con los datos del trabajo.</param>
        public Trabajo(TrabajoDto dto)
        {
            Fecha = dto.Fecha;
            CantHoras = dto.CantHoras;
            ValorHora = dto.ValorHora;
            Costo = dto.Costo;
            Cod_servicio = dto.Cod_servicio;
            Cod_proyecto = dto.Cod_proyecto;
        }

        /// <summary>
        /// Constructor para crear un objeto Trabajo a partir de un objeto TrabajoDto y un ID específico.
        /// </summary>
        /// <param name="dto">Objeto TrabajoDto con los datos del trabajo.</param>
        /// <param name="id">ID único del trabajo.</param>
        public Trabajo(TrabajoDto dto, int id)
        {
            CodTrabajo = id;
            Fecha = dto.Fecha;
            CantHoras = dto.CantHoras;
            ValorHora = dto.ValorHora;
            Costo = dto.Costo;
            Cod_servicio = dto.Cod_servicio;
            Cod_proyecto = dto.Cod_proyecto;
        }


        /// <summary>
        /// Constructor sin argumentos requerido para Entity Framework.
        /// </summary>
        public Trabajo()
        {
                
        }


        [Key]
        [Column("work_id")]
        public int CodTrabajo { get; set; }

        [Required]
        [Column("date")]
        public DateTime Fecha { get; set; }

        [Required]
        [Column("count_hours")]
        public int CantHoras { get; set; }

        [Required]
        [Column("value_hour")]
        public double ValorHora { get; set; }

        [Required]
        [Column("cost")]
        public double Costo { get; set; }

       
        [Required]
        [Column("project_id")]
        public int Cod_proyecto { get; set; }
        [ForeignKey("Cod_proyecto")]
        public  Proyecto? Proyecto { get; set; }


        [Required]
        [Column("service_id")]
        public int Cod_servicio { get; set; }

        [ForeignKey("Cod_servicio")]
        public  Servicio? Servicio { get; set; }


    }
}
