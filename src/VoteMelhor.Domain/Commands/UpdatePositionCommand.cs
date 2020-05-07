using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands
{
    public class UpdatePositionCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public int Current { get; set; }
        public int PoliticalId { get; set; }
  

        public UpdatePositionCommand()
        {
            
        }

        public UpdatePositionCommand(Guid id, int current, int politicalId)
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
                    .IsNullOrNullable(Current, "Current", "Valor é inválido.")
                    .IsBetween(Current, 0, 1, "Current", "Valor é inválido.")
                    .IsNullOrNullable(PoliticalId, "PoliticalId", "Político é inválido.")
                    .IsGreaterThan(PoliticalId, 0, "PoliticalId", "Político é inválido.")
            );
        }
    }
}