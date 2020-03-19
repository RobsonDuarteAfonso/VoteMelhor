using VoteMelhor.ApplicationCore.Entities;
using VoteMelhor.ApplicationCore.Interfaces.Repositories;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class PoliticoRepository : Repository<Politico>, IPoliticoRepository
    {
        public PoliticoRepository(VoteMelhorContext context)
            : base(context)
        {

        }
    }
}
