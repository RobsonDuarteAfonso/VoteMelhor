using System;
using System.Linq.Expressions;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Queries
{
    public static class PositionQueries
    {
        public static Expression<Func<Position, bool>> VerifyExist(Position position)
        {
            return x => x.PoliticalId == position.PoliticalId && x.Name == position.Name;
        }
    }
}