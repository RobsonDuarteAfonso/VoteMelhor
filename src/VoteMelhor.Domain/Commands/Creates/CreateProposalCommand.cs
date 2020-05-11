using System;
using Flunt.Notifications;
using Flunt.Validations;
using VoteMelhor.Domain.Interfaces.Commands;
using VoteMelhor.Domain.Enumations;

namespace VoteMelhor.Domain.Commands.Creates
{
    public class CreateProposalCommand : Notifiable, ICommand
    {        
        public HouseEnum House { get; set; }
        public ProposalTypeEnum ProposalType { get; set; }
        public string Numeration { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public DateTime ProposalDate { get; set; }    
        
        public CreateProposalCommand()
        {
            
        }

        public CreateProposalCommand(HouseEnum house, ProposalTypeEnum proposalType, string numeration, string summary, string description, DateTime proposalDate)
        {
            House = house;
            ProposalType = proposalType;
            Numeration = numeration;
            Summary = summary;
            Description = description;
            ProposalDate = proposalDate;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(House, "House", "Casa legislativa é inválido")
                    .IsNotNull(ProposalType, "ProposalType", "Tipo de proposta é inválido")
                    .HasMinLen(Numeration, 3, "Numeration", "É necessário ao menos 3 caracteres.")
                    .HasMaxLen(Numeration, 20, "Numeration", "Não pode ter mais do que 20 caracteres.")
                    .HasMinLen(Summary, 6, "Summary", "É necessário ao menos 6 caracteres.")
                    .HasMaxLen(Summary, 200, "Summary", "Não pode ter mais do que 200 caracteres.")
                    .HasMinLen(Description, 6, "Description", "É necessário ao menos 6 caracteres.")
                    .HasMaxLen(Description, 2000, "Description", "Não pode ter mais do que 2000 caracteres.")
                    .IsLowerOrEqualsThan(ProposalDate, DateTime.Now, "ProposalDate","Data tem que se menor ou igual a data de hoje.")
                    .IsNullOrNullable(ProposalDate, "ProposalDate", "Data da proposta é inválida.")
            );
        }
    }
}        