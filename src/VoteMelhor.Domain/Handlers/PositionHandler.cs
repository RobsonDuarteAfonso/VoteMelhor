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
    public class PositionHandler :
        Notifiable,
        IHandler<CreatePositionCommand>,
        IHandler<UpdatePositionCommand>
    {
        private readonly IPositionRepository _repository;

        public PositionHandler(IPositionRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreatePositionCommand command)
        {
            try
            {
                command.Validate();

                if (command.Invalid)
                {
                    return new CommandResult(false, "Erro nas informações do posição.", command.Notifications);
                }

                var position = new Position(command.Name, true, command.Participation, command.PoliticalId);

                var positionChecked = _repository.VerifyExist(position.PoliticalId, position.Name, position.Participation);


                if (positionChecked != null)
                {
                    return new CommandResult(false, "Posição já existe.", command);
                }

                _repository.Add(position);

                return new CommandResult(true, "Posição adicionado com sucesso.", position);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", command);
            }
        }

        public ICommandResult Handle(UpdatePositionCommand command)
        {
            try
            {
                command.Validate();

                if (command.Invalid)
                {
                    return new CommandResult(false, "Erro nas informações do posição.", command.Notifications);
                }

                var position = _repository.GetById(command.Id);


                if (position == null)
                {
                    return new CommandResult(false, "Você está tentando alterar uma posição que não existe.", command);
                }

                _repository.UpdateCurrent(command.Id, command.PoliticalId);

                return new CommandResult(true, "Posição alterado com sucesso.", position);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", command);
            }
        }
    }
}