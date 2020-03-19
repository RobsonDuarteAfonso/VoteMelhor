using System.Linq;
using VoteMelhor.ApplicationCore.Entities;
using VoteMelhor.ApplicationCore.Interfaces.Repositories;

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
            //var user = Db.Usuarios.Where(u => u.Email == usuario.Email && u.Senha == usuario.Senha).FirstOrDefault();
            var user = (from x in Db.Usuarios
                        where x.Email == usuario.Email && x.Senha == usuario.Senha
                        select new Usuario(x.Id, x.Nome, x.Email, x.Perfil, x.Classificacoes)).SingleOrDefault();
            //where u.Email == usuario.Email && u.Senha == usuario.Senha
            //select new Usuario(u.Id, u.Nome, u.Email, null, null, u.Perfil, u.Classificacoes)).FirstOrDefault();

            return user;
        }
    }
}
