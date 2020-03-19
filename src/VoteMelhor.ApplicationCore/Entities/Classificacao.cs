using System;
using VoteMelhor.ApplicationCore.Enumations;

namespace VoteMelhor.ApplicationCore.Entities
{
    public class Classificacao : Entity
    {
        public Rate Rate { get; private set; }
        public Rate RatePublico { get; private set; }
        public Guid UsuarioId { get; private set; }
        public Guid PoliticoId { get; private set; }
        public virtual Usuario Usuario { get; private set; }
        public virtual Politico Politico { get; private set; }

        public Classificacao(Guid id, Rate rate, Rate ratepublico, Guid usuarioid, Guid politicoid)
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
