using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Repositories
{
    public interface IPoliticalRepository : IRepository<Political>
    {
        void AddNewPolitical(Political political);
        Political VerifyExist(Political political);
    }
}
