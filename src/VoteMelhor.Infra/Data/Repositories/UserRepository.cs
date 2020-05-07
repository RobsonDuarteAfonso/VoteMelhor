using System.Linq;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;

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
/*             var user = (from x in Db.Users
                        where x.Email == user.Email && x.Senha == user.Senha
                        select new User(x.Id, x.Nome, x.Email, x.Status, x.Perfil, x.Classificacoes)).SingleOrDefault(); */
            var newUser = Db.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            newUser.Password.SetPasswordNull();

            return user;
        }

        public bool VerifyExist(User user)
        {
            var newUser = Db.Users.FirstOrDefault(x => x.Email == user.Email);

            if (newUser == null)
            {
                return false;
            }

            return true;
        }


    }
}
