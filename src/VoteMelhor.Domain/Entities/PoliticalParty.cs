using System;

namespace VoteMelhor.Domain.Entities
{
    public class PoliticalParty: Entity
    {
        public bool Current { get; private set; }
        public Guid PoliticalId { get; private set; }
        public Guid PartyId { get; private set; }
        public virtual Political Political { get; private set; }
        public virtual Party Party { get; private set; }

        public PoliticalParty(bool current, Guid politicalid, Guid partyid)
        {
            Current = current;
            PoliticalId = politicalid;
            PartyId = partyid;
        }

        public void MarkCurrent()
        {
            Current = true;
        }

        public void UnMarkCurrent()
        {
            Current = false;
        }

        // Empty constructor for EF
        protected PoliticalParty()
        {

        }
    }
}
