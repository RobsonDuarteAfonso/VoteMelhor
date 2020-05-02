using System;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;
using VoteMelhor.Domain.Interfaces.Services;

namespace VoteMelhor.Domain.Services
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
