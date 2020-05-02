using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Repositories
{
    public interface ICargoRepository : IRepository<Cargo>
    {
        Cargo VerifyExist(Cargo cargo);
        void SetAtual(int politicoId, int valor);
    }
}
