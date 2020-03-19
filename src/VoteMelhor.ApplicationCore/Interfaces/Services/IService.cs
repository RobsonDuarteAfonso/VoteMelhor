using System;
using System.Linq;

namespace VoteMelhor.ApplicationCore.Interfaces.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(Guid id);
    }
}
