using System;

namespace VoteMelhor.WebApi.ViewModels
{
    public class PoliticoPartidoViewModel
    {
        public Guid Id { get; set; }
        public int Atual { get; set; }
        public PoliticoViewModel Politico { get; set; }
        public PartidoViewModel Partido { get; set; }
    }
}
