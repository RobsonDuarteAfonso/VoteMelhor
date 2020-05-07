using System.Linq;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class ClassificacaoRepository : Repository<Classificacao>, IClassificacaoRepository
    {
        public ClassificacaoRepository(VoteMelhorContext context)
            : base(context)
        {

        }

        public Classificacao VerifyExist(Classificacao classificacao)
        {
            return DbSet.FirstOrDefault(x => 
            x.PoliticoId == classificacao.PoliticoId && 
            x.UsuarioId == classificacao.UsuarioId && 
            x.Rate == classificacao.Rate);
        }
    }
}
