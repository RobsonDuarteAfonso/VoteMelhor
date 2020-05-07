using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Repositories
{
    public interface IPartyRepository : IRepository<Party>
    {
        Party VerifyExist(Party party);
        Party VerifyExist(string initials);
    }
}
