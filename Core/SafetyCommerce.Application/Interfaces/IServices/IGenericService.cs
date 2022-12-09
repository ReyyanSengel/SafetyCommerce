using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Application.Interfaces.IServices
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);

        Task<TEntity> AddAsync(TEntity entity);

        Task AddRangeAsync(IQueryable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IQueryable<TEntity> entities);

        void Update(TEntity entity);

        IQueryable<TEntity> Query();
    }
}
