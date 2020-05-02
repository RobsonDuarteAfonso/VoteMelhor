using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class ClassificacaoRepository : Repository<Classificacao>, IClassificacaoRepository
    {
        public ClassificacaoRepository(VoteMelhorContext context)
            : base(context)
        {

        }
    }
}
