using System;
using VoteMelhor.ApplicationCore.Enumations;

namespace VoteMelhor.ApplicationCore.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string Senha { get; private set; }

        public string Facebook { get; private set; }

        public Perfil Perfil { get; private set; }

        public Usuario(Guid id, string nome, string email, string senha, string facebook, Perfil perfil)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Facebook = facebook;
            Perfil = perfil;
        }

        // Empty constructor for EF
        public Usuario()
        {

        }
    }
}
