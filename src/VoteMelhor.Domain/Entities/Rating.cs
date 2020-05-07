using System;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Entities
{
    public class Rating : Entity
    {
        public RateEnum Rate { get; private set; }
        public Guid UserId { get; private set; }
        public int PoliticalId { get; private set; }
        public virtual User User { get; private set; }
        public virtual Political Political { get; private set; }

        public Rating(RateEnum rate, Guid userId, int politicalId)
        {
            Rate = rate;
            UserId = userId;
            PoliticalId = politicalId;
        }

        // Empty constructor for EF
        protected Rating()
        {

        }

        public void SetRate(RateEnum rate)
        {
            Rate = rate;
        }
    }
}
