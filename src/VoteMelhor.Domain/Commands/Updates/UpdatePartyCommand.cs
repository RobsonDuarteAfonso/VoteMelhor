using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands.Updates
{
    public class UpdatePartyCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public int Number { get; set; }
        public string Image { get; set; }

        public UpdatePartyCommand()
        {
            
        }

        public UpdatePartyCommand(Guid id, string name, string initials, int number, string image)
        {
            Id = id;
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
                    .IsNotEmpty(Id, "Id", "Id é inválido.")
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