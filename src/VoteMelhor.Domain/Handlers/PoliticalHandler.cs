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
            try
            {
                command.Validate();

                if (command.Invalid)
                {
                    return new CommandResult(false, "Erro nas informações do Político.", command.Notifications);
                }

                var politicalCheckedId = _repository.VerifyExist(command.CongressmanId, command.SenatorId);

                if (politicalCheckedId != null)
                {
                    return new CommandResult(false, "Político já existe.", command);
                }
                else
                {
                    var politicalCheckedFullname = _repository.VerifyExistFullName(command.FullName);

                    if (politicalCheckedFullname != null)
                    {
                        return new CommandResult(false, "Político já existe.", command);
                    }
                }

                var _political = SetPolitical(politicalCheckedId, command, null);

                _repository.Add(_political);

                return new CommandResult(true, "Político adicionado com sucesso.", _political);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", command);
            }
        }

        public ICommandResult Handle(UpdatePoliticalCommand command)
        {
            try
            {
                command.Validate();

                if (command.Invalid)
                {
                    return new CommandResult(false, "Erro nas informações do Político.", command.Notifications);
                }

                var politicalCheckedId = _repository.VerifyExist(command.CongressmanId, command.SenatorId);

                if (politicalCheckedId == null)
                {
                    var politicalCheckedFullname = _repository.VerifyExistFullName(command.FullName);

                    if (politicalCheckedFullname == null)
                    {
                        return new CommandResult(false, "Você está tentando alterar um Político que não existe.", command);
                    }
                }

                var _political = SetPolitical(politicalCheckedId, null, command);

                _repository.Update(_political);

                return new CommandResult(true, "Político alterado com sucesso.", _political);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", command);
            }
        }

        private Political SetPolitical(Political political, CreatePoliticalCommand commandAdd, UpdatePoliticalCommand commandUp)
        {
            if (commandAdd != null)
            {
                var _political = new Political(
                commandAdd.CongressmanId,
                commandAdd.SenatorId,
                commandAdd.Name,
                commandAdd.FullName,
                commandAdd.State,
                commandAdd.Image
                );

                return _political;
            }
            else
            {
                political.SetCongresmanId(commandUp.CongressmanId);
                political.SetSenatorId(commandUp.SenatorId);
                political.SetName(commandUp.Name);
                political.SetState(commandUp.State);
                political.SetImage(commandUp.Image);

                return political;
            }
        }
    }
}