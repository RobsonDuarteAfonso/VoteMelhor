using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands
{
    public class CreatePoliticoPartidoCommand : Notifiable, ICommand
    {        
        public int Atual { get; set; }
        public int PoliticoId { get; set; }
        public Guid PartidoId { get; set; }
        
        public CreatePoliticoPartidoCommand()
        {
            
        }

        public CreatePoliticoPartidoCommand(int atual, int politicoId, Guid partidoId)
        {
            Atual = atual;
            PoliticoId = politicoId;
            PartidoId = partidoId;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNullOrNullable(PoliticoId, "PoliticoId", "Político é inválido.")
                    .IsGreaterThan(PoliticoId, 0, "PoliticoId", "Político é inválido.")
                    .IsNotEmpty(PartidoId, "PartidoId", "Partido é inválido.")
            );
        }
    }
}        