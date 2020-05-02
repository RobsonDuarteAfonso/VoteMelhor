using System;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.WebApi.ViewModels
{
    public class VotacaoViewModel
    {
        public Guid Id { get; set; }
        public VotoEnum Voto { get; set; }
        public DateTime DtVotacao { get; set; }
        public PropostaViewModel Proposta { get; set; }
        public PoliticoViewModel Politico { get; set; }
    }
}
