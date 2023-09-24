using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.DataAccess.Repository.Interfaces
{

    /// <summary>
    /// Interfaz genérica para definir operaciones comunes de un repositorio en la fuente de datos.
    /// </summary>
    /// <typeparam name="T">El tipo de entidad que se manejará en el repositorio.</typeparam>
    
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Inserta una entidad en la fuente de datos.
        /// </summary>
        /// <param name="entity">La entidad que se desea insertar.</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve un valor booleano.</para>
        ///   <para>Devuelve true si la inserción de la entidad es exitosa en la fuente de datos.</para>
        ///   <para>Devuelve false si la inserción falla o si ocurre una excepción durante la operación.</para>
        /// </returns>
        Task<bool> Insertar(T entity);


        /// <summary>
        /// Obtiene una entidad por su código único (cod) de la fuente de datos.
        /// </summary>
        /// <param name="cod">El código único de la entidad que se desea obtener.</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve un objeto de tipo T.</para>
        ///   <para>El objeto T obtenido de la fuente de datos.</para>
        ///   <para>Si no se encuentra ningún objeto con el código proporcionado o si ocurre una excepción durante la operación, se devuelve null.</para>
        /// </returns>
        Task<T> ObtenerPorDni(int cod);

        /// <summary>
        /// Obtiene una lista de todas las entidades de tipo T en la fuente de datos.
        /// </summary>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve una lista de objetos de tipo T.</para>
        ///   <para>La lista de objetos T obtenida de la fuente de datos.</para>
        ///   <para>Si no se encuentran objetos o si ocurre una excepción durante la operación, se devuelve una lista vacía.</para>
        /// </returns>
        Task<List<T>> ObtenerTodos();

        /// <summary>
        /// Borra una entidad de la fuente de datos por su código único (cod).
        /// </summary>
        /// <param name="cod">El código único (cod) de la entidad que se desea borrar.</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve un valor booleano.</para>
        ///   <para>Devuelve true si el borrado de la entidad es exitoso en la fuente de datos.</para>
        ///   <para>Devuelve false si el borrado falla, si la entidad no se encuentra o si ocurre una excepción durante la operación.</para>
        /// </returns>
        Task<bool> Borrar(int cod);

        /// <summary>
        /// Modifica una entidad en la fuente de datos.
        /// </summary>
        /// <param name="entity">La entidad con los datos actualizados que se desea modificar.</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve un valor booleano.</para>
        ///   <para>Devuelve true si la modificación de la entidad es exitosa en la fuente de datos.</para>
        ///   <para>Devuelve false si la modificación falla, si la entidad original no se encuentra o si ocurre una excepción durante la operación.</para>
        /// </returns>
        Task<bool> Modificar(T entity);

    }
}
