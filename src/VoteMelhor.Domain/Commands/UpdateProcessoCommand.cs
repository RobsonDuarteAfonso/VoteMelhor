using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands
{
    public class UpdateProcessoCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Resumo { get; set; }
        public string Detalhe { get; set; }
        public DateTime DtPublicacao { get; set; }
        public DateTime DtAtualizacao { get; set; }
        public SituacaoEnum Situacao { get; set; }
        public int PoliticoId { get; set; }

        public UpdateProcessoCommand()
        {
            
        }

        public UpdateProcessoCommand(Guid id, string resumo, string detalhe, SituacaoEnum situacao, int politicoId)
        {
            Id = id;
            Resumo = resumo;
            Detalhe = detalhe;
            Situacao = situacao;
            PoliticoId = politicoId;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(Id, "Id", "Id é inválido.")
                    .HasMinLen(Resumo, 3, "Resumo", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Resumo, 200, "Resumo", "Não pode ter mais do que 200 caracteres.")
                    .HasMinLen(Detalhe, 3, "Detalhe", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Detalhe, 2000, "Detalhe", "Não pode ter mais do que 2000 caracteres.")
                    .IsNotNull(Situacao, "Situacao", "Situacao é inválido")
                    .IsNullOrNullable(PoliticoId, "PoliticoId", "Político é inválido.")
                    .IsGreaterThan(PoliticoId, 0, "PoliticoId", "Político é inválido.")
            );
        }
    }
}