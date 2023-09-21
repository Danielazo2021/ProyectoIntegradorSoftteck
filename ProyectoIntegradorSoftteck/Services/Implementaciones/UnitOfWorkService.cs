using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.DataAccess;
using ProyectoIntegradorSoftteck.DataAccess.Repository.Implementations;
using ProyectoIntegradorSoftteck.Services.Interfaces;

namespace ProyectoIntegradorSoftteck.Services.Implementaciones
{
    /// <summary>
    /// Implementación de la interfaz IUnitOfWork que proporciona acceso a los repositorios de entidades de la base de datos.
    /// </summary>
    public class UnitOfWorkService : IUnitOfWork
    {
        private readonly ContextDB _context;
        public UsuarioRepository UsuarioRepository { get; private set; }
        public ServicioRepository ServicioRepository { get; private set; }
        public TrabajoRepository TrabajoRepository { get; private set; }
        public ProyectoRepository ProyectoRepository { get; private set; }


        /// <summary>
        /// Inicializa una nueva instancia de la clase UnitOfWorkService con el contexto de base de datos proporcionado.
        /// </summary>
        /// <param name="context">El contexto de base de datos.</param>
        public UnitOfWorkService(ContextDB context)
        {
            _context = context;
            UsuarioRepository = new UsuarioRepository(_context);
            ServicioRepository = new ServicioRepository(_context);
            TrabajoRepository = new TrabajoRepository(_context);
            ProyectoRepository = new ProyectoRepository(_context);

        }
    }
}
