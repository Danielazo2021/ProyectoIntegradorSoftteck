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

        public async Task<bool> BorrarTrabajo(int cod)
        {
            try
            {
                var trabajo = await _context.Trabajos.FirstOrDefaultAsync(u => u.CodTrabajo == cod);
                if (trabajo != null)
                {
                    _context.Trabajos.Remove(trabajo);
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
           // await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Trabajo> ObtenerTrabajoPorId(int cod)
        {
            try
            {
                var trabajo = await _context.Trabajos.FirstOrDefaultAsync(trabajo => trabajo.CodTrabajo == cod);
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



    }
    
}
