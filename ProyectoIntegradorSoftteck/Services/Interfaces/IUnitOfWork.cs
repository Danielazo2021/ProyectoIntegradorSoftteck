using ProyectoIntegradorSoftteck.DataAccess.Repository.Implementations;

namespace ProyectoIntegradorSoftteck.Services.Interfaces
{
    public interface IUnitOfWork
    {
        public UsuarioRepository UsuarioRepository { get; }
        public TrabajoRepository TrabajoRepository { get; }
        public ServicioRepository ServicioRepository { get; }
        public ProyectoRepository ProyectoRepository { get; }
    }
}
