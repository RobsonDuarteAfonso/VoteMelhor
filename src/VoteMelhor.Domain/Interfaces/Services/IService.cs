using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VoteMelhor.Domain.Interfaces.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        Task<TEntity> AddAsync(TEntity obj);
        Task<TEntity> GetByIdAsync(Guid id);
        TEntity GetById(Guid id);
        Task<ICollection<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetAll();
        Task<TEntity> UpdateAsync(TEntity obj);
        void Update(TEntity obj);
        Task<TEntity> RemoveAsync(Guid id);
        void Remove(Guid id);
    }
}
