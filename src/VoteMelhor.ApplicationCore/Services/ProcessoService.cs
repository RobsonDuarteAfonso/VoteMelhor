using VoteMelhor.ApplicationCore.Entities;
using VoteMelhor.ApplicationCore.Interfaces.Repositories;
using VoteMelhor.ApplicationCore.Interfaces.Services;

namespace VoteMelhor.ApplicationCore.Services
{
    public class ProcessoService : Service<Processo>, IProcessoService
    {
        private readonly IProcessoRepository _processoRepository;

        public ProcessoService(IProcessoRepository processoRepository) : base(processoRepository)
        {
            _processoRepository = processoRepository;
        }
    }
}
