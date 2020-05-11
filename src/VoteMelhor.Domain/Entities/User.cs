using System.Collections.Generic;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.Domain.ValueObjects;

namespace VoteMelhor.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Password Password { get; private set; }
        public UserStatusEnum UserStatus { get; private set; }
        public ConfirmationCode ConfirmationCode { get; private set; }
        public RoleEnum Role { get; private set; }
        public StateEnum State { get; private set; }
        public virtual ICollection<Rating> Ratings { get; private set; }

        public User(string name, string email, string password, StateEnum state)
        {
            Name = name;
            Email = email;
            Password = new Password(password);
            ConfirmationCode = new ConfirmationCode();
            State = state;
        }

        public User(string email, string password)
        {
            Email = email;
            Password = new Password(password);
        }
        
        public User(string email, RoleEnum role)
        {
            Email = email;
            Role = role;
        }

        public User(string email, UserStatusEnum userStatus)
        {
            Email = email;
            UserStatus = userStatus;
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
        protected User()
        {

        }        
        
        public void SetRole(RoleEnum role)
        {
            Role = role;
        }

        public void SetUserStatus(UserStatusEnum userStatus)
        {
            UserStatus = userStatus;
        }

        public ConfirmationCode CreateNewCode()
        {
            return new ConfirmationCode();
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetState(StateEnum state)
        {
            State = state;
        }
    }
}
