using System.Linq;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;
using VoteMelhor.Domain.Queries;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class VotingRepository : Repository<Voting>, IVotingRepository
    {
        public VotingRepository(VoteMelhorContext context)
            : base(context)
        {

        }

        public Voting VerifyExist(Voting voting)
        {
            return DbSet.FirstOrDefault(VotingQueries.VerifyExist(voting));
        }
    }
}
