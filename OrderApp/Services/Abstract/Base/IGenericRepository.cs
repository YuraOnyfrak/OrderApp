using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OrderApp.Services.Abstract.Base
{
    public interface IGenericRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        TEntity First(Expression<Func<TEntity, bool>> predicate); 
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> predicate);
         
        Task<List<TEntity>> FetchAsync();
        Task<List<TEntity>> FetchByAsync(Expression<Func<TEntity, bool>> predicate);       
        Task SaveAsync();
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
    }
}
