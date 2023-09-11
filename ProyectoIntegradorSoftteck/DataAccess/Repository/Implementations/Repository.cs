﻿using Microsoft.EntityFrameworkCore;
using ProyectoIntegradorSoftteck.DataAccess.Repository.Interfaces;
using ProyectoIntegradorSoftteck.Entities;
using System.Linq.Expressions;

namespace ProyectoIntegradorSoftteck.DataAccess.Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ContextDB _context;

        public Repository(ContextDB context)
        {
            _context = context;
        }

        public async Task<bool> Borrar(int cod)
        {
            var entity = await _context.Set<T>().FindAsync(cod);
            if (entity == null)
            {
                return false;
            }

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            if (result == null)
            {
                return false;
            }

            await _context.SaveChangesAsync();
            return true;
        }

       

        public async Task<bool> Modificar(T entity)
        {
             var existingEntity = await _context.Set<T>().FindAsync(entity);
    
                if (existingEntity == null)
                {
                    return false; // La entidad no existe en la base de datos, no se puede modificar.
                }

                // Copia los valores de las propiedades de la entidad que deseas modificar
                // a la entidad existente en la base de datos.
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);

                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();
                return true;
            

            
        }



        public async Task<T> ObtenerPorDni(int dni)
        {
           
             var entity = await _context.Set<T>().FindAsync(dni);
            return entity;
        }





        public async Task<List<T>> ObtenerTodos()
        {
            var prueba = await _context.Set<T>().ToListAsync();
            return prueba;
        }


    }
}
