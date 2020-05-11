using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands.Updates
{
    public class UpdateUserStatusCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public UserStatusEnum UserStatus { get; set; }

        public UpdateUserStatusCommand()
        {
            
        }

        public UpdateUserStatusCommand(Guid id, string email, UserStatusEnum userStatus)
        {
            Id = id;
            Email = email;
            UserStatus = userStatus;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(Id, "Id", "Id é inválido.")
                    .IsEmailOrEmpty(Email, "Email", "Email é inválido.")
                    .IsEmail(Email, "Email", "Email é inválido.")
                    .HasMaxLen(Email, 100, "Email", "Não pode ter mais do que 100 caracteres.")
                    .IsNotNull(UserStatus, "StatusUser", "Status do usuário é inválido")            
            );
        }
    }
}