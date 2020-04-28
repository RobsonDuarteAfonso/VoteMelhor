using VoteMelhor.ApplicationCore.Entities;

namespace VoteMelhor.ApplicationCore.Interfaces.Repositories
{
    public interface ICargoRepository : IRepository<Cargo>
    {
        Cargo VerifyExist(Cargo cargo);
        void SetAtual(int politicoId, int valor);
    }
}
