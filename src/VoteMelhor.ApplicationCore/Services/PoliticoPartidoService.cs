using VoteMelhor.ApplicationCore.Entities;
using VoteMelhor.ApplicationCore.Interfaces.Repositories;
using VoteMelhor.ApplicationCore.Interfaces.Services;

namespace VoteMelhor.ApplicationCore.Services
{
    public class PoliticoPartidoService : Service<PoliticoPartido>, IPoliticoPartidoService
    {
        private readonly IPoliticoPartidoRepository _politicoPartidoRepository;

        public PoliticoPartidoService(IPoliticoPartidoRepository politicoPartidoRepository) : base(politicoPartidoRepository)
        {
            _politicoPartidoRepository = politicoPartidoRepository;
        }
    }
}
