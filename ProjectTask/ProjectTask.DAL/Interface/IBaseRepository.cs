using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTask.DAL.Interface
{
    // interface for repositories with required methods
    // for comunication with database
    public interface IBaseRepository<T>

    {
        IQueryable<T>? GetAll();

        Task<bool> Create(T entity);

        Task<bool> Delete(T entity);

        T? Get(int id);
        
        Task<T> Update(T entity);
    }
}
