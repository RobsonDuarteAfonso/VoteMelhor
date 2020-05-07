using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.Domain.ValueObjects;

namespace VoteMelhor.Domain.Commands
{
    public class CreateUsuarioCommand : Notifiable, ICommand
    {        
        public string Nome { get; set; }
        public string Email { get; set; }
        public Senha Senha { get; set; }
        public EstadoEnum Estado { get; set; }
        
        public CreateUsuarioCommand()
        {
            
        }

        public CreateUsuarioCommand(string nome, string email, string senha, EstadoEnum estado)
        {
            Nome = nome;
            Email = email;
            Senha = new Senha(senha);
            Estado = estado;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Nome, 3, "Nome", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Nome, 100, "Nome", "Não pode ter mais do que 20 caracteres.")
                    .IsEmailOrEmpty(Email, "Email", "Email é inválido.")
                    .IsEmail(Email, "Email", "Email é inválido.")
                    .HasMaxLen(Email, 100, "Email", "Não pode ter mais do que 100 caracteres.")
                    .HasMinLen(Senha.Codigo, 6, "Senha", "É necessário ao menos 6 caracteres.")
                    .HasMaxLen(Senha.Codigo, 20, "Senha", "Não pode ter mais do que 20 caracteres.")
                    .IsNotNull(Estado, "Estado", "Estado é inválido")
            );
        }
    }
}