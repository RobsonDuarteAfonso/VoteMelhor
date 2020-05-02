using System;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.WebApi.ViewModels
{
    public class ClassificacaoViewModel
    {
        public Guid Id { get; set; }
        public RateEnum Rate { get; set; }
        public RateEnum RatePublico { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        public PoliticoViewModel Politico { get; set; }
    }
}
