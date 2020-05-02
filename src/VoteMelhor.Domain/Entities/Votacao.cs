using System;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Entities
{
    public class Votacao : Entity
    {
        public VotoEnum Voto { get; private set; }
        public DateTime DtVotacao { get; private set; }
        public int PoliticoId { get; private set; }
        public Guid PropostaId { get; private set; }
        public virtual Proposta Proposta { get;  private set; }
        public virtual Politico Politico { get; private set; }

        public Votacao(Guid id, VotoEnum voto, DateTime dtvotacao, int politicoid, Guid propostaid)
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
