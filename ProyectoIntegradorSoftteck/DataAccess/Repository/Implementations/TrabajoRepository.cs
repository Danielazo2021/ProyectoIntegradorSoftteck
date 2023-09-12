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
                var trabajoNvo = new Trabajo();
                trabajoNvo.cod_proyecto = trabajoDto.CodProyecto;
                trabajoNvo.cod_servicio = trabajoDto.CodServicio;
                trabajoNvo.Fecha = trabajoDto.Fecha;
                trabajoNvo.ValorHora = trabajoDto.ValorHora;
                trabajoNvo.CantHoras= trabajoDto.CantHoras;
                trabajoNvo.Costo=trabajoDto.Costo;
                    


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



        public async Task<bool> ModificarTrabajo(Trabajo trabajo)
        {
            //buscar el con el id que vino por parametro en la base y setearle el resto de los cambios,
            //despues hacer un update en la se y un savechange
            throw new NotImplementedException();
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
                listaTrabajos = await _context.Trabajos.ToListAsync();

            }
            catch (Exception)
            {

            }

            return listaTrabajos;


        }
    }
}
