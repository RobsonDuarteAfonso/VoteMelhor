using System;
using VoteMelhor.ApplicationCore.Enumations;

namespace VoteMelhor.WebApi.ViewModels
{
    public class PropostaViewModel
    {
        public Guid Id { get; set; }
        public CasaLegislativa CasaLegislativa { get; set; }
        public TipoProposta TipoProposta { get; set; }
        public string Numeracao { get; set; }
        public string Resumo { get; set; }
        public string Descricao { get; set; }
        public DateTime DtProposta { get; set; }
    }
}
