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

        public Partido(string nome, string sigla, int numero, string imagem)
        {
            Nome = nome;
            Sigla = sigla;
            Numero = numero;
            Imagem = imagem;
        }

        // Empty constructor for EF
        protected Partido()
        {

        }

        public void SetNome(string nome)
        {
            Nome = nome;
        }

        public void SetSigla(string sigla)
        {
            Sigla = sigla;
        }

        public void SetImagem(string imagem)
        {
            Imagem = imagem;
        }

        public void SetNumero(int numero)
        {
            Numero = numero;
        }        
    }
}
