﻿using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.DataAccess.Repository.Interfaces;
using ProyectoIntegradorSoftteck.Entities;

namespace ProyectoIntegradorSoftteck.DataAccess.Repository.Implementations
{
    public class ProyectoRepository : Repository<Proyecto>, IProyectoRepository
    {

        private readonly ContextDB _context;

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



        public async Task<bool> InsertarProyecto(Proyecto proyecto)
        {
            bool respuesta;

            try
            {
                _context.Proyectos.Add(proyecto);
                await _context.SaveChangesAsync();
                respuesta = true;

            }
            catch (Exception)
            {
                respuesta = false;
            }
            return respuesta;

        }



        public async Task<bool> ModificarProyecto(Proyecto proyecto)
        {
            //buscar el con el id que vino por parametro en la base y setearle el resto de los cambios,
            //despues hacer un update en la se y un savechange
            throw new NotImplementedException();
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

    }
}
