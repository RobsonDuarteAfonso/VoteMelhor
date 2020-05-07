using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands
{
    public class UpdateVotingCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public VoteEnum Vote { get; private set; }
        public DateTime VotingDate { get; private set; }

        public UpdateVotingCommand()
        {
            
        }

        public UpdateVotingCommand(Guid id, VoteEnum vote, DateTime votingDate)
        {
            Id = id;
            Vote = vote;
            VotingDate = votingDate;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(Id, "Id", "Id é inválido.")
                    .IsNotNull(Vote, "Vote", "Voto é inválido")
                    .IsLowerOrEqualsThan(VotingDate, DateTime.Now, "VotingDate","Data tem que se menor ou igual a data de hoje.")
                    .IsNullOrNullable(VotingDate, "VotingDate", "Data é inválida.")
            );
        }
    }
}