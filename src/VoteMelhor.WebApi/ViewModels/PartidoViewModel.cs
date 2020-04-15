using System;
using System.Collections.Generic;

namespace VoteMelhor.WebApi.ViewModels
{
    public class PartidoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public int Numero { get; set; }
        public string Imagem { get; set; }
        public ICollection<PoliticoPartidoViewModel> PoliticoPartidos { get; set; }
    }
}
