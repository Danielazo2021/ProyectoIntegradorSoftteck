using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.DataAccess.Repository.Interfaces;
using ProyectoIntegradorSoftteck.DTOs;
using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.DataAccess.Repository.Implementations
{
    public class TrabajoRepository : Repository<Trabajo>, ITrabajoRepository
    {
        public TrabajoRepository(ContextDB context) : base(context)
        {

        }

        /// <summary>
        /// Obtiene una lista de trabajos desde la fuente de datos, incluyendo información relacionada de proyectos y servicios.
        /// </summary>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve una lista de objetos de tipo Trabajo.</para>
        ///   <para>La lista contiene los trabajos obtenidos desde la fuente de datos, incluyendo información relacionada de proyectos y servicios.</para>
        ///   <para>Si no se encuentran trabajos en la fuente de datos o si ocurre una excepción durante la operación, la lista puede estar vacía.</para>
        /// </returns>
        public async Task<List<Trabajo>> ObtenerTrabajos()
        {
            List<Trabajo> listaTrabajos = new List<Trabajo>();
            try
            {
                listaTrabajos = await _context.Trabajos
                    .Include(t => t.Proyecto)
                    .Include(t => t.Servicio)
                    .ToListAsync();
            }
            catch (Exception)
            {
            }

            return listaTrabajos;
        }


        /// <summary>
        /// Obtiene un trabajo por su identificador único (código), incluyendo información relacionada de proyectos y servicios.
        /// </summary>
        /// <param name="cod">El código único del trabajo que se desea obtener.</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve un objeto de tipo Trabajo.</para>
        ///   <para>El objeto representa el trabajo obtenido por su código único, incluyendo información relacionada de proyectos y servicios.</para>
        ///   <para>Si no se encuentra ningún trabajo con el código proporcionado o si ocurre una excepción durante la operación, se devuelve null.</para>
        /// </returns>
        public async Task<Trabajo> ObtenerTrabajoPorId(int cod)
        {
            try
            {
                // Realiza una operación asincrónica para obtener el trabajo por su código único,
                // incluyendo información relacionada de proyectos y servicios
                var trabajo = await _context.Trabajos
                            .Include(t => t.Proyecto)
                            .Include(t => t.Servicio)
                            .FirstOrDefaultAsync(trabajo => trabajo.CodTrabajo == cod);
                if (trabajo != null)
                {
                    return trabajo;
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }


        /// <summary>
        /// Inserta un nuevo trabajo en la fuente de datos.
        /// </summary>
        /// <param name="trabajoDto">Un objeto de tipo TrabajoDto que contiene los datos del trabajo a insertar.</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve un valor booleano.</para>
        ///   <para>Devuelve true si el trabajo se inserta con éxito en la fuente de datos.</para>
        ///   <para>Devuelve false si ocurre una excepción durante la operación o si la inserción falla.</para>
        /// </returns>
        public async Task<bool> InsertarTrabajo(TrabajoDto trabajoDto)
        {
            bool respuesta;

            try
            {
                var trabajoNvo = new Trabajo(trabajoDto);
               
                _context.Trabajos.Add(trabajoNvo);
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
        /// Modifica un trabajo existente en la fuente de datos.
        /// </summary>
        /// <param name="trabajoModificado">Un objeto de tipo Trabajo que contiene los datos actualizados del trabajo.</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve un valor booleano.</para>
        ///   <para>Devuelve true si el trabajo se modifica con éxito en la fuente de datos.</para>
        ///   <para>Devuelve false si el trabajo original no se encuentra en la fuente de datos o si ocurre una excepción durante la operación.</para>
        /// </returns>
        public async Task<bool> ModificarTrabajo(Trabajo trabajoModificado)
        {
            var trabajo = await _context.Trabajos.FirstOrDefaultAsync(x => x.CodTrabajo == trabajoModificado.CodTrabajo);

            if (trabajo == null) { return false; }
           
            trabajo.Cod_servicio = trabajoModificado.Cod_servicio;
            trabajo.Fecha = trabajoModificado.Fecha;           
            trabajo.Cod_proyecto = trabajoModificado.Cod_proyecto;
            trabajo.Costo = trabajoModificado.Costo;
            trabajo.CantHoras = trabajoModificado.CantHoras;


            _context.Trabajos.Update(trabajo);
            await _context.SaveChangesAsync();

            return true;
        }


        /// <summary>
        /// Marca un trabajo como inactivo en la fuente de datos.
        /// </summary>
        /// <param name="cod">El código único del trabajo que se desea marcar como inactivo.</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve un valor booleano.</para>
        ///   <para>Devuelve true si el trabajo se marca como inactivo con éxito en la fuente de datos.</para>
        ///   <para>Devuelve false si el trabajo no se encuentra en la fuente de datos, ya está inactivo o si ocurre una excepción durante la operación.</para>
        /// </returns>
        public async Task<bool> BorrarTrabajo(int cod)
        {
            try
            {
                var trabajo = await _context.Trabajos.FirstOrDefaultAsync(u => u.CodTrabajo == cod);
                if (trabajo != null)
                {
                    trabajo.IsActive = false;
                    _context.Trabajos.Update(trabajo);
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
