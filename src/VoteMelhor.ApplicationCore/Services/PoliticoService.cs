using VoteMelhor.ApplicationCore.Entities;
using VoteMelhor.ApplicationCore.Interfaces.Repositories;
using VoteMelhor.ApplicationCore.Interfaces.Services;

namespace VoteMelhor.ApplicationCore.Services
{
    public class PoliticoService : Service<Politico>, IPoliticoService
    {
        private readonly IPoliticoRepository _politicoRepository;

        public PoliticoService(IPoliticoRepository politicoRepository) : base(politicoRepository)
        {
            _politicoRepository = politicoRepository;
        }
    }
}
