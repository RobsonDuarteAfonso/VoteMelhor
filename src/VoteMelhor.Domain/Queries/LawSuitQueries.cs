using System;
using System.Linq.Expressions;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Queries
{
    public static class LawSuitQueries
    {
        public static Expression<Func<LawSuit, bool>> GetAllByPolitical(Political political)
        {
            return x => x.Political == political;
        }
    }
}