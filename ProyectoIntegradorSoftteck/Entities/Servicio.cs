using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegradorSoftteck.Entities
{
    [Table("servicios")]
    public class Servicio
    {
        [Key]
        public int CodServicio { get; set; }
        public string Descr { get; set; }
        public bool Estado { get; set; }
        public double ValorHora { get; set; }
       
    }
}
