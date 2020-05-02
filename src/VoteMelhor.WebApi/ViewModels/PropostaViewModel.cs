using System;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.WebApi.ViewModels
{
    public class PropostaViewModel
    {
        public Guid Id { get; set; }
        public CasaLegislativaEnum CasaLegislativa { get; set; }
        public TipoPropostaEnum TipoProposta { get; set; }
        public string Numeracao { get; set; }
        public string Resumo { get; set; }
        public string Descricao { get; set; }
        public DateTime DtProposta { get; set; }
    }
}
