using System;
using Flunt.Notifications;
using VoteMelhor.Domain.Commands;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Commands;
using VoteMelhor.Domain.Interfaces.Handlers;
using VoteMelhor.Domain.Interfaces.Repositories;

namespace VoteMelhor.Domain.Handlers
{
    public class LawSuitHandler :
        Notifiable,
        IHandler<CreateLawSuitCommand>,
        IHandler<UpdateLawSuitCommand>
    {
        private readonly ILawSuitRepository _repository;

        public LawSuitHandler(ILawSuitRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateLawSuitCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Erro nas informações do processo.", command.Notifications);
            }

            var lawSuit = new LawSuit(command.Summary, command.Description, command.Situation, command.PoliticalId);

            lawSuit.SetPublicationDate();
            
            try
            {
                _repository.Add(lawSuit);
                return new CommandResult(true, "Processo adicionado com sucesso.", lawSuit);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", lawSuit);
            }
        }

        public ICommandResult Handle(UpdateLawSuitCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Erro nas informações do processo.", command.Notifications);
            }

            var lawSuit = _repository.GetById(command.Id);
                
            if (lawSuit == null)
            {
                return new CommandResult(false, "Você está tentando alterar um processo que não existe.", command);
            }

            lawSuit.SetSummary(command.Summary);
            lawSuit.SetDescription(command.Description);
            lawSuit.SetSituation(command.Situation);
            lawSuit.SetUpdateDate();
            

            try
            {
                _repository.Update(lawSuit);
                return new CommandResult(true, "Processo adicionado com sucesso.", lawSuit);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", lawSuit);
            }
        }
    }
}