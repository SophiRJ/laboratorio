using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RefugioAnimalesApp.Reposotories
{//Esta interfaz va a manejar cualquier tipo de clase
    public interface IRepository<T>//generico T -> una class
    { //Task -> tarea pendiente o en ejecucion
        Task<IEnumerable<T>> GetAllAsync();//todos los registros
        Task<T?>GetByIdAsync(int id);//un solo registro por su id
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

        Task <IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate); 
    }
}
