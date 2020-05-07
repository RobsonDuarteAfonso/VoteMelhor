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

        public Votacao(VotoEnum voto, DateTime dtvotacao, int politicoid, Guid propostaid)
        {
            Voto = voto;
            DtVotacao = dtvotacao;
            PoliticoId = politicoid;
            PropostaId = propostaid;
        }

        // Empty constructor for EF
        public Votacao()
        {

        }

        public void SetVoto(VotoEnum voto)
        {
            Voto = voto;
        }

        public void SetDataVotacao(DateTime dtVotacao)
        {
            DtVotacao = dtVotacao;
        }
    }
}
