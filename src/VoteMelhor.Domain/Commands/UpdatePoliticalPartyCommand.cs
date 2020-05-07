using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands
{
    public class UpdatePoliticalPartyCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public int Current { get; set; }
        public int PoliticalId { get; set; }
        public Guid PartyId { get; set; }

        public UpdatePoliticalPartyCommand()
        {
            
        }

        public UpdatePoliticalPartyCommand(Guid id, int current, int politicalId, Guid partyId)
        {
            Id = id;
            Current = current;
            PoliticalId = politicalId;
            PartyId = partyId;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(Id, "Id", "Id é inválido.")
                    .IsNullOrNullable(PoliticalId, "PoliticalId", "Político é inválido.")
                    .IsGreaterThan(PoliticalId, 0, "PoliticalId", "Político é inválido.")
                    .IsNotEmpty(PartyId, "PartyId", "Partido é inválido.")
                    .IsNullOrNullable(Current, "Current", "Valor é inválido.")
                    .IsBetween(Current, 0, 1, "Current", "Valor é inválido.")
            );
        }
    }
}