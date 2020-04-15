using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoteMelhor.ApplicationCore.Interfaces.Repositories;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly VoteMelhorContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(VoteMelhorContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public async virtual Task<TEntity> AddAsync(TEntity obj)
        {
            DbSet.Add(obj);
            await Db.SaveChangesAsync();
            return obj;
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
            SaveChanges();
        }

        public async virtual Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public async virtual Task<ICollection<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
            SaveChanges();
        }

        public async virtual Task<TEntity> UpdateAsync(TEntity obj)
        {
            //DbSet.Update(obj);
            Db.Entry(obj).State = EntityState.Modified;
            await Db.SaveChangesAsync();
            return obj;
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
            SaveChanges();
        }

        public async virtual Task<TEntity> RemoveAsync(Guid id)
        {
            var obj = await DbSet.FindAsync(id);
            if (obj == null)
            {
                return obj;
            }

            DbSet.Remove(obj);
            await Db.SaveChangesAsync();

            return obj;
        }

        public void SaveChanges()
        {
            Db.SaveChanges();
        }

        //public async void SaveChangesAsync()
        //{
        //    await Db.SaveChangesAsync();
        //}

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}