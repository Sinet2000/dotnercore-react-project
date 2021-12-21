using Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public abstract class BaseService<T> where T : class
    {
        protected IDataContext dataContext;
        protected readonly DbSet<T> dbSet;

        protected BaseService(IDataContext dataContext)
        {
            this.dataContext = dataContext;
            dbSet = dataContext.Set<T>();
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
            dataContext.SaveChanges();
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
            dataContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;

            dataContext.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);

            dataContext.SaveChanges();
        }

        public virtual void DeleteRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);

            dataContext.SaveChanges();
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IQueryable<T> GetAll(bool asNoTracking = false)
        {
            return asNoTracking ? dbSet.AsNoTracking() : dbSet;
        }
    }
}
