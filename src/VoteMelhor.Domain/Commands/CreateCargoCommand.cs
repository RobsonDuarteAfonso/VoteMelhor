using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands
{
    public class CreateCargoCommand : Notifiable, ICommand
    {
        public string Nome { get; set; }
        public int PoliticoId { get; set; }

        public CreateCargoCommand()
        {
            
        }

        public CreateCargoCommand(string nome, int politicoId)
        {
            Nome = nome;
            PoliticoId = politicoId;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Nome, 3, "Nome", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Nome, 100, "Nome", "Não pode ter mais do que 100 caracteres.")
                    .IsNullOrNullable(PoliticoId, "PoliticoId", "Político é inválido.")
                    .IsGreaterThan(PoliticoId, 0, "PoliticoId", "Político é inválido.")
            );
        }
    }
}