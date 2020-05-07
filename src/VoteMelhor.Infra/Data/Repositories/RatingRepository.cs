using System.Linq;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;

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
            return DbSet.FirstOrDefault(x => 
            x.PoliticalId == rating.PoliticalId && 
            x.UserId == rating.UserId && 
            x.Rate == rating.Rate);
        }
    }
}
