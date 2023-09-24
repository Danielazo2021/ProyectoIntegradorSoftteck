﻿using AlkemyUmsa.DTOs;

namespace AlkemyUmsa.Helper
{
    /// <summary>
    /// Clase de utilidad para la paginación de listas de elementos.
    /// </summary>
    public static class PaginateHelper
    {

        /// <summary>
        /// Realiza la paginación de una lista de elementos y genera un objeto PaginateDataDto.
        /// </summary>
        /// <typeparam name="T">El tipo de elementos contenidos en la lista.</typeparam>
        /// <param name="itemsToPaginate">La lista de elementos a paginar.</param>
        /// <param name="currentPage">El número de página actual.</param>
        /// <param name="url">La URL base utilizada para construir las URL de página anterior y siguiente.</param>
        /// <returns>Un objeto PaginateDataDto que contiene los datos paginados.</returns>

        public static PaginateDataDto<T> Paginate<T>(List<T> itemsToPaginate,  int currentPage, string url)
        {
            int pageSize = 3;
            var totalItems = itemsToPaginate.Count;
            var totalPages = (int)Math.Ceiling((double) totalItems / pageSize);

            var paginateItems = itemsToPaginate.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            var prevUrl = currentPage > 1 ? $"{url}?page={currentPage - 1}" : null;
            var nextUrl = currentPage < totalPages ? $"{url}?page={currentPage + 1}" : null;


            // Crea y devuelve un objeto PaginateDataDto con los datos paginados y la información de navegación.
            return new PaginateDataDto<T>()
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                PrevUrl = prevUrl,
                NextUrl = nextUrl,
                Items = paginateItems
            };


        }
    }
}
