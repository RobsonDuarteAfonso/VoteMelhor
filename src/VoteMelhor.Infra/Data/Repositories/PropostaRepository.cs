using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class PropostaRepository : Repository<Proposta>, IPropostaRepository
    {
        public PropostaRepository(VoteMelhorContext context)
            : base(context)
        {

        }
    }
}
