using VoteMelhor.Domain.Entities;

namespace VoteMelhor.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        public Usuario AutenticarUsuario(Usuario usuario);

    }
}
