namespace VoteMelhor.ApplicationCore.Entities
{
    public class PoliticoPartido: Entity
    {
        public int PoliticoId { get; private set; }

        public int PartidoId { get; private set; }

        public virtual Politico Politico { get; private set; }

        public virtual Partido Partido { get; private set; }

        public PoliticoPartido(Politico politico, Partido partido)
        {
            Politico = politico;
            Partido = partido;
        }

        // Empty constructor for EF
        public PoliticoPartido()
        {

        }
    }
}
