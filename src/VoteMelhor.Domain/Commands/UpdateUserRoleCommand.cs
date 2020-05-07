using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands
{
    public class UpdateUserRoleCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public RoleEnum Role { get; set; }

        public UpdateUserRoleCommand()
        {
            
        }

        public UpdateUserRoleCommand(Guid id, string email, RoleEnum role)
        {
            Id = id;
            Email = email;
            Role = role;
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
                    .IsNotNull(Role, "Role", "Perfil é inválido")            
            );
        }
    }
}