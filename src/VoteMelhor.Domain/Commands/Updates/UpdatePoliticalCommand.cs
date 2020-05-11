using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands.Updates
{
    public class UpdatePoliticalCommand : Notifiable, ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StateEnum State { get; set; }
        public string Image { get; set; }

        public UpdatePoliticalCommand()
        {
            
        }

        public UpdatePoliticalCommand(int id, string name, StateEnum state, string image)
        {
            Id = id;
            Name = name;
            State = state;
            Image = image;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNullOrNullable(Id, "Id", "Político é inválido.")
                    .IsGreaterThan(Id, 0, "Id", "Político é inválido.")
                    .HasMinLen(Name, 3, "Name", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Name, 100, "Name", "Não pode ter mais do que 100 caracteres.")
                    .IsNotNull(State, "State", "Estado é inválido")
                    .HasMinLen(Image, 6, "Image", "É necessário ao menos 6 caracteres.")
                    .HasMaxLen(Image, 100, "Image", "Não pode ter mais do que 100 caracteres.")
            );
        }
    }
}