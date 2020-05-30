using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;
using VoteMelhor.Domain.Queries;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class PoliticalRepository : Repository<Political>, IPoliticalRepository
    {
        public PoliticalRepository(VoteMelhorContext context)
            : base(context)
        {

        }

        public void AddPolitical(Political political)
        {
            using var transaction = Db.Database.BeginTransaction();
            try
            {
                Db.Politicals.Add(political);
                Db.Politicals.FromSqlRaw("SET IDENTITY_INSERT VoteMelhor.Politicals ON;");
                Db.SaveChanges();
                Db.Politicals.FromSqlRaw("SET IDENTITY_INSERT VoteMelhor.Politicals OFF;");
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public Political VerifyExist(int congressmanId, int senatorId)
        {
            return DbSet.FirstOrDefault(PoliticalQueries.VerifyExist(congressmanId, senatorId));
        }

        public Political VerifyExistFullName(string fullName)
        {
            return DbSet.FirstOrDefault(PoliticalQueries.VerifyExistFullName(fullName));
        }
    }
}
