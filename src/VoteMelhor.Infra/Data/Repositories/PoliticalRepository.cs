using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
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

        public List<Political> SearchPoliticals(string name, string state)
        {
            //return DbSet.Where(PoliticalQueries.SearchPoliticals(name, state))
            //.Include(a => a.PoliticalPartys
            //    .Where(b => b.Current == true))
            //.ThenInclude(e => e.Party)
            //.Include(c => c.Positions.Where(d => d.Current == true))
            //.ToList();

            var _political = DbSet.AsNoTracking().Where(PoliticalQueries.SearchPoliticals(name, state))
                .Include(x => x.PoliticalPartys)
                .ThenInclude(c => c.Party)
                .Include(d => d.Positions)
                .ToList();

            foreach(var item in _political)
            {
                item.PoliticalPartys.Add(item.PoliticalPartys.Where(d => d.Current == true).FirstOrDefault());
                item.Positions.Add(item.Positions.Where(d => d.Current == true).FirstOrDefault());
            }

            return _political.OrderByDescending(y => y.Positions.OrderBy(v => v.Name).Select(v => v.Name).FirstOrDefault()).ToList();
            
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
