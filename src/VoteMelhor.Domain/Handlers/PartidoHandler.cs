using System;
using Flunt.Notifications;
using VoteMelhor.Domain.Commands;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Commands;
using VoteMelhor.Domain.Interfaces.Handlers;
using VoteMelhor.Domain.Interfaces.Repositories;

namespace VoteMelhor.Domain.Handlers
{
    public class PartidoHandler :
        Notifiable,
        IHandler<CreatePartidoCommand>,
        IHandler<UpdatePartidoCommand>
    {
        private readonly IPartidoRepository _repository;

        public PartidoHandler(IPartidoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreatePartidoCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Erro nas informações da partido.", command.Notifications);
            }

            var partido = new Partido(command.Nome, command.Sigla, command.Numero, command.Imagem);
            var partidoVerificada = _repository.VerifyExist(partido);
            
            try
            {
                if (partidoVerificada != null)
                {
                    return new GenericCommandResult(false, "Já existe uma partido.", partidoVerificada);
                }

                _repository.Add(partidoVerificada);
                return new GenericCommandResult(true, "Partido adicionado com sucesso.", partidoVerificada);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, $"Erro: {ex.Message}", partidoVerificada);
            }
        }

        public ICommandResult Handle(UpdatePartidoCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Erro nas informações da classificação.", command.Notifications);
            }

            var partido = _repository.GetById(command.Id);
                
            if (partido == null)
            {
                return new GenericCommandResult(false, "Você está tentando alterar classificação que não existe.", command);
            }

            partido.SetNome(command.Nome);
            partido.SetSigla(command.Sigla);
            partido.SetNumero(command.Numero);
            partido.SetImagem(command.Imagem);

            try
            {
                _repository.Update(partido);
                return new GenericCommandResult(true, "Classificação adicionada com sucesso.", partido);
            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, $"Erro: {ex.Message}", partido);
            }
        }
    }
}