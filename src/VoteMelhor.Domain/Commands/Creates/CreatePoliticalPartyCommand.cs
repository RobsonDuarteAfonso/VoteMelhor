using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands.Creates
{
    public class CreatePoliticalPartyCommand : Notifiable, ICommand
    {        
        public bool Current { get; set; }
        public int PoliticalId { get; set; }
        public Guid PartyId { get; set; }
        
        public CreatePoliticalPartyCommand()
        {
            
        }

        public CreatePoliticalPartyCommand(bool current, int politicalId, Guid partyId)
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
                    .IsNullOrNullable(PoliticalId, "PoliticalId", "Político é inválido.")
                    .IsGreaterThan(PoliticalId, 0, "PoliticalId", "Político é inválido.")
                    .IsNotEmpty(PartyId, "PartyId", "Partido é inválido.")
            );
        }
    }
}        