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
    public class PoliticalPartyHandler :
        Notifiable,
        IHandler<CreatePoliticalPartyCommand>,
        IHandler<UpdatePoliticalPartyCommand>
    {
        private readonly IPoliticalPartyRepository _repository;

        public PoliticalPartyHandler(IPoliticalPartyRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreatePoliticalPartyCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Erro nas informações do partido político.", command.Notifications);
            }

            var politicalParty = new PoliticalParty(command.Current, command.PoliticalId, command.PartyId);
            var politicalPartyChecked = _repository.VerifyExist(politicalParty);
            
            try
            {
                if (politicalPartyChecked != null)
                {
                    return new CommandResult(false, "Partido Político já existe.", command);
                }

                _repository.Add(politicalParty);
                return new CommandResult(true, "Partido Político adicionado com sucesso.", politicalParty);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", politicalParty);
            }
        }

        public ICommandResult Handle(UpdatePoliticalPartyCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Erro nas informações do partido político.", command.Notifications);
            }

            var newPoliticalParty = new PoliticalParty(command.Current, command.PoliticalId, command.PartyId);
            var politicalParty = _repository.VerifyExist(newPoliticalParty);

            try
            {
                if (politicalParty == null)
                {
                    return new CommandResult(false, "Você está tentando alterar um partido político que não existe.", command);
                }

                _repository.UpdateCurrent(politicalParty);
                return new CommandResult(true, "Partido Político adicionado com sucesso.", politicalParty);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", politicalParty);
            }
        }
    }
}