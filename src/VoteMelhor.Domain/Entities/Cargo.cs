namespace VoteMelhor.Domain.Entities
{
    public class Cargo : Entity
    {
        public string Nome { get; private set; }
        public int Atual { get; private set; }
        public int PoliticoId { get; private set; }
        public virtual Politico Politico { get; private set; }


        public Cargo(string nome, int politicoid)
        {
            Nome = nome;
            Atual = 1;
            PoliticoId = politicoid;
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
        protected Cargo()
        {

        }
    }
}
