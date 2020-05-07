using System;
using Flunt.Notifications;
using VoteMelhor.Domain.Commands;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Commands;
using VoteMelhor.Domain.Interfaces.Handlers;
using VoteMelhor.Domain.Interfaces.Repositories;

namespace VoteMelhor.Domain.Handlers
{
    public class ClassificacaoHandler :
        Notifiable,
        IHandler<CreateClassificacaoCommand>,
        IHandler<UpdateClassificacaoCommand>
    {
        private readonly IClassificacaoRepository _repository;

        public ClassificacaoHandler(IClassificacaoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateClassificacaoCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Erro nas informações da classificação.", command.Notifications);
            }

            var classificacao = new Classificacao(command.Rate, command.UsuarioId, command.PoliticoId);
            var classificacaoVerificada = _repository.VerifyExist(classificacao);
            
            try
            {
                if (classificacaoVerificada != null)
                {
                    return new GenericCommandResult(false, "Já existe uma classificação.", classificacaoVerificada);
                }

                _repository.Add(classificacaoVerificada);
                return new GenericCommandResult(true, "Classificação adicionada com sucesso.", classificacaoVerificada);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, $"Erro: {ex.Message}", classificacaoVerificada);
            }
        }

        public ICommandResult Handle(UpdateClassificacaoCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Erro nas informações da classificação.", command.Notifications);
            }

            var classificacao = _repository.GetById(command.Id);
                
            if (classificacao == null)
            {
                return new GenericCommandResult(false, "Você está tentando alterar classificação que não existe.", command);
            }

            if (classificacao.UsuarioId != command.UsuarioId || classificacao.PoliticoId != command.PoliticoId)
            {
                return new GenericCommandResult(false, "Erro nas informações da classificação.", command.Notifications);
            }

            classificacao.SetRate(command.Rate);

            try
            {
                _repository.Update(classificacao);
                return new GenericCommandResult(true, "Classificação adicionada com sucesso.", classificacao);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, $"Erro: {ex.Message}", classificacao);
            }
        }
    }
}