using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands.Updates
{
    public class UpdatePoliticalPartyCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public bool Current { get; set; }
        public Guid PoliticalId { get; set; }
        public Guid PartyId { get; set; }

        public UpdatePoliticalPartyCommand()
        {
            
        }

        public UpdatePoliticalPartyCommand(Guid id, bool current, Guid politicalId, Guid partyId)
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
                    .IsNotEmpty(PoliticalId, "PoliticalId", "Político é inválido.")
                    .IsNotEmpty(PartyId, "PartyId", "Partido é inválido.")
            );
        }
    }
}