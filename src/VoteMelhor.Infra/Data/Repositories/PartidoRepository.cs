using System.Linq;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class PartidoRepository : Repository<Partido>, IPartidoRepository
    {
        public PartidoRepository(VoteMelhorContext context)
            : base(context)
        {

        }
        public Partido VerifyExist(Partido partido)
        {
            return DbSet.FirstOrDefault(c => c.Sigla == partido.Sigla && c.Numero == partido.Numero);
        }

        public Partido VerifyExist(string sigla)
        {
            return DbSet.FirstOrDefault(c => c.Sigla == sigla);
        }
    }
}
