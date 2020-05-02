using System;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Entities
{
    public class Proposta : Entity
    {
        public CasaLegislativaEnum CasaLegislativa { get; private set; }
        public TipoPropostaEnum TipoProposta { get; private set; }
        public string Numeracao { get; private set; }
        public string Resumo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DtProposta { get; private set; }        

        public Proposta(Guid id, CasaLegislativaEnum casalegislativa, TipoPropostaEnum tipoproposta, string numeracao, string resumo, string descricao, DateTime dtproposta)
        {
            Id = id;
            CasaLegislativa = casalegislativa;
            TipoProposta = tipoproposta;
            Numeracao = numeracao;
            Resumo = resumo;
            Descricao = descricao;
            DtProposta = dtproposta;
        }

        // Empty constructor for EF
        public Proposta()
        {

        }
    }
}
