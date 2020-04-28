using VoteMelhor.ApplicationCore.Entities;

namespace VoteMelhor.ApplicationCore.Interfaces.Services
{
    public interface ICargoService : IService<Cargo>
    {
        Cargo VerifyExist(Cargo cargo);
        void SetAtual(int politicoId, int valor);
    }
}
