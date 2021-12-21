using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public interface IBaseService<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        T GetById(int id);
        IQueryable<T> GetAll(bool asNoTracking = false);
    }
}
