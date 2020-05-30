using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Commands.Creates
{
    public class CreateRatingCommand : Notifiable, ICommand
    {
        public RateEnum Rate { get; set; }
        public Guid UserId { get; set; }
        public Guid PoliticalId { get; set; }

        public CreateRatingCommand()
        {
            
        }

        public CreateRatingCommand(RateEnum rate, Guid userId, Guid politicalId)
        {
            Rate = rate;
            UserId = userId;
            PoliticalId = politicalId;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(UserId, "UserId", "Usuário é inválido.")
                    .IsNotNull(Rate, "Rate", "Rate é inválido")
                    .IsNotEmpty(PoliticalId, "PoliticalId", "Político é inválido.")
            );
        }
    }
}