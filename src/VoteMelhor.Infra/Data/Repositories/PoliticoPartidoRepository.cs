using VoteMelhor.ApplicationCore.Entities;
using VoteMelhor.ApplicationCore.Interfaces.Repositories;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class PoliticoPartidoRepository : Repository<PoliticoPartido>, IPoliticoPartidoRepository
    {
        public PoliticoPartidoRepository(VoteMelhorContext context)
            : base(context)
        {

        }
    }
}
