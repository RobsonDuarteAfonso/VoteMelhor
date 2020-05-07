using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands
{
    public class UpdatePoliticoPartidoCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public int Atual { get; set; }
        public int PoliticoId { get; set; }
        public Guid PartidoId { get; set; }

        public UpdatePoliticoPartidoCommand()
        {
            
        }

        public UpdatePoliticoPartidoCommand(Guid id, int atual, int politicoId, Guid partidoId)
        {
            Id = id;
            Atual = atual;
            PoliticoId = politicoId;
            PartidoId = partidoId;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(Id, "Id", "Id é inválido.")
                    .IsNullOrNullable(PoliticoId, "PoliticoId", "Político é inválido.")
                    .IsGreaterThan(PoliticoId, 0, "PoliticoId", "Político é inválido.")
                    .IsNotEmpty(PartidoId, "PartidoId", "Partido é inválido.")
                    .IsNullOrNullable(Atual, "Atual", "Valor é inválido.")
                    .IsBetween(Atual, 0, 1, "Atual", "Valor é inválido.")
            );
        }
    }
}