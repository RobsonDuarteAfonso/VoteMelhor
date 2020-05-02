using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;
using VoteMelhor.Domain.Interfaces.Services;

namespace VoteMelhor.Domain.Services
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
