using VoteMelhor.ApplicationCore.Entities;

namespace VoteMelhor.ApplicationCore.Interfaces.Services
{
    public interface IPartidoService : IService<Partido>
    {
        Partido VerifyExist(Partido partido);
    }
}
