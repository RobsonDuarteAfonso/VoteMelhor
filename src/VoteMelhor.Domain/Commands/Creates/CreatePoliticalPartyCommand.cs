using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands.Creates
{
    public class CreatePoliticalPartyCommand : Notifiable, ICommand
    {        
        public bool Current { get; set; }
        public Guid PoliticalId { get; set; }
        public Guid PartyId { get; set; }
        
        public CreatePoliticalPartyCommand()
        {
            
        }

        public CreatePoliticalPartyCommand(bool current, Guid politicalId, Guid partyId)
        {
            Current = current;
            PoliticalId = politicalId;
            PartyId = partyId;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(PoliticalId, "PoliticalId", "Político é inválido.")
                    .IsNotEmpty(PartyId, "PartyId", "Partido é inválido.")
            );
        }
    }
}        