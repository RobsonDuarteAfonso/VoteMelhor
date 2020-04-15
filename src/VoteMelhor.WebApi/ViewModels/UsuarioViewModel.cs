using System;
using System.Collections.Generic;
using VoteMelhor.ApplicationCore.Enumations;

namespace VoteMelhor.WebApi.ViewModels
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Facebook { get; set; }
        public int Status { get; set; }
        public string CodigoConfirmacao { get; set; }
        public Perfil Perfil { get; set; }
        public virtual ICollection<ClassificacaoViewModel> Classificacoes { get; set; }
    }
}
