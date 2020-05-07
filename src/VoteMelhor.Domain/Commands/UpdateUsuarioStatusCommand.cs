using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands
{
    public class UpdateUsuarioStatusCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public StatusUsuarioEnum StatusUsuario { get; set; }

        public UpdateUsuarioStatusCommand()
        {
            
        }

        public UpdateUsuarioStatusCommand(Guid id, string email, StatusUsuarioEnum statusUsuario)
        {
            Id = id;
            Email = email;
            StatusUsuario = statusUsuario;
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
                    .IsNotNull(StatusUsuario, "StatusUsuario", "Status do usuário é inválido")            
            );
        }
    }
}