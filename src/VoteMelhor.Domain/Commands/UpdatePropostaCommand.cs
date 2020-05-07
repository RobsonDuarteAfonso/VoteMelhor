using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands
{
    public class UpdatePropostaCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public CasaLegislativaEnum CasaLegislativa { get; set; }
        public TipoPropostaEnum TipoProposta { get; set; }
        public string Numeracao { get; set; }
        public string Resumo { get; set; }
        public string Descricao { get; set; }
        public DateTime DtProposta { get; set; }  

        public UpdatePropostaCommand()
        {
            
        }

        public UpdatePropostaCommand(Guid id, CasaLegislativaEnum casaLegislativa, TipoPropostaEnum tipoProposta, string numeracao, string resumo, string descricao, DateTime dtProposta)
        {
            Id = id;
            CasaLegislativa = casaLegislativa;
            TipoProposta = tipoProposta;
            Numeracao = numeracao;
            Resumo = resumo;
            Descricao = descricao;
            DtProposta = dtProposta;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(Id, "Id", "Id é inválido.")
                    .IsNotNull(CasaLegislativa, "CasaLegislativa", "Casa Legislativa é inválido")
                    .IsNotNull(TipoProposta, "TipoProposta", "Tipo de Proposta é inválido")                                        
                    .HasMinLen(Resumo, 3, "Resumo", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Resumo, 200, "Resumo", "Não pode ter mais do que 200 caracteres.")
                    .HasMinLen(Descricao, 3, "Descricao", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Descricao, 2000, "Descricao", "Não pode ter mais do que 2000 caracteres.")
            );
        }
    }
}