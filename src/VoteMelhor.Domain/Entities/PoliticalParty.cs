using System;

namespace VoteMelhor.Domain.Entities
{
    public class PoliticalParty: Entity
    {
        public int Current { get; private set; }
        public int PoliticalId { get; private set; }
        public Guid PartyId { get; private set; }
        public virtual Political Political { get; private set; }
        public virtual Party Party { get; private set; }

        public PoliticalParty(int current, int politicalid, Guid partyid)
        {
            Current = current;
            PoliticalId = politicalid;
            PartyId = partyid;
        }

        public void MarkCurrent()
        {
            Current = 1;
        }

        public void UnMarkCurrent()
        {
            Current = 0;
        }

        // Empty constructor for EF
        protected PoliticalParty()
        {

        }
    }
}
