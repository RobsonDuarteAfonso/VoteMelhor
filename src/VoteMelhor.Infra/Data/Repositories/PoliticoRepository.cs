using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class PoliticoRepository : Repository<Politico>, IPoliticoRepository
    {
        public PoliticoRepository(VoteMelhorContext context)
            : base(context)
        {

        }

        public void AddNewPolitico(Politico politico)
        {
            using var transaction = Db.Database.BeginTransaction();
            try
            {
                Db.Politicos.Add(politico);
                Db.Politicos.FromSqlRaw("SET IDENTITY_INSERT VoteMelhor.Politicos ON;");
                Db.SaveChanges();
                Db.Politicos.FromSqlRaw("SET IDENTITY_INSERT VoteMelhor.Politicos OFF;");
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public Politico VerifyExist(int id)
        {
            return DbSet.FirstOrDefault(c => c.Id == id);
        }
    }
}
