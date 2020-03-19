using VoteMelhor.ApplicationCore.Entities;
using VoteMelhor.ApplicationCore.Interfaces.Repositories;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class VotacaoRepository : Repository<Votacao>, IVotacaoRepository
    {
        public VotacaoRepository(VoteMelhorContext context)
            : base(context)
        {

        }
    }
}
