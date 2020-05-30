using System.Linq;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;
using VoteMelhor.Domain.Queries;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class PartyRepository : Repository<Party>, IPartyRepository
    {
        public PartyRepository(VoteMelhorContext context)
            : base(context)
        {

        }
        public Party VerifyExist(string initials)
        {
            return DbSet.FirstOrDefault(PartyQueries.VerifyExist(initials));
        }
    }
}
