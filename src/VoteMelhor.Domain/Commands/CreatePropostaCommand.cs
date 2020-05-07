using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Commands
{
    public class CreatePropostaCommand : Notifiable, ICommand
    {        
        public CasaLegislativaEnum CasaLegislativa { get; set; }
        public TipoPropostaEnum TipoProposta { get; set; }
        public string Numeracao { get; set; }
        public string Resumo { get; set; }
        public string Descricao { get; set; }
        public DateTime DtProposta { get; set; }    
        
        public CreatePropostaCommand()
        {
            
        }

        public CreatePropostaCommand(CasaLegislativaEnum casaLegislativa, TipoPropostaEnum tipoProposta, string numeracao, string resumo, string descricao, DateTime dtProposta)
        {
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
                    .IsNotNull(CasaLegislativa, "CasaLegislativa", "Casa Legislativa é inválido")
                    .IsNotNull(TipoProposta, "TipoProposta", "Tipo de Proposta é inválido")
                    .HasMinLen(Numeracao, 3, "Numeracao", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Numeracao, 20, "Numeracao", "Não pode ter mais do que 20 caracteres.")
                    .HasMinLen(Resumo, 6, "Resumo", "É necessário ao menos 6 caracteres.")
                    .HasMaxLen(Resumo, 200, "Resumo", "Não pode ter mais do que 200 caracteres.")
                    .HasMinLen(Descricao, 6, "Descricao", "É necessário ao menos 6 caracteres.")
                    .HasMaxLen(Descricao, 2000, "Descricao", "Não pode ter mais do que 2000 caracteres.")
                    .IsLowerOrEqualsThan(DtProposta, DateTime.Now, "DtProposta","Data tem que se menor ou igual a data de hoje.")
                    .IsNullOrNullable(DtProposta, "DtProposta", "Data é inválida.")
            );
        }
    }
}        