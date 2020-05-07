using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Commands
{
    public class CreateProcessoCommand : Notifiable, ICommand
    {        
        public string Resumo { get; set; }
        public string Detalhe { get; set; }
        public DateTime DtPublicacao { get; set; }
        public SituacaoEnum Situacao { get; set; }
        public int PoliticoId { get; set; }
        
        public CreateProcessoCommand()
        {
            
        }

        public CreateProcessoCommand(string resumo, string detalhe, DateTime dtPublicacao, SituacaoEnum situacao, int politicoId)
        {
            Resumo = resumo;
            Detalhe = detalhe;
            DtPublicacao = dtPublicacao;
            Situacao = situacao;
            PoliticoId = politicoId;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Resumo, 6, "Resumo", "É necessário ao menos 6 caracteres.")
                    .HasMaxLen(Resumo, 200, "Resumo", "Não pode ter mais do que 200 caracteres.")
                    .HasMinLen(Detalhe, 6, "Detalhe", "É necessário ao menos 6 caracteres.")
                    .HasMaxLen(Detalhe, 2000, "Detalhe", "Não pode ter mais do que 2000 caracteres.")
                    .IsLowerOrEqualsThan(DtPublicacao, DateTime.Now, "DtPublicacao","Data tem que se menor ou igual a data de hoje.")
                    .IsNullOrNullable(DtPublicacao, "DtPublicacao", "Data é inválida.")
                    .IsNotNull(Situacao, "Situacao", "Situação é inválido")
                    .IsNullOrNullable(PoliticoId, "PoliticoId", "Político é inválido.")
                    .IsGreaterThan(PoliticoId, 0, "PoliticoId", "Político é inválido.")
            );
        }
    }
}        