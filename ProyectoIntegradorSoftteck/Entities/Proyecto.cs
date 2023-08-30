using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegradorSoftteck.Entities
{
    [Table("proyectos")]
    public class Proyecto
    {
        [Key]
        public int CodProyecto { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Estado { get; set; }
    }
}
