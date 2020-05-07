using System;
using System.Linq;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class PoliticalPartyRepository : Repository<PoliticalParty>, IPoliticalPartyRepository
    {
        public PoliticalPartyRepository(VoteMelhorContext context)
            : base(context)
        {

        }

        public PoliticalParty VerifyExist(int politicalId, Guid partyId)
        {
            return DbSet.FirstOrDefault(c => c.PoliticalId == politicalId && c.PartyId == partyId);
        }

/*         public void SetAtual(int politicalId, int valor)
        {
            var politicals = DbSet.Where(c => c.PoliticalId == politicalId);

            foreach(var item in politicals)
            {
                var politicalParty = new PoliticalParty(item.Id, valor, item.PoliticalId, item.PartyId);
                Db.Update(politicalParty);
                Db.SaveChanges();
            }
        } */
    }
}
