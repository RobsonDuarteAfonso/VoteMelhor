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

        public PoliticalParty VerifyExist(PoliticalParty politicalParty)
        {
            return DbSet.FirstOrDefault(PoliticalPartyQueries.VerifyExist(politicalParty));
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
