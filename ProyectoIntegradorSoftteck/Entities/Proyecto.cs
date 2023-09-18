using ProyectoIntegradorSoftteck.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegradorSoftteck.Entities
{
    [Table("projects")]
    public class Proyecto
    {
        public Proyecto(ProyectoDto dto, int id)
        {
            CodProyecto = id;
            Nombre = dto.Nombre;
            Direccion = dto.Direccion;
            Estado = dto.Estado;

        }

        public Proyecto(ProyectoDto dto)
        {
            Nombre = dto.Nombre;
            Direccion = dto.Direccion;
            Estado = dto.Estado;
                
        }
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

        [Required]
        [Column("state")]
        public Estado Estado { get; set; }

      
    }
}
