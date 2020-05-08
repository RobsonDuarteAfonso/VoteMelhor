using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Repositories
{
    public interface IProposalRepository : IRepository<Proposal>
    {
        Proposal VerifyExist(Proposal proposal);
    }
}
