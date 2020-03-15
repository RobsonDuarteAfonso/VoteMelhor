using System;
using VoteMelhor.ApplicationCore.Enumations;

namespace VoteMelhor.ApplicationCore.Entities
{
    public class Politico : Entity
    {     
        public string Nome { get; private set; }

        public Estado Estado { get; private set; }

        public string Imagem { get; private set; }

        public Politico(Guid id, string nome, Estado estado, string imagem)
        {
            Id = id;
            Nome = nome;
            Estado = estado;
            Imagem = imagem;
        }

        // Empty constructor for EF
        protected Politico() { }

    }
}
