using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using System;
using System.Collections.Generic;
using VoteMelhor.Domain.Commands;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.Domain.Interfaces.Repositories;
using VoteMelhor.WebApi.Dtos;

namespace VoteMelhor.WebApi.Controllers
{
    [Route("v1/public")]
    [ApiController]
    public class PublicController : ControllerBase
    {
        public PublicController()
        {
        }

        [HttpGet]
        [Route("states")]
        [AllowAnonymous]
        public CommandResult GetStates(
        )
        {
            var _listState = new List<StateDto>();

            foreach (StateEnum stateEnum in Enum.GetValues(typeof(StateEnum)))
            {
                var _state = new StateDto(
                    stateEnum.GetHashCode(),
                    stateEnum.GetDisplayName(),
                    stateEnum.GetAttributeOfType<System.ComponentModel.DescriptionAttribute>().Description
                );

                _listState.Add(_state);
            }

            var commandResult = new CommandResult(true, "Lista de estados recebida com sucesso.", _listState);

            return commandResult;
        }

        [HttpPost]
        [Route("search")]
        [AllowAnonymous]
        public CommandResult SearchPoliticals(
            [FromBody] SearchPoliticalDto searchPolitical,
            [FromServices] IPoliticalRepository politicalRepository
        )
        {
            var commandResult = new CommandResult();

            try
            {
                if (searchPolitical.State == null && searchPolitical.Name == null)
                {
                    return commandResult = new CommandResult(false, "É necessário informar ou parte de um nome ou estado.", null);
                }

                List<Political> listPolitical = politicalRepository.SearchPoliticals(searchPolitical.Name, searchPolitical.State);

                commandResult = new CommandResult(true, "Procura executada com sucesso.", listPolitical);

                return commandResult;
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", commandResult);
            }
        }
    }
}