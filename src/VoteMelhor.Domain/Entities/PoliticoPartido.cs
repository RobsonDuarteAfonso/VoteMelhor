using System;

namespace VoteMelhor.Domain.Entities
{
    public class PoliticoPartido: Entity
    {
        public int Atual { get; private set; }
        public int PoliticoId { get; private set; }
        public Guid PartidoId { get; private set; }
        public virtual Politico Politico { get; private set; }
        public virtual Partido Partido { get; private set; }

        public PoliticoPartido(int atual, int politicoid, Guid partidoid)
        {
            Atual = atual;
            PoliticoId = politicoid;
            PartidoId = partidoid;
        }

        public void MarqueAtual()
        {
            Atual = 1;
        }

        public void DesmarqueAtual()
        {
            Atual = 0;
        }

        // Empty constructor for EF
        protected PoliticoPartido()
        {

        }
    }
}
