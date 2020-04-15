using FluentValidation;
using VoteMelhor.ApplicationCore.Entities;

namespace VoteMelhor.WebApi.Validations
{
    public class CreateUsuarioValidation : AbstractValidator<Usuario>
    {
        public CreateUsuarioValidation()
        {
            RuleFor(u => u.Nome)
                .NotNull()
                .Length(3, 100).WithMessage("NOME deve ter no mínimo 3 e no máximo 100 caracteres.");

            RuleFor(u => u.Email)
                .NotNull()
                .MaximumLength(50).WithMessage("EMAIL deve ter no máximo 50 caracteres.")
                .EmailAddress();

            RuleFor(u => u.Senha)
                .NotNull()
                .Length(6, 12).WithMessage("SENHA deve ter no mínimo 6 e no máximo 12 caracteres.");

            RuleFor(u => u.Perfil.ToString())
                .NotNull()
                .Length(3).WithMessage("PERFIL deve ter 3 caracteres.");

            RuleFor(u => u.CodigoConfirmacao)
                .NotNull()
                .Length(70).WithMessage("CÓDIGO DE CONFIRMAÇÃO com formato inválido.");

        }
    }
}
