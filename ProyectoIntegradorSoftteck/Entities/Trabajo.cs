using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

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

        // [ForeignKey("IdMarca")]
        //public Marca Marca { get; set; }
        public int cod_proyecto { get; set; } 
        public int cod_servicio { get; set; }

    }
}
