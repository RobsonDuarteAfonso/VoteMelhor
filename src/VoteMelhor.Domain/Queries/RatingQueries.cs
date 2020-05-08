using System;
using System.Linq.Expressions;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Queries
{
    public static class RatingQueries
    {
        public static Expression<Func<Rating, bool>> VerifyExist(Rating rating)
        {
            return x => x.PoliticalId == rating.PoliticalId && x.UserId == rating.UserId && x.Rate == rating.Rate;
        }
    }
}