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

        public Proposta(CasaLegislativaEnum casalegislativa, TipoPropostaEnum tipoproposta, string numeracao, string resumo, string descricao, DateTime dtproposta)
        {
            CasaLegislativa = casalegislativa;
            TipoProposta = tipoproposta;
            Numeracao = numeracao;
            Resumo = resumo;
            Descricao = descricao;
            DtProposta = dtproposta;
        }

        // Empty constructor for EF
        protected Proposta()
        {

        }

        public void SetCasaLegislativa(CasaLegislativaEnum casalegislativa)
        {
            CasaLegislativa = casalegislativa;
        }

        public void SetTipoProposta( TipoPropostaEnum tipoProposta)
        {
            TipoProposta = tipoProposta;
        }

        public void SetNumeracao(string numeracao)
        {
            Numeracao = numeracao;
        }

        public void SetResumo(string resumo)
        {
            Resumo = resumo;
        }

        public void SetDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void SetDataProposta(DateTime dtProposta)
        {
            DtProposta = dtProposta;
        }
    }
}
