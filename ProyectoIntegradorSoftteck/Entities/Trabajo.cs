using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegradorSoftteck.Entities
{
    [Table("trabajos")]
    public class Trabajo
    {
        [Key]
        public int CodTrabajo { get; set; }
        public DateTime Fecha { get; set; }  
        public int CantHoras { get; set; }
        public double ValorHora { get; set; }
        public double Costo { get; set; }


        [ForeignKey("CodProyecto")]
        public Proyecto proyecto { get; set; }

        [ForeignKey("CodServicio")]
        public List<Servicio> servicio { get; set; }

    }
}
