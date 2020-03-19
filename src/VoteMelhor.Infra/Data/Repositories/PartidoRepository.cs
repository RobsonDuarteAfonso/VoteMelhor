using VoteMelhor.ApplicationCore.Entities;
using VoteMelhor.ApplicationCore.Interfaces.Repositories;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class PartidoRepository : Repository<Partido>, IPartidoRepository
    {
        public PartidoRepository(VoteMelhorContext context)
            : base(context)
        {

        }
    }
}
