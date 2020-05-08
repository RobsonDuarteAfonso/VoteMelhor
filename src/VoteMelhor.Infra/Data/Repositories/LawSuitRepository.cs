using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;
using VoteMelhor.Domain.Queries;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class LawSuitRepository : Repository<LawSuit>, ILawSuitRepository
    {
        public LawSuitRepository(VoteMelhorContext context)
            : base(context)
        {

        }

        public IEnumerable<LawSuit> GetAllByPolitical(Political political)
        {
            return DbSet.AsNoTracking().Where(LawSuitQueries.GetAllByPolitical(political)).OrderBy(x => x.PublicationDate);
        }
    }
}
