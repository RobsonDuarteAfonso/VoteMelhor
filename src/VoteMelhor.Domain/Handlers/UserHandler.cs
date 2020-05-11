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
    public class UserHandler :
        Notifiable,
        IHandler<CreateUserCommand>,
        IHandler<UpdateUserCommand>,
        IHandler<UpdateUserRoleCommand>,
        IHandler<UpdateUserStatusCommand>
    {
        private readonly IUserRepository _repository;

        public UserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateUserCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Erro nas informações do usuário.", command.Notifications);
            }

            var newUser = new User(command.Name, command.Email, command.Password, command.State);
            var user = _repository.VerifyExist(newUser);
            
            try
            {
                if (user != null)
                {
                    return new CommandResult(false, "Já existe um usuário.", user);
                }

                _repository.Add(user);
                return new CommandResult(true, "Usuário adicionado com sucesso.", user);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", user);
            }
        }

        public ICommandResult Handle(UpdateUserCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Erro nas informações do usuário.", command.Notifications);
            }

            var newUser = new User(command.Name, command.Email, command.Password, command.State);
            var user = _repository.VerifyExist(newUser);
                
            if (user == null)
            {
                return new CommandResult(false, "Você está tentando alterar usuário que não existe.", command);
            }

            user.SetName(command.Name);
            user.SetState(command.State);

            try
            {
                _repository.Update(user);
                return new CommandResult(true, "Usuário adicionada com sucesso.", user);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", user);
            }
        }

        public ICommandResult Handle(UpdateUserRoleCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Erro nas informações do usuário.", command.Notifications);
            }

            var newUser = new User(command.Email, command.Role);
            var user = _repository.VerifyExist(newUser);
                
            if (user == null)
            {
                return new CommandResult(false, "Você está tentando alterar usuário que não existe.", command);
            }

            user.SetRole(command.Role);

            try
            {
                _repository.Update(user);
                return new CommandResult(true, "Usuário adicionada com sucesso.", user);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", user);
            }
        }

        public ICommandResult Handle(UpdateUserStatusCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Erro nas informações do usuário.", command.Notifications);
            }

            var newUser = new User(command.Email, command.UserStatus);
            var user = _repository.VerifyExist(newUser);
                
            if (user == null)
            {
                return new CommandResult(false, "Você está tentando alterar usuário que não existe.", command);
            }

            user.SetUserStatus(command.UserStatus);

            try
            {
                _repository.Update(user);
                return new CommandResult(true, "Usuário adicionada com sucesso.", user);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", user);
            }
        }
    }
}