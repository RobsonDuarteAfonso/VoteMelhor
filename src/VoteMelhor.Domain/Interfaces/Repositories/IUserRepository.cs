using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public User AuthenticateUser(User user);
        bool VerifyExist(User user);

    }
}
