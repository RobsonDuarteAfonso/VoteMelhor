using System.Linq;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class PartyRepository : Repository<Party>, IPartyRepository
    {
        public PartyRepository(VoteMelhorContext context)
            : base(context)
        {

        }
        public Party VerifyExist(Party party)
        {
            return DbSet.FirstOrDefault(c => c.Initials == party.Initials && c.Number == party.Number);
        }

        public Party VerifyExist(string initials)
        {
            return DbSet.FirstOrDefault(c => c.Initials == initials);
        }
    }
}
