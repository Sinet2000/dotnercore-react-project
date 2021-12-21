using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IBaseService<T> where T : class
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task UpdateAsync(List<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteAsync(List<T> entities);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(string id);
        Task<List<T>> GetAllAsync();
    }
}
