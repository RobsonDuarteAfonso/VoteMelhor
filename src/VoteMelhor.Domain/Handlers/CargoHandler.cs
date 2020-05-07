using System;
using Flunt.Notifications;
using VoteMelhor.Domain.Commands;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Commands;
using VoteMelhor.Domain.Interfaces.Handlers;
using VoteMelhor.Domain.Interfaces.Repositories;

namespace VoteMelhor.Domain.Handlers
{
    public class CargoHandler :
        Notifiable,
        IHandler<CreateCargoCommand>,
        IHandler<UpdateCargoCommand>
    {
        private readonly ICargoRepository _repository;

        public CargoHandler(ICargoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateCargoCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Erro nas informações do cargo.", command.Notifications);
            }

            var cargo = new Cargo(command.Nome, command.PoliticoId);
            var cargoVerificado = _repository.VerifyExist(cargo);
            
            try
            {
                if (cargoVerificado != null)
                {
                    return new GenericCommandResult(false, "Cargo já existe.", command);
                }

                _repository.Add(cargo);
                return new GenericCommandResult(true, "Cargo adicionado com sucesso.", cargo);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, $"Erro: {ex.Message}", cargo);
            }
        }

        public ICommandResult Handle(UpdateCargoCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Erro nas informações do cargo.", command.Notifications);
            }

            var cargo = _repository.GetById(command.Id);

            try
            {
                if (cargo == null)
                {
                    return new GenericCommandResult(false, "Você está tentando alterar um cargo que não existe.", command);

                }

                _repository.UpdateAtual(command.Id, command.PoliticoId);
                _repository.Add(cargo);
                return new GenericCommandResult(true, "Cargo adicionado com sucesso.", cargo);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, $"Erro: {ex.Message}", cargo);
            }
        }
    }
}