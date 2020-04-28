using System;
using VoteMelhor.ApplicationCore.Entities;

namespace VoteMelhor.ApplicationCore.Interfaces.Repositories
{
    public interface IPoliticoPartidoRepository : IRepository<PoliticoPartido>
    {
        PoliticoPartido VerifyExist(int politicoId, Guid partidoId);
        void SetAtual(int politicoId, int valor);
    }
}
