using System;
using System.Linq.Expressions;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Queries
{
    public static class PoliticalPartyQueries
    {
        public static Expression<Func<PoliticalParty, bool>> VerifyExist(Guid politicalId, Guid partyId)
        {
            return x => x.PoliticalId == politicalId && x.PartyId == partyId;
        }
    }
}