using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoteMelhor.ApplicationCore.Interfaces.Repositories;
using VoteMelhor.ApplicationCore.Interfaces.Services;

namespace VoteMelhor.ApplicationCore.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }

        public Task<TEntity> AddAsync(TEntity obj)
        {
            return _repository.AddAsync(obj);
        }

        public Task<TEntity> GetByIdAsync(Guid id)
        {
            return _repository.GetByIdAsync(id);
        }

        public TEntity GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public Task<ICollection<TEntity>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public Task<TEntity> UpdateAsync(TEntity obj)
        {
            return _repository.UpdateAsync(obj);
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public Task<TEntity> RemoveAsync(Guid id)
        {
            return _repository.RemoveAsync(id);
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
        }
    }
}
