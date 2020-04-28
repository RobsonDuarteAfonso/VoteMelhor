using System;
using VoteMelhor.ApplicationCore.Entities;

namespace VoteMelhor.ApplicationCore.Interfaces.Services
{
    public interface IPoliticoPartidoService : IService<PoliticoPartido>
    {
        PoliticoPartido VerifyExist(int politicoId, Guid partidoId);
        void SetAtual(int politicoId, int valor);
    }
}
