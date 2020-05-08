using System.Linq;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;
using VoteMelhor.Domain.Queries;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class RatingRepository : Repository<Rating>, IRatingRepository
    {
        public RatingRepository(VoteMelhorContext context)
            : base(context)
        {

        }

        public Rating VerifyExist(Rating rating)
        {
            return DbSet.FirstOrDefault(RatingQueries.VerifyExist(rating));
        }
    }
}
