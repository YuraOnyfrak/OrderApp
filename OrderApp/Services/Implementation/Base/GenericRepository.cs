using Microsoft.EntityFrameworkCore;
using OrderApp.Services.Abstract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrderApp.Services.Implementation.Base
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly OrdersDBContext _context;

        public GenericRepository(OrdersDBContext context)
        {
            _context = context;
        }

        public OrdersDBContext Context
        {
            get { return _context; }
        }

        public DbSet<TEntity> DbSet
        {
            get { return Context.Set<TEntity>(); }
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public virtual async Task<List<TEntity>> FetchAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<List<TEntity>> FetchByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().First(predicate);
        }

        public virtual async Task<IEnumerable<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where<TEntity>(predicate).ToListAsync();
        }
        
        public virtual async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }


    }

}
