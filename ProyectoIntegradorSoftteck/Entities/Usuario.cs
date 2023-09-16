using ProyectoIntegradorSoftteck.DTOs;
using ProyectoIntegradorSoftteck.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegradorSoftteck.Entities
{
    [Table("users")]
    public class Usuario
    {
        public Usuario(UsuarioDto dto, int id)
        {
            CodUsuario = id;
            Nombre = dto.Nombre;
            Dni = dto.Dni;
            Tipo = dto.Tipo;
            Contrasena = PasswordEncryptHelper.EncryptPassword(dto.Contrasena, dto.Nombre);

        }
        public Usuario(UsuarioDto dto)
        {
            Nombre = dto.Nombre;
            Dni= dto.Dni;
            Tipo = dto.Tipo;
            Contrasena = PasswordEncryptHelper.EncryptPassword(dto.Contrasena, dto.Nombre);

        }
        public Usuario()
        {


        }


        [Key]
        [Column("user_id")]
        public int CodUsuario{ get; set; }

        [Required]
        [Column("name")]
        public string Nombre { get; set; }

        [Required]
        [Column("dni")]
        public int Dni { get; set; }

        [Required]
        [Column("type")]
        public Tipo Tipo { get; set; }

        [Required]
        [Column("password")]
        public string Contrasena { get; set; }

    }
}
