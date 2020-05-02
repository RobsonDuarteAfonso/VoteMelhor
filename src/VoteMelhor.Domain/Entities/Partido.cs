using System;
using System.Collections.Generic;

namespace VoteMelhor.Domain.Entities
{
    public class Partido : Entity
    {
        public string Nome { get; private set; }
        public string Sigla { get; private set; }
        public int Numero { get; private set; }
        public string Imagem { get; private set; }
        public virtual ICollection<PoliticoPartido> PoliticoPartidos { get; private set; }

        public Partido(Guid id, string nome, string sigla, int numero, string imagem)
        {
            Id = id;
            Nome = nome;
            Sigla = sigla;
            Numero = numero;
            Imagem = imagem;
        }

        // Empty constructor for EF
        public Partido()
        {

        }
    }
}
