using System;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Repositories
{
    public interface IPoliticoPartidoRepository : IRepository<PoliticoPartido>
    {
        PoliticoPartido VerifyExist(int politicoId, Guid partidoId);
        //void SetAtual(int politicoId, int valor);
    }
}
