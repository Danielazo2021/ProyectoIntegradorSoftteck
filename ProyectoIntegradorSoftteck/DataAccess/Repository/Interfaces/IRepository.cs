using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.DataAccess.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<bool> Insertar(T entity);
        Task<T> ObtenerPorDni(int dni);
        Task<List<T>> ObtenerTodos(); 
      
        Task<bool> Borrar(int dni);
        Task<bool> Modificar(T entity);

    }
}
