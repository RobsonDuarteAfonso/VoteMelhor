using System;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Entities
{
    public class LawSuit : Entity
    {
        public string Summary { get; private set; }
        public string Description { get; private set; }
        public DateTime PublicationDate { get; private set; }
        public DateTime UpdateDate { get; private set; }
        public SituationEnum Situation { get; private set; }
        public Guid PoliticalId { get; private set; }
        public virtual Political Political { get; private set; }

        public LawSuit(string summary, string description, SituationEnum situation, Guid politicalid)
        {
            Summary = summary;
            Description = description;
            Situation = situation;
            PoliticalId = politicalid;
        }

        // Empty constructor for EF
        protected LawSuit()
        {

        }

        public void SetSummary(string summary)
        {
            Summary = summary;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetSituation(SituationEnum situation) 
        {
            Situation = situation;
        }
        
        public void SetPublicationDate()
        {
            PublicationDate = DateTime.Now;
        }

        public void SetUpdateDate()
        {
            UpdateDate = DateTime.Now;
        }

    }
}
