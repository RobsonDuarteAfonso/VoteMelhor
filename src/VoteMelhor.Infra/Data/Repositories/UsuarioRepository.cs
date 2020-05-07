using System.Linq;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Repositories;

namespace VoteMelhor.Infra.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(VoteMelhorContext context)
            : base(context)
        {

        }

        public Usuario AutenticarUsuario(Usuario usuario)
        {
/*             var user = (from x in Db.Usuarios
                        where x.Email == usuario.Email && x.Senha == usuario.Senha
                        select new Usuario(x.Id, x.Nome, x.Email, x.Status, x.Perfil, x.Classificacoes)).SingleOrDefault(); */
            var user = Db.Usuarios.FirstOrDefault(x => x.Email == usuario.Email && x.Senha == usuario.Senha);
            user.Senha.SetSenhaNull();

            return user;
        }

        public bool VerificarUsuarioExiste(Usuario usuario)
        {
            var user = Db.Usuarios.FirstOrDefault(x => x.Email == usuario.Email);

            if (user == null)
            {
                return false;
            }

            return true;
        }


    }
}
