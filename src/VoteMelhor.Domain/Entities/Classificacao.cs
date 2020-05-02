using System;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Entities
{
    public class Classificacao : Entity
    {
        public RateEnum Rate { get; private set; }
        public RateEnum RatePublico { get; private set; }
        public Guid UsuarioId { get; private set; }
        public int PoliticoId { get; private set; }
        public virtual Usuario Usuario { get; private set; }
        public virtual Politico Politico { get; private set; }

        public Classificacao(Guid id, RateEnum rate, RateEnum ratepublico, Guid usuarioid, int politicoid)
        {
            Id = id;
            Rate = rate;
            RatePublico = ratepublico;
            UsuarioId = usuarioid;
            PoliticoId = politicoid;
        }

        // Empty constructor for EF
        protected Classificacao()
        {

        }
    }
}
