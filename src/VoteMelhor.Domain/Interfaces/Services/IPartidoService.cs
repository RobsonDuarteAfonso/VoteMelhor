using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Services
{
    public interface IPartidoService : IService<Partido>
    {
        Partido VerifyExist(Partido partido);
        Partido VerifyExist(string sigla);
    }
}
