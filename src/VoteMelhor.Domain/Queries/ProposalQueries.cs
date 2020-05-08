using System;
using System.Linq.Expressions;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Queries
{
    public static class ProposalQueries
    {
        public static Expression<Func<Proposal, bool>> VerifyExist(Proposal proposal)
        {
            return x => x.Id == proposal.Id;
        }
    }
}