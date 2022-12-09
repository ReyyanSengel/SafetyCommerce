using Microsoft.EntityFrameworkCore;
using SafetyCommerce.Application.Interfaces.IRepositorys;
using SafetyCommerce.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Persistence.Repositories
{
    public class GenericRepsitory<TEntity> :IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly SafetyCommerceDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepsitory(SafetyCommerceDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(IQueryable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<TEntity> Query()
        {
            return _dbSet.AsQueryable();
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IQueryable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

    }
}
