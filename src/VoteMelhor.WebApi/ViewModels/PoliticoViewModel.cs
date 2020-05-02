using System.Collections.Generic;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.WebApi.ViewModels
{
    public class PoliticoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public EstadoEnum Estado { get; set; }
        public string Imagem { get; set; }
        public ICollection<PoliticoPartidoViewModel> PoliticoPartidos { get; set; }
        public ICollection<ClassificacaoViewModel> Classificacoes { get; set; }
        public ICollection<ProcessoViewModel> Processos { get; set; }
        public ICollection<VotacaoViewModel> Votacoes { get; set; }
        public ICollection<CargoViewModel> Cargos { get; set; }
    }
}
