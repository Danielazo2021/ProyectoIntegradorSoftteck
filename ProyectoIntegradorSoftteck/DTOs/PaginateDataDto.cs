namespace AlkemyUmsa.DTOs
{
    /// <summary>
    /// Clase utilizada como un Data Transfer Object (DTO) para representar datos paginados.
    /// </summary>
    /// <typeparam name="T">El tipo de elementos contenidos en la página paginada.</typeparam>
    public class PaginateDataDto<T>
    {
        /// <summary>
        /// Obtiene o establece el número de página actual.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Obtiene o establece el número de elementos por página.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Obtiene o establece el número total de páginas disponibles.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Obtiene o establece el número total de elementos en la lista completa (sin paginación).
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Obtiene o establece una URL que puede apuntar a la página anterior en la lista paginada (si está disponible).
        /// </summary>
        public string PrevUrl { get; set; }

        /// <summary>
        /// Obtiene o establece una URL que puede apuntar a la página siguiente en la lista paginada (si está disponible).
        /// </summary>
        public string NextUrl { get; set; }

        /// <summary>
        /// Obtiene o establece una lista de elementos de tipo T que representa los elementos de la página actual.
        /// </summary>
        public List<T> Items { get; set; }
    }

}
