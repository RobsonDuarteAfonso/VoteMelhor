using System;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Entities
{
    public class Rating : Entity
    {
        public RateEnum Rate { get; private set; }
        public Guid UserId { get; private set; }
        public Guid PoliticalId { get; private set; }
        public virtual User User { get; private set; }
        public virtual Political Political { get; private set; }

        public Rating(RateEnum rate, Guid userId, Guid politicalId)
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

        public RateEnum CalculateRate(double value)
        {
            if (value >= 80)
            {
                return RateEnum.EXC;
            }
            else if(value < 80 && value >= 60)
            {
                return RateEnum.BOM;
            }
            else if(value < 60 && value >= 40)
            {
                return RateEnum.REG;
            }
            else if(value < 40 && value >= 20)
            {
                return RateEnum.RUI;
            }
            else
            {
                return RateEnum.PES;
            }
        }
    }
}
