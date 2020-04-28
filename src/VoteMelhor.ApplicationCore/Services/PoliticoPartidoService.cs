using System;
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

        public PoliticoPartido VerifyExist(int politicoId, Guid partidoId)
        {
            return _politicoPartidoRepository.VerifyExist(politicoId, partidoId);
        }

        public void SetAtual(int politicoId, int valor)
        {
            _politicoPartidoRepository.SetAtual(politicoId, valor);
        }

    }
}
