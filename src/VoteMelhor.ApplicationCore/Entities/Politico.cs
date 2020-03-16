using System;
using System.Collections.Generic;
using VoteMelhor.ApplicationCore.Enumations;

namespace VoteMelhor.ApplicationCore.Entities
{
    public class Politico : Entity
    {     
        public string Nome { get; private set; }

        public Estado Estado { get; private set; }

        public string Imagem { get; private set; }

        public virtual ICollection<PoliticoPartido> PoliticoPartidos { get; private set; }

        public virtual ICollection<Classificacao> Classificacoes { get; private set; }

        public virtual ICollection<Processo> Processos  { get; private set; }

        public virtual ICollection<Votacao> Votacoes { get; private set; }

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
