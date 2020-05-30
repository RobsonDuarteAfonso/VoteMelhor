using System;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Repositories
{
    public interface IPoliticalPartyRepository : IRepository<PoliticalParty>
    {
        PoliticalParty VerifyExist(Guid politicalId, Guid partyId);
        
        void UpdateCurrent(PoliticalParty politicalParty);
    }
}
