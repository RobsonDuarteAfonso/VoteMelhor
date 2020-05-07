using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands
{
    public class UpdateVotacaoCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public VotoEnum Voto { get; private set; }
        public DateTime DtVotacao { get; private set; }

        public UpdateVotacaoCommand()
        {
            
        }

        public UpdateVotacaoCommand(Guid id, VotoEnum voto, DateTime dtVotacao)
        {
            Id = id;
            Voto = voto;
            DtVotacao = dtVotacao;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(Id, "Id", "Id é inválido.")
                    .IsNotNull(Voto, "Voto", "Voto é inválido")
                    .IsLowerOrEqualsThan(DtVotacao, DateTime.Now, "DtVotacao","Data tem que se menor ou igual a data de hoje.")
                    .IsNullOrNullable(DtVotacao, "DtVotacao", "Data é inválida.")
            );
        }
    }
}