using System;
using Flunt.Notifications;
using VoteMelhor.Domain.Commands;
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
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Erro nas informações do Position.", command.Notifications);
            }

            var position = new Position(command.Name, 1, command.PoliticalId);
            var positionChecked = _repository.VerifyExist(position);
            
            try
            {
                if (positionChecked != null)
                {
                    return new CommandResult(false, "Position já existe.", command);
                }

                _repository.Add(position);
                return new CommandResult(true, "Position adicionado com sucesso.", position);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", position);
            }
        }

        public ICommandResult Handle(UpdatePositionCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Erro nas informações do Position.", command.Notifications);
            }

            var position = _repository.GetById(command.Id);

            try
            {
                if (position == null)
                {
                    return new CommandResult(false, "Você está tentando alterar um Position que não existe.", command);

                }

                _repository.UpdateCurrent(command.Id, command.PoliticalId);
                _repository.Add(position);
                return new CommandResult(true, "Position adicionado com sucesso.", position);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", position);
            }
        }
    }
}