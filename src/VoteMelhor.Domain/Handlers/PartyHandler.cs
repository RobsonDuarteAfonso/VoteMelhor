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
    public class PartyHandler :
        Notifiable,
        IHandler<CreatePartyCommand>,
        IHandler<UpdatePartyCommand>
    {
        private readonly IPartyRepository _repository;

        public PartyHandler(IPartyRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreatePartyCommand command)
        {
            try
            {
                command.Validate();

                if (command.Invalid)
                {
                    return new CommandResult(false, "Erro nas informações do partido.", command.Notifications);
                }

                var party = new Party(command.Name, command.Initials, command.Number, command.Image);

                var partyChecked = _repository.VerifyExist(party.Initials);


                if (partyChecked != null)
                {
                    return new CommandResult(false, "Já existe o partido.", partyChecked);
                }

                _repository.Add(party);

                return new CommandResult(true, "Partido adicionado com sucesso.", party);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", command);
            }
        }

        public ICommandResult Handle(UpdatePartyCommand command)
        {
            try
            {
                command.Validate();

                if (command.Invalid)
                {
                    return new CommandResult(false, "Erro nas informações da partido.", command.Notifications);
                }

                var party = _repository.VerifyExist(command.Initials);
                
                if (party == null)
                {
                    return new CommandResult(false, "Você está tentando alterar partido que não existe.", command);
                }

                party.SetName(command.Name);
                party.SetInitials(command.Initials);
                party.SetNumber(command.Number);
                party.SetImage(command.Image);


                _repository.Update(party);

                return new CommandResult(true, "Partido alterado com sucesso.", party);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", command);
            }
        }
    }
}