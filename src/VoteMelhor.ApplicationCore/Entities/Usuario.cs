using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VoteMelhor.ApplicationCore.Enumations;

namespace VoteMelhor.ApplicationCore.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Facebook { get; private set; }
        public int Status { get; private set; }
        public string CodigoConfirmacao { get; private set; }
        public Perfil Perfil { get; private set; }
        public virtual ICollection<Classificacao> Classificacoes { get; private set; }


        public Usuario(Guid id, string nome, string email, string senha, string facebook, int status, string codigoConfirmacao, Perfil perfil)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Facebook = facebook;
            Perfil = perfil;
            Status = status;
            CodigoConfirmacao = codigoConfirmacao;
        }


        [JsonConstructor]
        public Usuario(Guid id, string nome, string email, string senha, string facebook, int status, string codigoConfirmacao, Perfil perfil, ICollection<Classificacao> classificacoes)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Facebook = facebook;
            Perfil = perfil;
            Status = status;
            Classificacoes = classificacoes;
            if (Id == Guid.Empty)
            {
                CodigoConfirmacao = GerarCodigoConfirmacao(70);
            } 
            else
            {
                CodigoConfirmacao = codigoConfirmacao;
            }            
            
        }

        public Usuario(Guid id, string nome, string email, int status, Perfil perfil, ICollection<Classificacao> classificacoes)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Perfil = perfil;
            Classificacoes = classificacoes;
            Status = status;
        }

        // Empty constructor for EF
        protected Usuario()
        {

        }

        public static string GerarCodigoConfirmacao(int tamanho)
        {
            var chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}
