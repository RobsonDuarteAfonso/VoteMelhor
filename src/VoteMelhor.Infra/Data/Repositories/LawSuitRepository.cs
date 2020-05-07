using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class LawSuitRepository : Repository<LawSuit>, ILawSuitRepository
    {
        public LawSuitRepository(VoteMelhorContext context)
            : base(context)
        {

        }
    }
}
