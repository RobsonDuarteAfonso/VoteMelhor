using System;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Entities
{
    public class Proposal : Entity
    {
        public HouseEnum House { get; private set; }
        public ProposalTypeEnum ProposalType { get; private set; }
        public string Numeration { get; private set; }
        public string Summary { get; private set; }
        public string Description { get; private set; }
        public DateTime ProposalDate { get; private set; }        

        public Proposal(HouseEnum house, ProposalTypeEnum proposalType, string numeration, string summary, string description, DateTime proposalDate)
        {
            House = house;
            ProposalType = proposalType;
            Numeration = numeration;
            Summary = summary;
            Description = description;
            ProposalDate = proposalDate;
        }

        // Empty constructor for EF
        protected Proposal()
        {

        }

        public void SetHouse(HouseEnum house)
        {
            House = house;
        }

        public void SetProposalType( ProposalTypeEnum proposalType)
        {
            ProposalType = proposalType;
        }

        public void SetNumeration(string numeration)
        {
            Numeration = numeration;
        }

        public void SetSummary(string summary)
        {
            Summary = summary;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetProposalDate(DateTime proposalDate)
        {
            ProposalDate = proposalDate;
        }
    }
}
