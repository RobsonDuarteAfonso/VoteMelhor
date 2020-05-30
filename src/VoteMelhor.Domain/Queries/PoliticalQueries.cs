using System;
using System.Linq.Expressions;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Queries
{
    public static class PoliticalQueries
    {
        public static Expression<Func<Political, bool>> VerifyExist(int congressmanId, int senatorId )
        {
            return x => (x.CongressmanId == congressmanId && x.CongressmanId != 0) || (x.SenatorId == senatorId && x.SenatorId != 0);
        }

        public static Expression<Func<Political, bool>> VerifyExistFullName(string fullName)
        {
            return x => x.FullName == fullName;
        }
    }
}