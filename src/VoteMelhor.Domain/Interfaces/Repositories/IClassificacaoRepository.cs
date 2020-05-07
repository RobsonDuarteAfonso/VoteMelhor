using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Repositories
{
    public interface IClassificacaoRepository : IRepository<Classificacao>
    {
        Classificacao VerifyExist(Classificacao classificacao);
    }
}
