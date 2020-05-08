using System;
using System.Linq.Expressions;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Queries
{
    public static class PoliticalQueries
    {
        public static Expression<Func<Political, bool>> VerifyExist(Political political)
        {
            return x => x.Id == political.Id;
        }
    }
}