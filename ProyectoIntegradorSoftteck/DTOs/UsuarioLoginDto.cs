﻿namespace ProyectoIntegradorSoftteck.DTOs
{
    /// <summary>
    /// Clase de transferencia de datos (DTO) utilizada para representar la información de inicio de sesión de un usuario.
    /// </summary>
    public class UsuarioLoginDto
    {
        public string UserName { get; set; }      
        public string Email { get; set; }      
        public string Token { get; set; }

    }
}
