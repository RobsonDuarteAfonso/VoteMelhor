using System;
using System.Linq;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;
using VoteMelhor.Domain.Queries;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class PoliticalPartyRepository : Repository<PoliticalParty>, IPoliticalPartyRepository
    {
        public PoliticalPartyRepository(VoteMelhorContext context)
            : base(context)
        {

        }

        public void UpdateCurrent(PoliticalParty politicalParty)
        {
            using var transaction = Db.Database.BeginTransaction();            
            try
            {
                var politicalPartys = DbSet.Where(c => c.PoliticalId == politicalParty.PoliticalId && c.PartyId == politicalParty.PartyId);

                foreach (var item in politicalPartys)
                {
                    if(item.Id == politicalParty.Id)
                    {
                        item.MarkCurrent();
                    }
                    else
                    {
                        item.UnMarkCurrent();
                    }

                    Db.Update(item);
                    Db.SaveChanges();
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public PoliticalParty VerifyExist(PoliticalParty politicalParty)
        {
            return DbSet.FirstOrDefault(PoliticalPartyQueries.VerifyExist(politicalParty));
        }
    }
}
