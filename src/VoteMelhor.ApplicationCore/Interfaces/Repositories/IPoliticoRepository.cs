using VoteMelhor.ApplicationCore.Entities;

namespace VoteMelhor.ApplicationCore.Interfaces.Repositories
{
    public interface IPoliticoRepository : IRepository<Politico>
    {
        void AddNewPolitico(Politico politico);
    }
}
