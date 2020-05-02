using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Repositories
{
    public interface IPoliticoRepository : IRepository<Politico>
    {
        void AddNewPolitico(Politico politico);
        Politico VerifyExist(int id);
    }
}
