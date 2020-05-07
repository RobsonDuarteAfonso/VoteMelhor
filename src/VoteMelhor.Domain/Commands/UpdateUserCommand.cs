using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.Domain.Interfaces.Commands;
using VoteMelhor.Domain.ValueObjects;

namespace VoteMelhor.Domain.Commands
{
    public class UpdateUserCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Password Password { get; set; }
        public StateEnum State { get; set; }

        public UpdateUserCommand()
        {
            
        }

        public UpdateUserCommand(Guid id, string name, string email, string password, StateEnum state)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = new Password(password);
            State = state;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(Id, "Id", "Id é inválido.")
                    .HasMinLen(Name, 3, "Name", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Name, 100, "Name", "Não pode ter mais do que 20 caracteres.")
                    .IsEmailOrEmpty(Email, "Email", "Email é inválido.")
                    .IsEmail(Email, "Email", "Email é inválido.")
                    .HasMaxLen(Email, 100, "Email", "Não pode ter mais do que 100 caracteres.")
                    .HasMinLen(Password.Code, 6, "Password", "É necessário ao menos 6 caracteres.")
                    .HasMaxLen(Password.Code, 20, "Password", "Não pode ter mais do que 20 caracteres.")
                    .IsNotNull(State, "State", "Estado é inválido")
            );
        }
    }
}