using System.Collections.Generic;
using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Services
{
    public interface IPoliticoService : IService<Politico>
    {
        void AddNewPolitico(Politico politico);
        Politico VerifyExist(int id);
    }
}
