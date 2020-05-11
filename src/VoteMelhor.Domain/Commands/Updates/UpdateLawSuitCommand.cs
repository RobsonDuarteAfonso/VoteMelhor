using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands.Updates
{
    public class UpdateLawSuitCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public SituationEnum Situation { get; set; }
        public int PoliticalId { get; set; }

        public UpdateLawSuitCommand()
        {
            
        }

        public UpdateLawSuitCommand(Guid id, string summary, string description, SituationEnum situation, int politicalId)
        {
            Id = id;
            Summary = summary;
            Description = description;
            Situation = situation;
            PoliticalId = politicalId;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(Id, "Id", "Id é inválido.")
                    .HasMinLen(Summary, 3, "Summary", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Summary, 200, "Summary", "Não pode ter mais do que 200 caracteres.")
                    .HasMinLen(Description, 3, "Description", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Description, 2000, "Description", "Não pode ter mais do que 2000 caracteres.")
                    .IsNotNull(Situation, "Situation", "Situação é inválido")
                    .IsNullOrNullable(PoliticalId, "PoliticalId", "Político é inválido.")
                    .IsGreaterThan(PoliticalId, 0, "PoliticalId", "Político é inválido.")
            );
        }
    }
}