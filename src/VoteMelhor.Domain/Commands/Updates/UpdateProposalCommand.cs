using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.Domain.Interfaces.Commands;

namespace VoteMelhor.Domain.Commands.Updates
{
    public class UpdateProposalCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public HouseEnum House { get; set; }
        public ProposalTypeEnum ProposalType { get; set; }
        public string Number { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public DateTime ProposalDate { get; set; }  

        public UpdateProposalCommand()
        {
            
        }

        public UpdateProposalCommand(Guid id, HouseEnum house, ProposalTypeEnum proposalType, string number, string summary, string description, DateTime proposalDate)
        {
            Id = id;
            House = house;
            ProposalType = proposalType;
            Number = number;
            Summary = summary;
            Description = description;
            ProposalDate = proposalDate;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotEmpty(Id, "Id", "Id é inválido.")
                    .IsNotNull(House, "House", "Casa Legislativa é inválido")
                    .IsNotNull(ProposalType, "ProposalType", "Tipo de Proposta é inválido")                                        
                    .HasMinLen(Summary, 3, "Summary", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Summary, 200, "Summary", "Não pode ter mais do que 200 caracteres.")
                    .HasMinLen(Description, 3, "Description", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Description, 2000, "Description", "Não pode ter mais do que 2000 caracteres.")
            );
        }
    }
}