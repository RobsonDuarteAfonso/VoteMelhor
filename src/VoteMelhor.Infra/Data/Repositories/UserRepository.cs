using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            var newUser = Db.Users.AsNoTracking().FirstOrDefault(UserQueries.AuthenticateUser(user));
            newUser.Password.SetPasswordNull();

            return newUser;
        }

        public User VerifyExist(string email)
        {        
            return Db.Users.FirstOrDefault(UserQueries.VerifyExist(email));
        }
    }
}
