using SafetyCommerce.Application.Exceptions;
using SafetyCommerce.Application.Interfaces.IRepositorys;
using SafetyCommerce.Application.Interfaces.IServices;
using SafetyCommerce.Application.Interfaces.IUnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Infrastructure.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public GenericService(IGenericRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task AddRangeAsync(IQueryable<TEntity> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
        }


        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var hasEntity = await _repository.GetByIdAsync(id);
            if (hasEntity == null)
            {
                throw new NotFoundException($"{typeof(TEntity).Name} ({id}) not found");
            }
            return hasEntity;
        }

        public IQueryable<TEntity> Query()
        {
            return _repository.Query();
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            _unitOfWork.Commit();
        }

        public void RemoveRange(IQueryable<TEntity> entities)
        {
            _repository.RemoveRange(entities);
            _unitOfWork.Commit();
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
