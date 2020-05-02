using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;
using VoteMelhor.Domain.Interfaces.Services;

namespace VoteMelhor.Domain.Services
{
    public class PropostaService : Service<Proposta>, IPropostaService
    {
        private readonly IPropostaRepository _propostaRepository;

        public PropostaService(IPropostaRepository propostaRepository) : base(propostaRepository)
        {
            _propostaRepository = propostaRepository;
        }
    }
}
