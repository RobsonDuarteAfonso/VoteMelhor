using VoteMelhor.ApplicationCore.Entities;
using VoteMelhor.ApplicationCore.Interfaces.Repositories;
using VoteMelhor.ApplicationCore.Interfaces.Services;

namespace VoteMelhor.ApplicationCore.Services
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
