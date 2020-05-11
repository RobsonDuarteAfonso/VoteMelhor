using System;
using System.Linq.Expressions;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Queries
{
    public static class UserQueries
    {
        public static Expression<Func<User, bool>> AuthenticateUser(User user)
        {
            return x => x.Email == user.Email && x.Password == user.Password;
        }

        public static Expression<Func<User, bool>> VerifyExist(User user)
        {
            return x => x.Email == user.Email;
        }
    }
}