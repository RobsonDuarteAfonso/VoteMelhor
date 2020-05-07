using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Commands
{
    public class CreateVotacaoCommand : Notifiable, ICommand
    {        
        public VotoEnum Voto { get; set; }
        public DateTime DtVotacao { get; set; }
        public int PoliticoId { get; set; }
        public Guid PropostaId { get; set; }
        
        public CreateVotacaoCommand()
        {
            
        }

        public CreateVotacaoCommand(VotoEnum voto, DateTime dtVotacao, int politicoId, Guid propostaId)
        {
            Voto = voto;
            DtVotacao = dtVotacao;
            PoliticoId = politicoId;
            PropostaId = propostaId;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(Voto, "Voto", "Voto é inválido")
                    .IsLowerOrEqualsThan(DtVotacao, DateTime.Now, "DtVotacao","Data tem que se menor ou igual a data de hoje.")
                    .IsNullOrNullable(DtVotacao, "DtVotacao", "Data é inválida.")
                    .IsNullOrNullable(PoliticoId, "PoliticoId", "Político é inválido.")
                    .IsGreaterThan(PoliticoId, 0, "PoliticoId", "Político é inválido.")
                    .IsNotNull(PropostaId, "PropostaId", "Proposta é inválido")
            );
        }
    }
}