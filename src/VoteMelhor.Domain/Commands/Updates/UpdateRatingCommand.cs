using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Commands.Updates
{
    public class UpdateRatingCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public RateEnum Rate { get; set; }
        public Guid UserId { get; set; }
        public int PoliticalId { get; set; }

        public UpdateRatingCommand()
        {
            
        }

        public UpdateRatingCommand(Guid id, RateEnum rate, Guid userId, int politicalId)
        {
            Id = id;
            Rate = rate;
            UserId = userId;
            PoliticalId = politicalId;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(Id, "Id", "Id é inválido.")
                    .IsNotEmpty(UserId, "UserId", "Usuário é inválido.")
                    .IsNotNull(Rate, "Rate", "Rate é inválido")
                    .IsNullOrNullable(PoliticalId, "PoliticalId", "Político é inválido.")
                    .IsGreaterThan(PoliticalId, 0, "PoliticalId", "Político é inválido.")
            );
        }
    }
}