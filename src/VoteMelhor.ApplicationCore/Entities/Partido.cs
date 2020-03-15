using System;

namespace VoteMelhor.ApplicationCore.Entities
{
    public class Partido : Entity
    {
        public string Nome { get; private set; }

        public char Sigla { get; private set; }

        public int Numero { get; private set; }

        public string Imagem { get; private set; }

        public Partido(Guid id, string nome, char sigla, int numero, string imagem)
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
