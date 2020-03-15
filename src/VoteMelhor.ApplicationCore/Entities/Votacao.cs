using System;
using VoteMelhor.ApplicationCore.Enumations;

namespace VoteMelhor.ApplicationCore.Entities
{
    public class Votacao : Entity
    {
        public Voto Voto { get; private set; }

        public DateTime DtVotacao { get; private set; }

        public int PoliticoId { get; private set; }

        public int PropostaId { get; private set; }

        public virtual Proposta Proposta { get;  private set; }

        public virtual Politico Politico { get; private set; }

        public Votacao(Guid id, Voto voto, DateTime dtvotacao, int politicoid, int propostaid)
        {
            Id = id;
            Voto = voto;
            DtVotacao = dtvotacao;
            PoliticoId = politicoid;
            PropostaId = propostaid;
        }

        // Empty constructor for EF
        public Votacao()
        {

        }
    }
}
