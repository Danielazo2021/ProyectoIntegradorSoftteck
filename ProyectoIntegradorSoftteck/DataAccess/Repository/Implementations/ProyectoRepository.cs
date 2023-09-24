using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.DataAccess.Repository.Interfaces;
using ProyectoIntegradorSoftteck.DTOs;
using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.DataAccess.Repository.Implementations
{
    public class ProyectoRepository : Repository<Proyecto>, IProyectoRepository
    {

        public ProyectoRepository(ContextDB context) : base(context)
        {

        }

        /// <summary>
        /// Obtiene una lista de proyectos desde la fuente de datos.
        /// </summary>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve una lista de objetos de tipo Proyecto.</para>
        ///   <para>La lista contiene los proyectos obtenidos desde la fuente de datos.</para>
        ///   <para>Si ocurre una excepción durante la operación, la lista puede estar vacía.</para>
        /// </returns>
        public async Task<List<Proyecto>> ObtenerProyectos()
        {
            List<Proyecto> listaProyectos = new List<Proyecto>();
            try
            {
                listaProyectos = await _context.Proyectos.ToListAsync();
            }
            catch (Exception)
            {
            }
            return listaProyectos;
        }


        /// <summary>
        /// Obtiene un proyecto por su identificador único (código).
        /// </summary>
        /// <param name="cod">El código único del proyecto que se desea obtener.</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve un objeto de tipo Proyecto.</para>
        ///   <para>El objeto representa el proyecto obtenido por su código único.</para>
        ///   <para>Si no se encuentra ningún proyecto con el código proporcionado, se devuelve null.</para>
        ///   <para>Si ocurre una excepción durante la operación, se devuelve null.</para>
        /// </returns>
        public async Task<Proyecto> ObtenerProyectoPorId(int cod)
        {
            try
            {
                var proyecto = await _context.Proyectos.FirstOrDefaultAsync(proyecto => proyecto.CodProyecto == cod);
                if (proyecto != null)
                {
                    return proyecto;
                }
            }
            catch (Exception ex)
            {
            }

            return null;
        }


        /// <summary>
        /// Obtiene una lista de proyectos por su estado.
        /// </summary>
        /// <param name="estado">El estado de los proyectos que se desean obtener.</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve una lista de objetos de tipo Proyecto.</para>
        ///   <para>La lista contiene los proyectos que tienen el estado especificado.</para>
        ///   <para>Si no se encuentran proyectos con el estado proporcionado, la lista puede estar vacía.</para>
        ///   <para>Si ocurre una excepción durante la operación, la lista puede estar vacía.</para>
        /// </returns>
        public async Task<List<Proyecto>> ObtenerProyectosPorEstado(Estado estado)
        {
            List<Proyecto> listaProyectos = new List<Proyecto>();
            try
            {
                string estadoStr = estado.ToString(); 
                listaProyectos = await _context.Proyectos.Where(x => x.Estado == estadoStr).ToListAsync();
                               
            }
            catch (Exception)
            {
            }
            return listaProyectos;
        }


        /// <summary>
        /// Inserta un nuevo proyecto en la fuente de datos.
        /// </summary>
        /// <param name="proyecto">Un objeto de tipo ProyectoDto que contiene los datos del proyecto a insertar.</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve un valor booleano.</para>
        ///   <para>Devuelve true si el proyecto se inserta correctamente en la fuente de datos.</para>
        ///   <para>Devuelve false si ocurre una excepción durante la operación o si la inserción falla.</para>
        /// </returns>
        public async Task<bool> InsertarProyecto(ProyectoDto proyecto)
        {
            bool respuesta;
            try
            {
                var proyectoNvo= new Proyecto(proyecto);

                _context.Proyectos.Add(proyectoNvo);
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
        /// Modifica un proyecto existente en la fuente de datos.
        /// </summary>
        /// <param name="proyectoModificado">Un objeto de tipo Proyecto que contiene los datos actualizados del proyecto.</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve un valor booleano.</para>
        ///   <para>Devuelve true si la modificación del proyecto se realiza con éxito en la fuente de datos.</para>
        ///   <para>Devuelve false si el proyecto original no se encuentra en la fuente de datos o si ocurre una excepción durante la operación.</para>
        /// </returns>
        public async Task<bool> ModificarProyecto(Proyecto proyectoModificado)
        {
            var proyecto = await _context.Proyectos.FirstOrDefaultAsync(x => x.CodProyecto == proyectoModificado.CodProyecto);

            if (proyecto == null) 
            {
                return false;
            }
            proyecto.Nombre = proyectoModificado.Nombre;
            proyecto.Direccion = proyectoModificado.Direccion;
            proyecto.Estado = proyectoModificado.Estado;

            _context.Proyectos.Update(proyecto);
            await _context.SaveChangesAsync();

            return true;
        }


        /// <summary>
        /// Borra (desactiva) un proyecto existente en la fuente de datos por su código único.
        /// </summary>
        /// <param name="cod">El código único del proyecto que se desea borrar (desactivar).</param>
        /// <returns>
        ///   <para>Una tarea que representa la operación asincrónica y devuelve un valor booleano.</para>
        ///   <para>Devuelve true si el proyecto se desactiva (borra) con éxito en la fuente de datos.</para>
        ///   <para>Devuelve false si el proyecto no se encuentra en la fuente de datos, si ya está desactivado o si ocurre una excepción durante la operación.</para>
        /// </returns>
        public async Task<bool> BorrarProyecto(int cod)
        {
            try
            {
                var proyecto = await _context.Proyectos.FirstOrDefaultAsync(u => u.CodProyecto == cod);
                if (proyecto != null)
                {
                    proyecto.IsActive = false;
                    _context.Proyectos.Update(proyecto);
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
