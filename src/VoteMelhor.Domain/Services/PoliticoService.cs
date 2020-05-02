using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;
using VoteMelhor.Domain.Interfaces.Services;

namespace VoteMelhor.Domain.Services
{
    public class PoliticoService : Service<Politico>, IPoliticoService
    {
        private readonly IPoliticoRepository _politicoRepository;

        public PoliticoService(IPoliticoRepository politicoRepository) : base(politicoRepository)
        {
            _politicoRepository = politicoRepository;
        }

        public void AddNewPolitico(Politico politico)
        {
            _politicoRepository.AddNewPolitico(politico);
        }

        public Politico VerifyExist(int id)
        {
            return _politicoRepository.VerifyExist(id);
        }
    }
}
