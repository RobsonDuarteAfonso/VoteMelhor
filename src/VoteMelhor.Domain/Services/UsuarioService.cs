using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;
using VoteMelhor.Domain.Interfaces.Services;

namespace VoteMelhor.Domain.Services
{
    public class UsuarioService : Service<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario AutenticarUsuario(Usuario usuario)
        {
            return _usuarioRepository.AutenticarUsuario(usuario);
        }
    }
}
