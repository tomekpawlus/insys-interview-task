using Microsoft.EntityFrameworkCore;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.Data.Repository.Impl
{
    public abstract class BaseRepository<T, K> : IBaseRepository<T, K> where T : BaseEntity
    {
        protected MovieLibraryContext context;
        protected DbSet<T> _dbSet;

        public BaseRepository(MovieLibraryContext context)
        {
            this.context = context;
            _dbSet = this.context.Set<T>();
        }

        public virtual async Task<T> Add(T entity)
        {
            _dbSet.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> Delete(K id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _dbSet.Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T> Get(K id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
        public virtual IQueryable<T> Find()
        {
            return _dbSet;
        }

    }
}
