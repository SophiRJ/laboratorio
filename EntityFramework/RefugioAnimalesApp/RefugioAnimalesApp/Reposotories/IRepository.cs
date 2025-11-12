using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RefugioAnimalesApp.Reposotories
{//Esta interfaz va a manejar cualquier tipo de clase
    public interface IRepository<T>//generico T -> una class
        //Definimos metodos q van a a implementar las clases que hereden de esta i
    { //Task -> tarea pendiente o en ejecucion
        Task<IEnumerable<T>> GetAllAsync();// devuelve enumerador lista 
                                           // (me obtiene todos los registros asincronicamente)
        Task<T?>GetByIdAsync(int id);//un solo registro por su id
        Task AddAsync(T entity);//añadir una entidad asincronicamente
        Task UpdateAsync(T entity);//actualizar
        Task DeleteAsync(int id);//borrar

        Task <IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate); 
        //encontrar una coleccion(recibe una expresion de tipo linq->
        //si la encuentras me devuleves el predicado como valor boleano) 
        //el resultaod se la pasamos al resultado del find asincrono
    }
}
