using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Repositories
{
    public interface IRatingRepository : IRepository<Rating>
    {
        Rating VerifyExist(Rating rating);
    }
}
