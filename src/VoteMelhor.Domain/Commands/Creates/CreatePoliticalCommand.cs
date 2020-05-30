using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Commands.Creates
{
    public class CreatePoliticalCommand : Notifiable, ICommand
    {        
        public int CongressmanId { get; set; }
        public int SenatorId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public StateEnum State { get; set; }
        public string Image { get; set; }
        
        public CreatePoliticalCommand()
        {
            
        }

        public CreatePoliticalCommand(int congressmanId, int senatorId, string name, string fullname, StateEnum state, string image)
        {
            CongressmanId = congressmanId;
            SenatorId = senatorId;
            Name = name;
            FullName = fullname;
            State = state;
            Image = image;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 3, "Name", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Name, 100, "Name", "Não pode ter mais do que 100 caracteres.")
                    .HasMinLen(FullName, 3, "FullName", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(FullName, 100, "FullName", "Não pode ter mais do que 100 caracteres.")
                    .IsNotNull(State, "State", "Estado é inválido")
                    .HasMinLen(Image, 6, "Image", "É necessário ao menos 6 caracteres.")
                    .HasMaxLen(Image, 100, "Image", "Não pode ter mais do que 100 caracteres.")
            );
        }
    }
}        