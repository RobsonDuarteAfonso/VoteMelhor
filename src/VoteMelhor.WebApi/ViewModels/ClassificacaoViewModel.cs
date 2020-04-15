using System;
using VoteMelhor.ApplicationCore.Enumations;

namespace VoteMelhor.WebApi.ViewModels
{
    public class ClassificacaoViewModel
    {
        public Guid Id { get; set; }
        public Rate Rate { get; set; }
        public Rate RatePublico { get; set; }
        public UsuarioViewModel Usuario { get; set; }
        public PoliticoViewModel Politico { get; set; }
    }
}
