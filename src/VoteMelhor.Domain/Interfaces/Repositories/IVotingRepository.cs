using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Repositories
{
    public interface IVotingRepository : IRepository<Voting>
    {
        Voting VerifyExist(Voting voting);
    }
}
