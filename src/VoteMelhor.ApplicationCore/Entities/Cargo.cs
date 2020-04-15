using System;

namespace VoteMelhor.ApplicationCore.Entities
{
    public class Cargo : Entity
    {
        public string Nome { get; private set; }
        public int Atual { get; private set; }
        public int PoliticoId { get; private set; }
        public virtual Politico Politico { get; private set; }


        public Cargo(Guid id, string nome, int atual, int politicoid)
        {
            Id = id;
            Nome = nome;
            Atual = atual;
            PoliticoId = politicoid;
        }

        // Empty constructor for EF
        protected Cargo()
        {

        }
    }
}
