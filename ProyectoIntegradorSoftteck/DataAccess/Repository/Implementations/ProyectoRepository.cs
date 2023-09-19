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

        public async Task<bool> BorrarProyecto(int cod)
        {
            try
            {
                var proyecto = await _context.Proyectos.FirstOrDefaultAsync(u => u.CodProyecto == cod);
                if (proyecto != null)
                {
                    _context.Proyectos.Remove(proyecto);
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

        public async Task<List<Proyecto>> ObtenerProyectosPorEstado(Estado estado)
        {
            List<Proyecto> listaProyectos = new List<Proyecto>();
            try
            {
                listaProyectos = await _context.Proyectos.Where(x => x.Estado== estado).ToListAsync();
            }
            catch (Exception)
            {
            }
            return listaProyectos;
        }

       
        public async Task<List<Proyecto>> ObtenerProyectosPaginado(int pagina, int registrosPorPagina)
        {
            try
            {
                var query = _context.Proyectos.AsQueryable();

                var proyectos = await query
                    .OrderBy(p => p.CodProyecto) 
                    .Skip((pagina - 1) * registrosPorPagina) 
                    .Take(registrosPorPagina) 
                    .ToListAsync();                

                return proyectos;
            }
            catch (Exception)
            {                
                throw;
            }
        }


    }
}
