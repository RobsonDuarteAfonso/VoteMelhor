using System;
using System.Linq.Expressions;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Queries
{
    public static class PoliticalPartyQueries
    {
        public static Expression<Func<PoliticalParty, bool>> VerifyExist(PoliticalParty politicalParty)
        {
            return x => x.PoliticalId == politicalParty.PoliticalId && x.PartyId == politicalParty.PartyId;
        }
    }
}