using System;
using System.Linq.Expressions;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Queries
{
    public static class LawSuitQueries
    {
        public static Expression<Func<LawSuit, bool>> GetAllByPoliticalId(Guid id)
        {
            return x => x.Political.Id == id;
        }
    }
}