using VoteMelhor.ApplicationCore.Entities;
using VoteMelhor.ApplicationCore.Interfaces.Repositories;
using VoteMelhor.ApplicationCore.Interfaces.Services;

namespace VoteMelhor.ApplicationCore.Services
{
    public class VotacaoService : Service<Votacao>, IVotacaoService
    {
        private readonly IVotacaoRepository _votacaoRepository;

        public VotacaoService(IVotacaoRepository votacaoRepository) : base(votacaoRepository)
        {
            _votacaoRepository = votacaoRepository;
        }
    }
}
