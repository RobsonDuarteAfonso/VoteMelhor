using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Commands
{
    public class CreateVotingCommand : Notifiable, ICommand
    {        
        public VoteEnum Vote { get; set; }
        public DateTime VotingDate { get; set; }
        public int PoliticalId { get; set; }
        public Guid ProposalId { get; set; }
        
        public CreateVotingCommand()
        {
            
        }

        public CreateVotingCommand(VoteEnum vote, DateTime votingDate, int politicalId, Guid proposalId)
        {
            Vote = vote;
            VotingDate = votingDate;
            PoliticalId = politicalId;
            ProposalId = proposalId;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(Vote, "Vote", "Voto é inválido")
                    .IsLowerOrEqualsThan(VotingDate, DateTime.Now, "VotingDate","Data tem que se menor ou igual a data de hoje.")
                    .IsNullOrNullable(VotingDate, "VotingDate", "Data é inválida.")
                    .IsNullOrNullable(PoliticalId, "PoliticalId", "Político é inválido.")
                    .IsGreaterThan(PoliticalId, 0, "PoliticalId", "Político é inválido.")
                    .IsNotNull(ProposalId, "ProposalId", "Proposta é inválido")
            );
        }
    }
}