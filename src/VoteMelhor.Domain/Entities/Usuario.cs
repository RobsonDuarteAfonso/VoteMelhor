using System.Collections.Generic;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.Domain.ValueObjects;

namespace VoteMelhor.Domain.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public Senha Senha { get; private set; }
        public StatusUsuarioEnum StatusUsuario { get; private set; }
        public CodigoConfirmacao CodigoConfirmacao { get; private set; }
        public PerfilEnum Perfil { get; private set; }
        public EstadoEnum Estado { get; private set; }
        public virtual ICollection<Classificacao> Classificacoes { get; private set; }


        public Usuario(string nome, string email, string senha, EstadoEnum estado)
        {
            Nome = nome;
            Email = email;
            Senha = new Senha(senha);
            Perfil = PerfilEnum.USR;
            StatusUsuario = StatusUsuarioEnum.CAD;
            CodigoConfirmacao = new CodigoConfirmacao();
            Estado = estado;
        }


        // [JsonConstructor]
/*         public Usuario(Guid id, string nome, string email, string senha, int status, CodigoConfirmacao codigoConfirmacao, PerfilEnum perfil, ICollection<Classificacao> classificacoes)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Perfil = perfil;
            StatusUsuario = StatusUsuarioEnum.CAD;
            Classificacoes = classificacoes;
            CodigoConfirmacao = codigoConfirmacao;            
        } */

        // Empty constructor for EF
        protected Usuario()
        {

        }        
        
        public void SetPerfil(PerfilEnum perfil)
        {
            Perfil = perfil;
        }

        public void SetStatus(StatusUsuarioEnum status)
        {
            StatusUsuario = status;
        }

        public CodigoConfirmacao GerarNovoCodigo()
        {
            return new CodigoConfirmacao();
        }

        public void SetNome(string nome)
        {
            Nome = nome;
        }

        public void SetEstado(EstadoEnum estado)
        {
            Estado = estado;
        }
    }
}
