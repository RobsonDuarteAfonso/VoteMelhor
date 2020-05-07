using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Commands
{
    public class UpdateClassificacaoCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public RateEnum Rate { get; set; }
        public Guid UsuarioId { get; set; }
        public int PoliticoId { get; set; }

        public UpdateClassificacaoCommand()
        {
            
        }

        public UpdateClassificacaoCommand(Guid id, RateEnum rate, Guid usuarioId, int politicoId)
        {
            Id = id;
            Rate = rate;
            UsuarioId = usuarioId;
            PoliticoId = politicoId;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(Id, "Id", "Id é inválido.")
                    .IsNotEmpty(UsuarioId, "UsuarioId", "Usuário é inválido.")
                    .IsNotNull(Rate, "Rate", "Rate é inválido")
                    .IsNullOrNullable(PoliticoId, "PoliticoId", "Político é inválido.")
                    .IsGreaterThan(PoliticoId, 0, "PoliticoId", "Político é inválido.")
            );
        }
    }
}