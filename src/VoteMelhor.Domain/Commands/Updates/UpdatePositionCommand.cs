using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands.Updates
{
    public class UpdatePositionCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public bool Current { get; set; }
        public Guid PoliticalId { get; set; }
  

        public UpdatePositionCommand()
        {
            
        }

        public UpdatePositionCommand(Guid id, bool current, Guid politicalId)
        {
            Id = id;
            Current = current;
            PoliticalId = politicalId;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(Id, "Id", "Cargo é inválido.")
                    .IsNotEmpty(PoliticalId, "PoliticalId", "Político é inválido.")
            );
        }
    }
}