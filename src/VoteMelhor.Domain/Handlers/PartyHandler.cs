using System;
using Flunt.Notifications;
using VoteMelhor.Domain.Commands;
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
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Erro nas informações da party.", command.Notifications);
            }

            var party = new Party(command.Name, command.Initials, command.Number, command.Image);
            var partyChecked = _repository.VerifyExist(party);
            
            try
            {
                if (partyChecked != null)
                {
                    return new CommandResult(false, "Já existe uma party.", partyChecked);
                }

                _repository.Add(partyChecked);
                return new CommandResult(true, "Party adicionado com sucesso.", partyChecked);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", partyChecked);
            }
        }

        public ICommandResult Handle(UpdatePartyCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Erro nas informações da classificação.", command.Notifications);
            }

            var party = _repository.GetById(command.Id);
                
            if (party == null)
            {
                return new CommandResult(false, "Você está tentando alterar classificação que não existe.", command);
            }

            party.SetName(command.Name);
            party.SetInitials(command.Initials);
            party.SetNumber(command.Number);
            party.SetImage(command.Image);

            try
            {
                _repository.Update(party);
                return new CommandResult(true, "Classificação adicionada com sucesso.", party);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", party);
            }
        }
    }
}