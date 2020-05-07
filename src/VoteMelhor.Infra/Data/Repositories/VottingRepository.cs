using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class VotingRepository : Repository<Voting>, IVotingRepository
    {
        public VotingRepository(VoteMelhorContext context)
            : base(context)
        {

        }
    }
}
