using System;
using System.Linq.Expressions;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Queries
{
    public static class UserQueries
    {
        public static Expression<Func<User, bool>> AuthenticateUser(User user)
        {
            return x => x.Email == user.Email && x.Password.Code == user.Password.Code;
        }

        public static Expression<Func<User, bool>> VerifyExist(string email)
        {
            return x => x.Email == email;
        }
    }
}