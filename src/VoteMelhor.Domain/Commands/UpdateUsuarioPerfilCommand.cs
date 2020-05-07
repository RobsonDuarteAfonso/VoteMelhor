using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands
{
    public class UpdateUsuarioPerfilCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }

        public UpdateUsuarioPerfilCommand()
        {
            
        }

        public UpdateUsuarioPerfilCommand(Guid id, string email, PerfilEnum perfil)
        {
            Id = id;
            Email = email;
            Perfil = perfil;
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
                    .IsNotNull(Perfil, "Perfil", "Perfil é inválido")            
            );
        }
    }
}