using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Services
{
    public interface ICargoService : IService<Cargo>
    {
        Cargo VerifyExist(Cargo cargo);
        void SetAtual(int politicoId, int valor);
    }
}
