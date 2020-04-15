using VoteMelhor.ApplicationCore.Entities;
using VoteMelhor.ApplicationCore.Interfaces.Repositories;
using VoteMelhor.ApplicationCore.Interfaces.Services;

namespace VoteMelhor.ApplicationCore.Services
{
    public class PartidoService : Service<Partido>, IPartidoService
    {
        private readonly IPartidoRepository _partidoRepository;

        public PartidoService(IPartidoRepository partidoRepository) : base(partidoRepository)
        {
            _partidoRepository = partidoRepository;
        }

        public Partido VerifyExist(Partido partido)
        {
            return _partidoRepository.VerifyExist(partido);
        }
    }
}
