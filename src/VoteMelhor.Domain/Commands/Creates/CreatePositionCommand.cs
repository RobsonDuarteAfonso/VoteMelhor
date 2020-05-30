using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands.Creates
{
    public class CreatePositionCommand : Notifiable, ICommand
    {
        public string Name { get; set; }
        public Guid PoliticalId { get; set; }

        public CreatePositionCommand()
        {
            
        }

        public CreatePositionCommand(string name, Guid politicalId)
        {
            Name = name;
            PoliticalId = politicalId;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 3, "Name", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Name, 100, "Name", "Não pode ter mais do que 100 caracteres.")
                    .IsNotEmpty(PoliticalId, "PoliticalId", "Político é inválido.")
            );
        }
    }
}