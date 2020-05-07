using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Commands
{
    public class CreateLawSuitCommand : Notifiable, ICommand
    {        
        public string Summary { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public SituationEnum Situation { get; set; }
        public int PoliticalId { get; set; }
        
        public CreateLawSuitCommand()
        {
            
        }

        public CreateLawSuitCommand(string summary, string description, DateTime publicationDate, SituationEnum situation, int politicalId)
        {
            Summary = summary;
            Description = description;
            PublicationDate = publicationDate;
            Situation = situation;
            PoliticalId = politicalId;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Summary, 6, "Summary", "É necessário ao menos 6 caracteres.")
                    .HasMaxLen(Summary, 200, "Summary", "Não pode ter mais do que 200 caracteres.")
                    .HasMinLen(Description, 6, "Description", "É necessário ao menos 6 caracteres.")
                    .HasMaxLen(Description, 2000, "Description", "Não pode ter mais do que 2000 caracteres.")
                    .IsLowerOrEqualsThan(PublicationDate, DateTime.Now, "PublicationDate","Data tem que se menor ou igual a data de hoje.")
                    .IsNullOrNullable(PublicationDate, "PublicationDate", "Data é inválida.")
                    .IsNotNull(Situation, "Situation", "Situação é inválido")
                    .IsNullOrNullable(PoliticalId, "PoliticalId", "Político é inválido.")
                    .IsGreaterThan(PoliticalId, 0, "PoliticalId", "Político é inválido.")
            );
        }
    }
}        