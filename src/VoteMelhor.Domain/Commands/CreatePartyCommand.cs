using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands
{
    public class CreatePartyCommand : Notifiable, ICommand
    {
        public string Name { get; set; }
        public string Initials { get; set; }
        public int Number { get; set; }
        public string Image { get; set; }

        public CreatePartyCommand()
        {
            
        }

        public CreatePartyCommand(string name, string initials, int number, string image)
        {
            Name = name;
            Initials = initials;
            Number = number;
            Image = image;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 3, "Name", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Name, 100, "Name", "Não pode ter mais do que 100 caracteres.")
                    .HasMinLen(Initials, 2, "Initials", "É necessário ao menos 2 caracteres.")
                    .HasMaxLen(Initials, 50, "Initials", "Não pode ter mais do que 50 caracteres.")
                    .IsNullOrNullable(Number, "Number", "Político é inválido.")
                    .IsGreaterThan(Number, 0, "Number", "Político é inválido.")
                    .HasMinLen(Image, 6, "Image", "É necessário ao menos 6 caracteres.")
                    .HasMaxLen(Image, 100, "Image", "Não pode ter mais do que 100 caracteres.")
            );
        }
    }
}