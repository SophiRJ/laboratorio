using ColoniasEspaciales.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ColoniasEspaciales.Repository
{
    public class RepositoryEF<T> : IRepository<T> where T : class
    {
        //Necesitamos el contexto de datos-> lo instanciamos en una variable
        private readonly ShelterContext? _context;
        private readonly DbSet<T>? _dbSet;//dbSet->objeto generico. Variable que me permite manejar la coleccion 

        //constructor ctor
        public RepositoryEF(ShelterContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);//encontramos la entidad, localizar la entidad
            if (entity != null)//si encuentra la entidad
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();//guardar los datos en bd
            }
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) //si la expresion es encontrada
                                                                                         //me devuelve un true y ejecuta el
                                                                                         //findAsync devolviendo una lista
            => await _dbSet.Where(predicate).ToListAsync();


        public async Task<IEnumerable<T>> GetAllAsync()
            => await _dbSet.ToListAsync();//Espera a que el dbset le devuelva todos los registros

        public async Task<T?> GetByIdAsync(int id)
            => await _dbSet.FindAsync(id);//encuentra la entidad de este id

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
