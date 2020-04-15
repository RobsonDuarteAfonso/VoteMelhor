using System;
using VoteMelhor.ApplicationCore.Enumations;

namespace VoteMelhor.WebApi.ViewModels
{
    public class VotacaoViewModel
    {
        public Guid Id { get; set; }
        public Voto Voto { get; set; }
        public DateTime DtVotacao { get; set; }
        public PropostaViewModel Proposta { get; set; }
        public PoliticoViewModel Politico { get; set; }
    }
}
