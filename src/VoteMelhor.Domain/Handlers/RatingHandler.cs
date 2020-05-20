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
    public class RatingHandler :
        Notifiable,
        IHandler<CreateRatingCommand>,
        IHandler<UpdateRatingCommand>
    {
        private readonly IRatingRepository _repository;

        public RatingHandler(IRatingRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateRatingCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Erro nas informações da classificação.", command.Notifications);
            }

            var rating = new Rating(command.Rate, command.UserId, command.PoliticalId);
            var ratingChecked = _repository.VerifyExist(rating);
            
            try
            {
                if (ratingChecked != null)
                {
                    return new CommandResult(false, "Já existe uma classificação.", ratingChecked);
                }

                _repository.Add(rating);
                return new CommandResult(true, "Classificação adicionada com sucesso.", rating);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", rating);
            }
        }

        public ICommandResult Handle(UpdateRatingCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new CommandResult(false, "Erro nas informações da classificação.", command.Notifications);
            }

            var rating = _repository.GetById(command.Id);
                
            if (rating == null)
            {
                return new CommandResult(false, "Você está tentando alterar classificação que não existe.", command);
            }

            if (rating.UserId != command.UserId || rating.PoliticalId != command.PoliticalId)
            {
                return new CommandResult(false, "Erro nas informações da classificação.", command.Notifications);
            }

            rating.SetRate(command.Rate);

            try
            {
                _repository.Update(rating);
                return new CommandResult(true, "Classificação alterado com sucesso.", rating);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", rating);
            }
        }
    }
}