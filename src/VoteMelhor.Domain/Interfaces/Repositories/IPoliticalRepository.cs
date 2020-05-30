using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Repositories
{
    public interface IPoliticalRepository : IRepository<Political>
    {
        void AddPolitical(Political political);
        Political VerifyExist(int congressmanId, int senatorId);
        Political VerifyExistFullName(string fullName);
    }
}
