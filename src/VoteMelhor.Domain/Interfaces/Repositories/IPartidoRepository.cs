using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Repositories
{
    public interface IPartidoRepository : IRepository<Partido>
    {
        Partido VerifyExist(Partido partido);
        Partido VerifyExist(string sigla);
    }
}
