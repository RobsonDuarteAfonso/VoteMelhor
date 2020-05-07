using System.Collections.Generic;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Entities
{
    public class Politico
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public EstadoEnum Estado { get; private set; }
        public string Imagem { get; private set; }
        public virtual ICollection<PoliticoPartido> PoliticoPartidos { get; private set; }
        public virtual ICollection<Classificacao> Classificacoes { get; private set; }
        public virtual ICollection<Processo> Processos { get; private set; }
        public virtual ICollection<Votacao> Votacoes { get; private set; }
        public virtual ICollection<Cargo> Cargos { get; private set; }

        public Politico(int id, string nome, EstadoEnum estado, string imagem)
        {
            Id = id;
            Nome = nome;
            Estado = estado;
            Imagem = imagem;
        }

        // Empty constructor for EF
        protected Politico()
        {

        }

        public void SetNome(string nome)
        {
            Nome = nome;
        }

        public void SetEstado(EstadoEnum estado)
        {
            Estado = estado;
        }

        public void SetImagem(string imagem)
        {
            Imagem = imagem;
        }        

    }
}
