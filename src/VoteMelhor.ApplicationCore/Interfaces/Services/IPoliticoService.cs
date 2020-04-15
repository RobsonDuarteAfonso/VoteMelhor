using System.Collections.Generic;
using VoteMelhor.ApplicationCore.Entities;

namespace VoteMelhor.ApplicationCore.Interfaces.Services
{
    public interface IPoliticoService : IService<Politico>
    {
        void AddNewPolitico(Politico politico);
    }
}
