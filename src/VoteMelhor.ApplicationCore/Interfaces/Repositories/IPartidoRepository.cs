using VoteMelhor.ApplicationCore.Entities;

namespace VoteMelhor.ApplicationCore.Interfaces.Repositories
{
    public interface IPartidoRepository : IRepository<Partido>
    {
        Partido VerifyExist(Partido partido);
        Partido VerifyExist(string sigla);
    }
}
