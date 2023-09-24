using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.DataAccess.Repository.Interfaces;
using ProyectoIntegradorSoftteck.DTOs;
using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.DataAccess.Repository.Implementations
{
    public class ServicioRepository : Repository<Servicio>, IServicioRepository
    {      
        public ServicioRepository(ContextDB context) : base(context)
        {

        }


        /// <summary>
        /// Obtiene una lista de servicios desde la fuente de datos.
        /// </summary>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve una lista de objetos de tipo Servicio.</para>
        ///   <para>La lista contiene los servicios obtenidos desde la fuente de datos.</para>
        ///   <para>Si no se encuentran servicios en la fuente de datos, la lista puede estar vacía.</para>
        ///   <para>Si ocurre una excepción durante la operación, la lista puede estar vacía.</para>
        /// </returns>
        public async Task<List<Servicio>> ObtenerServicios()
        {
            List<Servicio> listaServicios = new List<Servicio>();
            try
            {
                listaServicios = await _context.Servicios.ToListAsync();
            }
            catch (Exception)
            {
            }
            return listaServicios;
        }


        /// <summary>
        /// Obtiene un servicio por su identificador único (código).
        /// </summary>
        /// <param name="cod">El código único del servicio que se desea obtener.</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve un objeto de tipo Servicio.</para>
        ///   <para>El objeto representa el servicio obtenido por su código único.</para>
        ///   <para>Si no se encuentra ningún servicio con el código proporcionado, se devuelve null.</para>
        ///   <para>Si ocurre una excepción durante la operación, se devuelve null.</para>
        /// </returns>
        public async Task<Servicio> ObtenerServicioPorId(int cod)
        {
            try
            {
                var servicio = await _context.Servicios.FirstOrDefaultAsync(serv => serv.CodServicio == cod);
                if (servicio != null)
                {
                    return servicio;
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }



        /// <summary>
        /// Obtiene una lista de servicios activos desde la fuente de datos.
        /// </summary>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve una lista de objetos de tipo Servicio.</para>
        ///   <para>La lista contiene los servicios activos obtenidos desde la fuente de datos.</para>
        ///   <para>Si no se encuentran servicios activos en la fuente de datos, la lista puede estar vacía.</para>
        ///   <para>Si ocurre una excepción durante la operación, la lista puede estar vacía.</para>
        /// </returns>
        public async Task<List<Servicio>> ObtenerServiciosActivos()
        {
            List<Servicio> listaServicios = new List<Servicio>();
            try
            {
                listaServicios = await _context.Servicios.Where(x=>x.Estado== true).ToListAsync();
            }
            catch (Exception)
            {
            }
            return listaServicios;
        }


        /// <summary>
        /// Inserta un nuevo servicio en la fuente de datos.
        /// </summary>
        /// <param name="servicioDto">Un objeto de tipo ServicioDto que contiene los datos del servicio a insertar.</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve un valor booleano.</para>
        ///   <para>Devuelve true si el servicio se inserta con éxito en la fuente de datos.</para>
        ///   <para>Devuelve false si ocurre una excepción durante la operación o si la inserción falla.</para>
        /// </returns>
        public async Task<bool> InsertarServicio(ServicioDto servicioDto)
        {
            bool respuesta;
            try
            {
                var servicioNvo = new Servicio(servicioDto);

                _context.Servicios.Add(servicioNvo);
                await _context.SaveChangesAsync();
                respuesta = true;

            }
            catch (Exception)
            {
                respuesta = false;
            }

            return respuesta;
        }


        /// <summary>
        /// Modifica un servicio existente en la fuente de datos.
        /// </summary>
        /// <param name="servicioModificado">Un objeto de tipo Servicio que contiene los datos actualizados del servicio.</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve un valor booleano.</para>
        ///   <para>Devuelve true si el servicio se modifica con éxito en la fuente de datos.</para>
        ///   <para>Devuelve false si el servicio original no se encuentra en la fuente de datos o si ocurre una excepción durante la operación.</para>
        /// </returns>
        public async Task<bool> ModificarServicio(Servicio servicioModificado)
        {

            var servicio = await _context.Servicios.FirstOrDefaultAsync(x => x.CodServicio == servicioModificado.CodServicio);

            if (servicio == null) { return false; }

            servicio.Descr = servicioModificado.Descr;
            servicio.Estado = servicioModificado.Estado;
            servicio.ValorHora = servicioModificado.ValorHora;

            _context.Servicios.Update(servicio);
            await _context.SaveChangesAsync();

            return true;
        }


        /// <summary>
        /// Marca un servicio como inactivo en la fuente de datos.
        /// </summary>
        /// <param name="cod">El código único del servicio que se desea marcar como inactivo.</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve un valor booleano.</para>
        ///   <para>Devuelve true si el servicio se marca como inactivo con éxito en la fuente de datos.</para>
        ///   <para>Devuelve false si el servicio no se encuentra en la fuente de datos, si ya está inactivo o si ocurre una excepción durante la operación.</para>
        /// </returns>
        public async Task<bool> BorrarServicio(int cod)
        {
            try
            {
                var servicio = await _context.Servicios.FirstOrDefaultAsync(serv => serv.CodServicio == cod);
                if (servicio != null)
                {
                    servicio.IsActive = false;

                    _context.Servicios.Update(servicio);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
