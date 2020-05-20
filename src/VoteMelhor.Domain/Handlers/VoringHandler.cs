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
    public class VotingHandler :
        Notifiable,
        IHandler<CreateVotingCommand>,
        IHandler<UpdateVotingCommand>
    {
        private readonly IVotingRepository _repository;

        public VotingHandler(IVotingRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateVotingCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Erro nas informações da votação.", command.Notifications);
            }

            var voting = new Voting(command.Vote, command.VotingDate, command.PoliticalId, command.ProposalId);
            var votingChecked = _repository.VerifyExist(voting);
            
            try
            {
                if (votingChecked != null)
                {
                    return new CommandResult(false, "Já existe uma votação.", voting);
                }

                _repository.Add(voting);
                return new CommandResult(true, "Votação adicionada com sucesso.", voting);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", voting);
            }
        }
        
        public ICommandResult Handle(UpdateVotingCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Erro nas informações da votação.", command.Notifications);
            }

            var voting = _repository.GetById(command.Id);
                
            if (voting == null)
            {
                return new CommandResult(false, "Você está tentando alterar votação que não existe.", command);
            }

            if (voting.Vote != command.Vote || voting.VotingDate != command.VotingDate)
            {
                return new CommandResult(false, "Erro nas informações da votação.", command.Notifications);
            }

            voting.SetVote(command.Vote);
            voting.SetVotingDate(command.VotingDate);

            try
            {
                _repository.Update(voting);
                return new CommandResult(true, "Votação alterada com sucesso.", voting);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", voting);
            }
        }
    }
}