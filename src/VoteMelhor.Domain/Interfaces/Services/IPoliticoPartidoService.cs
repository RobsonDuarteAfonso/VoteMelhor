using System;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Services
{
    public interface IPoliticoPartidoService : IService<PoliticoPartido>
    {
        PoliticoPartido VerifyExist(int politicoId, Guid partidoId);
        void SetAtual(int politicoId, int valor);
    }
}
