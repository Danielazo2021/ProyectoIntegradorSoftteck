using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.DataAccess.Repository.Interfaces;
using ProyectoIntegradorSoftteck.Entities;
using System.Linq.Expressions;

namespace ProyectoIntegradorSoftteck.DataAccess.Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly ContextDB _context;

        public Repository(ContextDB context)
        {
            _context = context;
        }

        /// <summary>
        /// Borra una entidad de la fuente de datos por su código único.
        /// </summary>
        /// <typeparam name="T">El tipo de entidad que se desea borrar.</typeparam>
        /// <param name="cod">El código único de la entidad que se desea borrar.</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve un valor booleano.</para>
        ///   <para>Devuelve true si la entidad se borra con éxito en la fuente de datos.</para>
        ///   <para>Devuelve false si la entidad no se encuentra en la fuente de datos o si ocurre una excepción durante la operación.</para>
        /// </returns>

        public async Task<bool> Borrar(int cod)
        {
            var entity = await _context.Set<T>().FindAsync(cod);
            if (entity == null)
            {
                return false;
            }

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }


        /// <summary>
        /// Inserta una entidad en la fuente de datos.
        /// </summary>
        /// <typeparam name="T">El tipo de entidad que se desea insertar.</typeparam>
        /// <param name="entity">La entidad que se desea insertar en la fuente de datos.</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve un valor booleano.</para>
        ///   <para>Devuelve true si la entidad se inserta con éxito en la fuente de datos.</para>
        ///   <para>Devuelve false si la operación de inserción falla o si ocurre una excepción durante la operación.</para>
        /// </returns>
        public async Task<bool> Insertar(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            if (result == null)
            {
                return false;
            }

            await _context.SaveChangesAsync();
            return true;
        }


        /// <summary>
        /// Modifica una entidad existente en la fuente de datos.
        /// </summary>
        /// <typeparam name="T">El tipo de entidad que se desea modificar.</typeparam>
        /// <param name="entity">La entidad con los datos actualizados que se desea modificar en la fuente de datos.</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve un valor booleano.</para>
        ///   <para>Devuelve true si la entidad se modifica con éxito en la fuente de datos.</para>
        ///   <para>Devuelve false si la entidad original no se encuentra en la fuente de datos o si ocurre una excepción durante la operación.</para>
        /// </returns>

        public async Task<bool> Modificar(T entity)
        {
             var existingEntity = await _context.Set<T>().FindAsync(entity);
    
                if (existingEntity == null)
                {
                    return false; 
                }

                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                
                await _context.SaveChangesAsync();
                return true;
                        
        }


        /// <summary>
        /// Obtiene una entidad por su código único (DNI en este caso).
        /// </summary>
        /// <typeparam name="T">El tipo de entidad que se desea obtener.</typeparam>
        /// <param name="cod">El código único (DNI) de la entidad que se desea obtener.</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve una entidad del tipo especificado.</para>
        ///   <para>La entidad obtenida representa el objeto con el código único (DNI) especificado.</para>
        ///   <para>Si no se encuentra ninguna entidad con el código proporcionado, devuelve null.</para>
        /// </returns>

        public async Task<T> ObtenerPorDni(int cod)
        {           
             var entity = await _context.Set<T>().FindAsync(cod);
            return entity;
        }



        /// <summary>
        /// Obtiene una lista de todas las entidades del tipo especificado desde la fuente de datos.
        /// </summary>
        /// <typeparam name="T">El tipo de entidad que se desea obtener.</typeparam>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve una lista de entidades del tipo especificado.</para>
        ///   <para>La lista contiene todas las entidades del tipo especificado obtenidas desde la fuente de datos.</para>
        ///   <para>Si no se encuentran entidades del tipo especificado, la lista puede estar vacía.</para>
        /// </returns>
        public async Task<List<T>> ObtenerTodos() 
        {
            var prueba = await _context.Set<T>().ToListAsync();
            return prueba;
        }


        /// <summary>
        /// Obtiene una lista paginada de entidades del tipo especificado desde la fuente de datos.
        /// </summary>
        /// <typeparam name="T">El tipo de entidad que se desea obtener.</typeparam>
        /// <param name="pagina">El número de página deseado (comenzando desde 1).</param>
        /// <param name="registrosPorPagina">La cantidad de registros por página.</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve una lista paginada de entidades del tipo especificado.</para>
        ///   <para>La lista contiene las entidades del tipo especificado obtenidas desde la fuente de datos para la página y cantidad de registros especificados.</para>
        ///   <para>Si no se encuentran entidades del tipo especificado o si los valores de página o registrosPorPagina son inválidos, la lista puede estar vacía.</para>
        /// </returns>

        public async Task<List<T>> ObtenerTodosPaginado(int pagina, int registrosPorPagina) // modif
        {
            var prueba = await _context.Set<T>().ToListAsync();
            return prueba;
        }

    }
}
