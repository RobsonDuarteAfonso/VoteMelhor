using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User AuthenticateUser(User user);
        User VerifyExist(User user);

    }
}
