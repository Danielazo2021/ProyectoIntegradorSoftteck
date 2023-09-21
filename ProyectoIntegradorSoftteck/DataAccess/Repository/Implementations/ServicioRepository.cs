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
