using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Services
{
    public interface IUsuarioService : IService<Usuario>
    {
        public Usuario AutenticarUsuario(Usuario usuario);
    }
}
