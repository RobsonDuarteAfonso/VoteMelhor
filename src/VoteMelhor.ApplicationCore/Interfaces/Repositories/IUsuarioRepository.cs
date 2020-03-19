using VoteMelhor.ApplicationCore.Entities;

namespace VoteMelhor.ApplicationCore.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        public Usuario AutenticarUsuario(Usuario usuario);

    }
}
