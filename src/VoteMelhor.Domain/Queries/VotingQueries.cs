using System;
using System.Linq.Expressions;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Queries
{
    public static class VotingQueries
    {
        public static Expression<Func<Voting, bool>> VerifyExist(Voting voting)
        {
            return x => x.PoliticalId == voting.PoliticalId && x.VotingDate == voting.VotingDate && x.ProposalId == voting.ProposalId;
        }
    }
}