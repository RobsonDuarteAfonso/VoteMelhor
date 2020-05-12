using System;
using Flunt.Notifications;
using VoteMelhor.Domain.Commands;
using VoteMelhor.Domain.Commands.Creates;
using VoteMelhor.Domain.Commands.Updates;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Commands;
using VoteMelhor.Domain.Interfaces.Handlers;
using VoteMelhor.Domain.Interfaces.Repositories;

namespace VoteMelhor.Domain.Handlers
{
    public class ProposalHandler :
        Notifiable,
        IHandler<CreateProposalCommand>,
        IHandler<UpdateProposalCommand>
    {
        private readonly IProposalRepository _repository;

        public ProposalHandler(IProposalRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateProposalCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Erro nas informações do Proposta.", command.Notifications);
            }

            var proposal = new Proposal(command.House, command.ProposalType, command.Numeration, command.Summary, command.Description, command.ProposalDate);
            var proposalChecked = _repository.VerifyExist(proposal);
            
            try
            {
                if (proposalChecked != null)
                {
                    return new CommandResult(false, "Proposta já existe.", command);
                }

                _repository.Add(proposal);
                return new CommandResult(true, "Proposta adicionado com sucesso.", proposal);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", proposal);
            }
        }

        public ICommandResult Handle(UpdateProposalCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Erro nas informações do Proposta.", command.Notifications);
            }

            var newProposal = new Proposal(command.House, command.ProposalType, command.Number, command.Summary, command.Description, command.ProposalDate);
            var proposal = _repository.VerifyExist(newProposal);

            try
            {
                if (proposal == null)
                {
                    return new CommandResult(false, "Você está tentando alterar um Proposta que não existe.", command);
                }

                proposal.SetHouse(command.House);
                proposal.SetNumeration(command.Number);
                proposal.SetSummary(command.Summary);
                proposal.SetDescription(command.Description);
                proposal.SetProposalType(command.ProposalType);
                proposal.SetProposalDate(command.ProposalDate);

                _repository.Update(proposal);
                return new CommandResult(true, "Proposta alterado com sucesso.", proposal);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", proposal);
            }
        }
    }
}