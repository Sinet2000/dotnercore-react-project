using BusinessLogic.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
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

        public virtual async Task AddAsync(T entity)
        {
            dbSet.Add(entity);
            await dataContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;

            await dataContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(List<T> entities)
        {
            foreach (T entity in entities)
            {
                dbSet.Attach(entity);
                dataContext.Entry(entity).State = EntityState.Modified;
            }

            await dataContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity);

            await dataContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(List<T> entities)
        {
            dbSet.RemoveRange(entities);

            await dataContext.SaveChangesAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }
    }
}
