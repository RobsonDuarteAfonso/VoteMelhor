using System;

namespace VoteMelhor.ApplicationCore.Entities
{
    public class PoliticoPartido: Entity
    {
        public Guid PoliticoId { get; private set; }

        public Guid PartidoId { get; private set; }

        public virtual Politico Politico { get; private set; }

        public virtual Partido Partido { get; private set; }

        public PoliticoPartido(Guid id, Guid politicoid, Guid partidoid)
        {
            Id = id;
            PoliticoId = politicoid;
            PartidoId = partidoid;
        }

        // Empty constructor for EF
        public PoliticoPartido()
        {

        }
    }
}
