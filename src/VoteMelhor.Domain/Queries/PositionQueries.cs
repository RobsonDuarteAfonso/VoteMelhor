using System;
using System.Linq.Expressions;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Queries
{
    public static class PositionQueries
    {
        public static Expression<Func<Position, bool>> VerifyExist(Guid politicalId, string name)
        {
            return x => x.PoliticalId == politicalId && x.Name == name;
        }
    }
}