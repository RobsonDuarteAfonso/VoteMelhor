using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands
{
    public class UpdatePoliticoCommand : Notifiable, ICommand
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public EstadoEnum Estado { get; set; }
        public string Imagem { get; set; }

        public UpdatePoliticoCommand()
        {
            
        }

        public UpdatePoliticoCommand(int id, string nome, EstadoEnum estado, string imagem)
        {
            Id = id;
            Nome = nome;
            Estado = estado;
            Imagem = imagem;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNullOrNullable(Id, "Id", "Político é inválido.")
                    .IsGreaterThan(Id, 0, "Id", "Político é inválido.")
                    .HasMinLen(Nome, 3, "Nome", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Nome, 100, "Nome", "Não pode ter mais do que 100 caracteres.")
                    .IsNotNull(Estado, "Estado", "Estado é inválido")
                    .HasMinLen(Imagem, 6, "Imagem", "É necessário ao menos 6 caracteres.")
                    .HasMaxLen(Imagem, 100, "Imagem", "Não pode ter mais do que 100 caracteres.")
            );
        }
    }
}