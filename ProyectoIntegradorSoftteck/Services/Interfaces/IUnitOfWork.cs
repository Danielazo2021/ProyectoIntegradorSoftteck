using ProyectoIntegradorSoftteck.DataAccess.Repository.Implementations;

namespace ProyectoIntegradorSoftteck.Services.Interfaces
{
    /// <summary>
    /// Define una interfaz para acceder a los repositorios relacionados con las entidades de la base de datos.
    /// </summary>
    public interface IUnitOfWork
    {
        public UsuarioRepository UsuarioRepository { get; }
        public TrabajoRepository TrabajoRepository { get; }
        public ServicioRepository ServicioRepository { get; }
        public ProyectoRepository ProyectoRepository { get; }
    }
}
