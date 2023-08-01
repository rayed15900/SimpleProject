using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        void Update(T entity, T oldEntity);
        void Remove(T entity);
    }
}
