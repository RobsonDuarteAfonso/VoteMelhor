using System;
using System.Collections.Generic;
using System.Text;
using VoteMelhor.ApplicationCore.Enumations;

namespace VoteMelhor.ApplicationCore.Entities
{
    public class Proposta : Entity
    {
        public CasaLegislativa CasaLegislativa { get; private set; }

        public TipoProposta TipoProposta { get; private set; }

        public string Numeracao { get; private set; }

        public string Resumo { get; private set; }

        public string Descricao { get; private set; }

        public DateTime DtProposta { get; private set; }        
        
        public int PoliticoId { get; private set; }

        public virtual Politico Politico { get; private set; }

        public Proposta(Guid id, CasaLegislativa casalegislativa, TipoProposta tipoproposta, string numeracao, string resumo, string descricao, DateTime dtproposta, int politicoid)
        {
            Id = id;
            CasaLegislativa = casalegislativa;
            TipoProposta = tipoproposta;
            Numeracao = numeracao;
            Resumo = resumo;
            Descricao = descricao;
            DtProposta = dtproposta;
            PoliticoId = politicoid;
        }

        // Empty constructor for EF
        public Proposta()
        {

        }
    }
}
