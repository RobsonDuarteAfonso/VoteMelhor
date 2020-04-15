using System;
using VoteMelhor.ApplicationCore.Enumations;

namespace VoteMelhor.WebApi.ViewModels
{
    public class ProcessoViewModel
    {
        public Guid Id { get; set; }
        public string Resumo { get; set; }
        public string Detalhe { get; set; }
        public DateTime DtPublicacao { get; set; }
        public DateTime DtAtualizacao { get; set; }
        public Situacao Situacao { get; set; }
        public PoliticoViewModel Politico { get; set; }
    }
}
