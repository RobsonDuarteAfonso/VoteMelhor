using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands
{
    public class UpdateCargoCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public int Atual { get; set; }
        public int PoliticoId { get; set; }
  

        public UpdateCargoCommand()
        {
            
        }

        public UpdateCargoCommand(Guid id, int atual, int politicoId)
        {
            Id = id;
            Atual = atual;
            PoliticoId = politicoId;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(Id, "Id", "Cargo é inválido.")
                    .IsNullOrNullable(Atual, "Atual", "Valor é inválido.")
                    .IsBetween(Atual, 0, 1, "Atual", "Valor é inválido.")
                    .IsNullOrNullable(PoliticoId, "PoliticoId", "Político é inválido.")
                    .IsGreaterThan(PoliticoId, 0, "PoliticoId", "Político é inválido.")
            );
        }
    }
}