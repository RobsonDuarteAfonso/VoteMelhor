using VoteMelhor.ApplicationCore.Entities;
using VoteMelhor.ApplicationCore.Interfaces.Repositories;
using VoteMelhor.ApplicationCore.Interfaces.Services;

namespace VoteMelhor.ApplicationCore.Services
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
