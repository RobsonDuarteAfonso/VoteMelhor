using System;

namespace VoteMelhor.ApplicationCore.Entities
{
    public class PoliticoPartido: Entity
    {
        public int Atual { get; private set; }
        public int PoliticoId { get; private set; }
        public Guid PartidoId { get; private set; }
        public virtual Politico Politico { get; private set; }
        public virtual Partido Partido { get; private set; }

        public PoliticoPartido(Guid id, int atual, int politicoid, Guid partidoid)
        {
            Id = id;
            Atual = atual;
            PoliticoId = politicoid;
            PartidoId = partidoid;
        }

        // Empty constructor for EF
        public PoliticoPartido()
        {

        }
    }
}
