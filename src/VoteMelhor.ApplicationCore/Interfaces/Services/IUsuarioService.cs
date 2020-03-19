using VoteMelhor.ApplicationCore.Entities;

namespace VoteMelhor.ApplicationCore.Interfaces.Services
{
    public interface IUsuarioService : IService<Usuario>
    {
        public Usuario AutenticarUsuario(Usuario usuario);
    }
}
