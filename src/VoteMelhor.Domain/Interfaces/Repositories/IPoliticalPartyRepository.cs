using System;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Repositories
{
    public interface IPoliticalPartyRepository : IRepository<PoliticalParty>
    {
        PoliticalParty VerifyExist(int politicalId, Guid partyId);
        //void SetAtual(int politicalId, int valor);
    }
}
