using System;
using System.Collections.Generic;
using Flunt.Notifications;
using VoteMelhor.Domain.Commands;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Interfaces.Commands;
using VoteMelhor.Domain.Interfaces.Handlers;
using VoteMelhor.Domain.Interfaces.Repositories;

namespace VoteMelhor.Domain.Handlers
{
    public class SenatorCongressmanHandler :
        Notifiable,
        IHandler<SenatorCongressmanCommand>
    {
        private readonly IPoliticalRepository _politicalRepository;
        private readonly IPoliticalPartyRepository _politicalPartyRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly IPartyRepository _partyRepository;

        public SenatorCongressmanHandler(
        IPoliticalRepository politicalRepository,
        IPoliticalPartyRepository politicalPartyRepository,
        IPositionRepository positionRepository,
        IPartyRepository partyRepository
        )
        {
            _politicalRepository = politicalRepository;
            _politicalPartyRepository = politicalPartyRepository;
            _positionRepository = positionRepository;
            _partyRepository = partyRepository;
        }

        public ICommandResult Handle(SenatorCongressmanCommand command)
        {
            var _listCmdResult = new List<ICommandResult>();

            try
            {
                //Create or Update a political
                if (command.Invalid)
                {
                    _listCmdResult.Add(new CommandResult(false, "Erro nas informações do político.", command.Notifications));
                }
                else
                {
                    var _political = _politicalRepository.VerifyExist(command.Political.CongressmanId, command.Political.SenatorId);

                    if (_political == null)
                    {
                        _political = _politicalRepository.VerifyExistFullName(command.Political.FullName);

                        if (_political == null)
                        {
                            _politicalRepository.AddPolitical(command.Political);

                            _listCmdResult.Add(new CommandResult(true, "Político adicionado com sucesso.", command.Political));
                        }
                        else
                        {
                            _politicalRepository.Update(MountPolitical(_political, command.Political));

                            _listCmdResult.Add(new CommandResult(true, "Político alterado com sucesso.", _political));
                        }
                    }
                    else
                    {
                        _politicalRepository.Update(MountPolitical(_political, command.Political));

                        _listCmdResult.Add(new CommandResult(true, "Político alterado com sucesso.", _political));
                    }

                    //Create a temporary Party
                    var _party = _partyRepository.VerifyExist(command.PartyInitials);

                    if (_party == null)
                    {
                        _party = new Party("Novo Partido", command.PartyInitials, 0, "http");

                        _partyRepository.Add(_party);

                        _listCmdResult.Add(new CommandResult(false, "Novo Partido adicionado com dados incompletos.", _party));
                    }                

                    //Create or Update a relation Political with Party
                    var _politicalPartyChecked = _politicalPartyRepository.VerifyExist(command.Political.Id, _party.Id);

                    if (_politicalPartyChecked == null)
                    {
                        var _politicalParty = new PoliticalParty(
                            true,
                            command.Political.Id,
                            _party.Id
                        );

                        _politicalPartyRepository.Add(_politicalParty);

                        _listCmdResult.Add(new CommandResult(true, "Político com Partido adicionado com sucesso.", _politicalParty));
                    }
                    else
                    {
                        _politicalPartyRepository.UpdateCurrent(_politicalPartyChecked);

                        _listCmdResult.Add(new CommandResult(true, "Político com Partido alterado com sucesso.", _politicalPartyChecked));
                    }


                    //Create or Update a relation Political with Position
                    var _positionChecked = _positionRepository.VerifyExist(command.Position.PoliticalId, command.Position.Name, command.Position.Participation);

                    if (_positionChecked == null)
                    {
                        _positionRepository.Add(command.Position);

                        _listCmdResult.Add(new CommandResult(true, "Cargo para o político adicionado com sucesso.", command.Position));
                    }
                    else
                    {
                        _positionRepository.UpdateCurrent(_positionChecked.Id, _positionChecked.PoliticalId);

                        _listCmdResult.Add(new CommandResult(true, "Cargo para o político alterado com sucesso.", _positionChecked));
                    }

                }

                return new CommandResult(true, "Todas as informações adicionadas com sucesso.", _listCmdResult);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", _listCmdResult);
            }
        }

        public Political MountPolitical(Political politicalChecked, Political commandPolitical)
        {
            politicalChecked.SetCongresmanId(commandPolitical.CongressmanId);
            politicalChecked.SetSenatorId(commandPolitical.SenatorId);
            politicalChecked.SetName(commandPolitical.Name);
            politicalChecked.SetState(commandPolitical.State);
            politicalChecked.SetImage(commandPolitical.Image);

            return politicalChecked;
        }
    }
}