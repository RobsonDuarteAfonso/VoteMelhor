using System;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Entities
{
    public class Voting : Entity
    {
        public VoteEnum Vote { get; private set; }
        public DateTime VotingDate { get; private set; }
        public Guid PoliticalId { get; private set; }
        public Guid ProposalId { get; private set; }
        public virtual Proposal Proposal { get;  private set; }
        public virtual Political Political { get; private set; }

        public Voting(VoteEnum vote, DateTime votingDate, Guid politicalId, Guid proposalId)
        {
            Vote = vote;
            VotingDate = votingDate;
            PoliticalId = politicalId;
            ProposalId = proposalId;
        }

        // Empty constructor for EF
        public Voting()
        {

        }

        public void SetVote(VoteEnum vote)
        {
            Vote = vote;
        }

        public void SetVotingDate(DateTime votingDate)
        {
            VotingDate = votingDate;
        }
    }
}
