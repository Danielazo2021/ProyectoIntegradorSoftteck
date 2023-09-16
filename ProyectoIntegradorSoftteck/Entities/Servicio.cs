using ProyectoIntegradorSoftteck.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegradorSoftteck.Entities
{
    [Table("services")]
    public class Servicio
    {

        public Servicio(ServicioDto dto, int id)
        {
            CodServicio = id;
            Descr = dto.Descr;
            Estado = dto.Estado;
            ValorHora = dto.ValorHora;

        }
        public Servicio(ServicioDto dto)
        {
            Descr= dto.Descr;
            Estado= dto.Estado;
            ValorHora= dto.ValorHora;
            
        }

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
