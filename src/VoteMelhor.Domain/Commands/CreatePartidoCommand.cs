using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands
{
    public class CreatePartidoCommand : Notifiable, ICommand
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public int Numero { get; set; }
        public string Imagem { get; set; }

        public CreatePartidoCommand()
        {
            
        }

        public CreatePartidoCommand(string nome, string sigla, int numero, string imagem)
        {
            Nome = nome;
            Sigla = sigla;
            Numero = numero;
            Imagem = imagem;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Nome, 3, "Nome", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Nome, 100, "Nome", "Não pode ter mais do que 100 caracteres.")
                    .HasMinLen(Sigla, 2, "Sigla", "É necessário ao menos 2 caracteres.")
                    .HasMaxLen(Sigla, 50, "Sigla", "Não pode ter mais do que 50 caracteres.")
                    .IsNullOrNullable(Numero, "Numero", "Político é inválido.")
                    .IsGreaterThan(Numero, 0, "Numero", "Político é inválido.")
                    .HasMinLen(Imagem, 6, "Imagem", "É necessário ao menos 6 caracteres.")
                    .HasMaxLen(Imagem, 100, "Imagem", "Não pode ter mais do que 100 caracteres.")
            );
        }
    }
}