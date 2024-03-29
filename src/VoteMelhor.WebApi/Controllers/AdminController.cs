﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using VoteMelhor.Domain.Commands;
using VoteMelhor.Domain.Commands.Creates;
using VoteMelhor.Domain.Commands.Updates;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.Domain.Handlers;
using VoteMelhor.Domain.Interfaces.Commands;
using VoteMelhor.WebApi.Raws;
using VoteMelhor.WebApi.Services;
using VoteMelhor.WebApi.Util;

namespace VoteMelhor.WebApi.Controllers
{
    [Route("v1/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public AdminController()
        {
        }

        [HttpGet]
        [Route("senators")]
        [AuthorizeEnum(RoleEnum.ADM)]
        [AllowAnonymous]
        public async Task<CommandResult> GetSenators(
            [FromServices]
            SenatorCongressmanHandler senatorCongressmanHandler
        )
        {
            var _listCmdResult = new List<ICommandResult>();

            try
            {
                var federalSenateService = new FederalSenateService();

                var jsonNet = await federalSenateService.GetListSenators();

                foreach (var item in jsonNet.ListaParlamentarEmExercicio.Parlamentares.Parlamentar)
                {
                    var itemrecebido = item.IdentificacaoParlamentar;

                    Political _political = new Political(
                        0,
                        Convert.ToInt32(itemrecebido.CodigoParlamentar),
                        itemrecebido.NomeParlamentar.ToUpper(),
                        itemrecebido.NomeCompletoParlamentar.ToUpper(),
                        (StateEnum)Enum.Parse(typeof(StateEnum), itemrecebido.UfParlamentar),
                        itemrecebido.UrlFotoParlamentar
                    );

                    string _party = itemrecebido.SiglaPartidoParlamentar;

                    //Correction
                    if (_party == "PODEMOS")
                    {
                        _party = "PODE";
                    }

                    Position _position = new Position("SENADOR", true, _political.Id);

                    SenatorCongressmanCommand _command = new SenatorCongressmanCommand(_political, _position, _party);

                    var _result = (CommandResult)senatorCongressmanHandler.Handle(_command);

                    _listCmdResult.Add(_result);
                }

                return new CommandResult(true, "Todos os senadores carregados.", _listCmdResult);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", _listCmdResult);
            }
        }

        [HttpGet]
        [Route("congressmen")]
        [AuthorizeEnum(RoleEnum.ADM)]
        [AllowAnonymous]
        public async Task<CommandResult> GetCongressmen(
            [FromServices]
            SenatorCongressmanHandler senatorCongressmanHandler
        )
        {
            var _listCmdResult = new List<ICommandResult>();

            try
            {
                var houseRepresentativesService = new HouseRepresentativesService();

                var jsonNet = await houseRepresentativesService.GetListCongressmen();

                foreach (var item in jsonNet.dados)
                {
                    var fullName = await houseRepresentativesService.GetDetailsCongressman(item.id);
                    
                    Political _political = new Political(
                        Convert.ToInt32(item.id),
                        0,
                        item.nome.ToUpper(),
                        fullName.ToUpper(),
                        (StateEnum)Enum.Parse(typeof(StateEnum), item.siglaUf),
                        item.urlFoto
                    );

                    string _party = item.siglaPartido;

                    //Correction
                    if (_party == "PODEMOS")
                    {
                        _party = "PODE";
                    }

                    Position _position = new Position("DEP. FEDERAL", true, _political.Id);

                    SenatorCongressmanCommand _command = new SenatorCongressmanCommand(_political, _position, _party);

                    var _result = (CommandResult)senatorCongressmanHandler.Handle(_command);

                    _listCmdResult.Add(_result);
                }

                return new CommandResult(true, "Todos os deputados carregados.", _listCmdResult);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", _listCmdResult);
            }
        }


        [HttpGet]
        [Route("add-all-partys")]
        [AuthorizeEnum(RoleEnum.ADM)]
        [AllowAnonymous]
        public CommandResult AddAllPartidos(
            [FromServices]
            PartyHandler partyHandler
        )
        {
            var _listCmdResult = new List<ICommandResult>();

            try
            {
                var webClient = new WebClient();
                var json = webClient.DownloadString("./Extra/partidos.json");

                List<Partys_Raw> jsonNet = JsonConvert.DeserializeObject<List<Partys_Raw>>(json);

                foreach (var item in jsonNet)
                {
                    CreatePartyCommand _command = new CreatePartyCommand(item.Nome.ToUpper(), item.Sigla.ToUpper(), item.Numero, item.Imagem);

                    var _result = (CommandResult)partyHandler.Handle(_command);

                    _listCmdResult.Add(_result);

                    if (_result.Success == false && _result.Message == "Já existe o partido.")
                    {
                        UpdatePartyCommand _commandUp = new UpdatePartyCommand(item.Nome.ToUpper(), item.Sigla.ToUpper(), item.Numero, item.Imagem);

                        _result = (CommandResult)partyHandler.Handle(_command);

                        _listCmdResult.Add(_result);
                    }
                }

                return new CommandResult(true, "Todos os partidos carregados.", _listCmdResult);

            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", _listCmdResult);
            }
        }
    }
}