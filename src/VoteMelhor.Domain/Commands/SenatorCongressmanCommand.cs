using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands
{
    public class SenatorCongressmanCommand : Notifiable, ICommand
    {
        public Political Political { get; set; }
        public Position Position { get; set; }
        public string PartyInitials { get; set; }

        public SenatorCongressmanCommand()
        {
            
        }

        public SenatorCongressmanCommand(Political political, Position position, string partyInitials)
        {
            Political = political;
            Position = position;
            PartyInitials = partyInitials;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Political.Name, 3, "Political.Name", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Political.Name, 100, "Political.Name", "Não pode ter mais do que 100 caracteres.")
                    .HasMinLen(Political.FullName, 3, "Political.FullName", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Political.FullName, 100, "Political.FullName", "Não pode ter mais do que 100 caracteres.")
                    .IsNotNull(Political.State, "Political.State", "Estado é inválido")
                    .HasMinLen(Political.Image, 6, "Political.Image", "É necessário ao menos 6 caracteres.")
                    .HasMaxLen(Political.Image, 100, "Political.Image", "Não pode ter mais do que 100 caracteres.")
                    .HasMinLen(Position.Name, 3, "Position.Name", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Position.Name, 100, "Position.Name", "Não pode ter mais do que 100 caracteres.")
                    .IsNotEmpty(Position.PoliticalId, "Position.PoliticalId", "Político é inválido.")  
                    .HasMinLen(PartyInitials, 2, "PartyInitials", "É necessário ao menos 2 caracteres.")
                    .HasMaxLen(PartyInitials, 50, "PartyInitials", "Não pode ter mais do que 50 caracteres.")                  
            );            
        }
    }
}