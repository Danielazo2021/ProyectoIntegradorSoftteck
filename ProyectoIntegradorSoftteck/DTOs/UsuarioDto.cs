namespace ProyectoIntegradorSoftteck.DTOs
{
    public class UsuarioDto
    {
       // public int CodUsuario { get; set; }  // como dto no lo necesito, y para el put usamos el entity para tenerlo o haremos 2 dtos distintos
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public int Tipo { get; set; }
        public string Contrasena { get; set; }

    }
}
