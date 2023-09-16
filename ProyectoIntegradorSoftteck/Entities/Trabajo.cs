using ProyectoIntegradorSoftteck.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ProyectoIntegradorSoftteck.Entities
{
    
    [Table("works")]
    public class Trabajo
    {

        public Trabajo(TrabajoDto dto)
        {
            Fecha = dto.Fecha;
            CantHoras = dto.CantHoras;
            ValorHora = dto.ValorHora;
            Costo = dto.Costo;
            Cod_servicio = dto.Cod_servicio;
            Cod_proyecto = dto.Cod_proyecto;
        }
      
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
        public virtual Proyecto? Proyecto { get; set; }


        [Required]
        [Column("service_id")]
        public int Cod_servicio { get; set; }
        public virtual Servicio? Servicio { get; set; }


    }
}
