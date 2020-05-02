using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;
using VoteMelhor.Domain.Interfaces.Services;

namespace VoteMelhor.Domain.Services
{
    public class ClassificacaoService : Service<Classificacao>, IClassificacaoService
    {
        private readonly IClassificacaoRepository _classificacaoRepository;

        public ClassificacaoService(IClassificacaoRepository classificacaoRepository) : base(classificacaoRepository)
        {
            _classificacaoRepository = classificacaoRepository;
        }
    }
}
