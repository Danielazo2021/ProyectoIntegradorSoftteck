using ProyectoIntegradorSoftteck.DTOs;
using ProyectoIntegradorSoftteck.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoIntegradorSoftteck.Entities
{
    /// <summary>
    /// Clase que representa un usuario en la aplicación.
    /// </summary>
    
    [Table("users")]
    public class Usuario
    {
     
        /// <summary>
        /// Constructor para crear un objeto Usuario a partir de un objeto UsuarioDto.
        /// </summary>
        /// <param name="dto">Objeto UsuarioDto con los datos del usuario.</param>
        
        public Usuario(UsuarioDto dto, int id)
        {
            CodUsuario = id;
            Nombre = dto.Nombre;
            UserName = dto.UserName;
            Email = dto.Email;
            Dni = dto.Dni;
            Tipo = dto.Tipo;
            Contrasena = PasswordEncryptHelper.EncryptPassword(dto.Contrasena, dto.Nombre);

        }

        /// <summary>
        /// Constructor para crear un objeto Usuario a partir de un objeto UsuarioDto y un ID específico.
        /// </summary>
        /// <param name="dto">Objeto UsuarioDto con los datos del usuario.</param>
        /// <param name="id">ID único del usuario.</param>
        public Usuario(UsuarioDto dto)
        {
            Nombre = dto.Nombre;
            UserName = dto.UserName;
            Email = dto.Email;
            Dni = dto.Dni;
            Tipo = dto.Tipo;
            Contrasena = PasswordEncryptHelper.EncryptPassword(dto.Contrasena, dto.Nombre);

        }

        /// <summary>
        /// Constructor sin argumentos requerido para Entity Framework.
        /// </summary>
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
        [Column("user_name")]
        public string UserName { get; set; }
        [Required]

        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("dni")]
        public int Dni { get; set; }

        [Required]
        [Column("type")]
        public Tipo Tipo { get; set; }

        [Required]
        [Column("password")]
        public string Contrasena { get; set; }

        [Required]
        [Column("is_active")]
        public bool IsActive { get; set; } = true;


    }
}
