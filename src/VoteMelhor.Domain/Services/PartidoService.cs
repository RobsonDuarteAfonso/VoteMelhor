using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;
using VoteMelhor.Domain.Interfaces.Services;

namespace VoteMelhor.Domain.Services
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

        public Partido VerifyExist(string sigla)
        {
            return _partidoRepository.VerifyExist(sigla);
        }
    }
}
