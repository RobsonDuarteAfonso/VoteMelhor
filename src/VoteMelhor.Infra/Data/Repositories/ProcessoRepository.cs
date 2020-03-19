using VoteMelhor.ApplicationCore.Entities;
using VoteMelhor.ApplicationCore.Interfaces.Repositories;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class ProcessoRepository : Repository<Processo>, IProcessoRepository
    {
        public ProcessoRepository(VoteMelhorContext context)
            : base(context)
        {

        }
    }
}
