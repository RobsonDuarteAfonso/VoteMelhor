using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.Domain.ValueObjects;

namespace VoteMelhor.Domain.Commands.Creates
{
    public class CreateUserCommand : Notifiable, ICommand
    {        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public StateEnum State { get; set; }
        
        public CreateUserCommand()
        {
            
        }

        public CreateUserCommand(string name, string email, string password, StateEnum state)
        {
            Name = name;
            Email = email;
            Password = password;
            State = state;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 3, "Name", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Name, 100, "Name", "Não pode ter mais do que 20 caracteres.")
                    .IsEmailOrEmpty(Email, "Email", "Email é inválido.")
                    .IsEmail(Email, "Email", "Email é inválido.")
                    .HasMaxLen(Email, 100, "Email", "Não pode ter mais do que 100 caracteres.")
                    .HasMinLen(Password, 6, "Password", "É necessário ao menos 6 caracteres.")
                    .HasMaxLen(Password, 20, "Password", "Não pode ter mais do que 20 caracteres.")
                    .IsNotNull(State, "State", "Estado é inválido")
            );
        }
    }
}