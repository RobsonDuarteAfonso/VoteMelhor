using System;
using System.Linq.Expressions;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Queries
{
    public static class PartyQueries
    {
        public static Expression<Func<Party, bool>> VerifyExist(Party party)
        {
            return x => x.Number == party.Number && x.Initials == party.Initials;
        }
    }
}