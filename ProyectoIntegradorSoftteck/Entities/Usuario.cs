using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegradorSoftteck.Entities
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        public int CodUsuario{ get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public int Tipo { get; set; }
        public string Contrasena { get; set; }

    }
}
