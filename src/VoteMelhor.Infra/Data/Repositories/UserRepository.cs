using System.Linq;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;
using VoteMelhor.Domain.Queries;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(VoteMelhorContext context)
            : base(context)
        {

        }

        public User AuthenticateUser(User user)
        {
            var newUser = Db.Users.FirstOrDefault(UserQueries.AuthenticateUser(user));
            newUser.Password.SetPasswordNull();

            return user;
        }

        public User VerifyExist(User user)
        {        
            return Db.Users.FirstOrDefault(UserQueries.VerifyExist(user));
        }
    }
}
