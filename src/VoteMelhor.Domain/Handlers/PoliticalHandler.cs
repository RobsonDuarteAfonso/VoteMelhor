using System;
using Flunt.Notifications;
using VoteMelhor.Domain.Commands;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Commands;
using VoteMelhor.Domain.Interfaces.Handlers;
using VoteMelhor.Domain.Interfaces.Repositories;

namespace VoteMelhor.Domain.Handlers
{
    public class PoliticalHandler :
        Notifiable,
        IHandler<CreatePoliticalCommand>,
        IHandler<UpdatePoliticalCommand>
    {
        private readonly IPoliticalRepository _repository;

        public PoliticalHandler(IPoliticalRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreatePoliticalCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Erro nas informações do Político.", command.Notifications);
            }

            var political = new Political(command.Id, command.Name, command.State, command.Image);
            var politicalChecked = _repository.VerifyExist(political);
            
            try
            {
                if (politicalChecked != null)
                {
                    return new CommandResult(false, "Político já existe.", command);
                }

                _repository.Add(political);
                return new CommandResult(true, "Político adicionado com sucesso.", political);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", political);
            }
        }

        public ICommandResult Handle(UpdatePoliticalCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Erro nas informações do Político.", command.Notifications);
            }

            var newPolitical = new Political(command.Id, command.Name, command.State, command.Image);
            var political = _repository.VerifyExist(newPolitical);

            try
            {
                if (political == null)
                {
                    return new CommandResult(false, "Você está tentando alterar um Político que não existe.", command);
                }

                political.SetName(command.Name);
                political.SetState(command.State);
                political.SetImage(command.Image);

                _repository.Update(political);
                return new CommandResult(true, "Político adicionado com sucesso.", political);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", political);
            }
        }
    }
}