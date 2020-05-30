using Microsoft.EntityFrameworkCore;
using System;
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

        public IEnumerable<LawSuit> GetAllByPoliticalId(Guid id)
        {
            return DbSet.AsNoTracking().Where(LawSuitQueries.GetAllByPoliticalId(id)).OrderBy(x => x.PublicationDate);
        }
    }
}
