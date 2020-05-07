using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.WebApi.Raws;
using VoteMelhor.WebApi.Services;


namespace VoteMelhor.WebApi.Controllers
{
    [Route("v1/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
/*         private readonly IPoliticoPartidoService _politicoPartidoService;
        private readonly IPoliticoService _politicoService;
        private readonly IPartidoService _partidoService;
        private readonly ICargoService _cargoService; 
        private readonly IMapper _mapper;*/

        public AdminController(
/*             IPoliticoPartidoService politicoPartidoService,
            IPartidoService partidoService,
            IPoliticoService politicoService,
            ICargoService cargoService, 
            IMapper mapper*/
            )
        {
/*             _politicoPartidoService = politicoPartidoService;
            _politicoService = politicoService;
            _partidoService = partidoService;
            _cargoService = cargoService; 
            _mapper = mapper;*/
        }

        [HttpGet]
        [Route("add-senadores")]
        //[AuthorizeEnum(Perfil.ADM)]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> AddSenadores()
        {
/*                 try
                {

                var senadoFederalService = new SenadoFederalService();

                var jsonNet = await senadoFederalService.GetListaSenadores();

                foreach (var item in jsonNet.ListaParlamentarEmExercicio.Parlamentares.Parlamentar)
                {
                    var itemrecebido = item.IdentificacaoParlamentar;

                    if (_politicoService.VerifyExist(Convert.ToInt32(itemrecebido.CodigoParlamentar)) == null)
                    {
                        PoliticoViewModel _politico = new PoliticoViewModel();
                        PoliticoPartidoViewModel _politicoPartido = new PoliticoPartidoViewModel();
                        CargoViewModel _cargo = new CargoViewModel();
                        PartidoViewModel _partido = new PartidoViewModel();

                        _politico.Id = Convert.ToInt32(itemrecebido.CodigoParlamentar);
                        _politico.Nome = itemrecebido.NomeParlamentar;
                        _politico.Imagem = itemrecebido.UrlFotoParlamentar;
                        _politico.Estado = (EstadoEnum)Enum.Parse(typeof(EstadoEnum), itemrecebido.UfParlamentar);

                        _politicoService.AddNewPolitico(_mapper.Map<Politico>(_politico));

                        _partido = _mapper.Map<PartidoViewModel>(_partidoService.VerifyExist(itemrecebido.SiglaPartidoParlamentar));

                        if (_partido == null)
                        {
                            return BadRequest($"Partido com a sigla { itemrecebido.SiglaPartidoParlamentar } não existe.");
                        }

                        _politicoPartido = _mapper.Map<PoliticoPartidoViewModel>(_politicoPartidoService.VerifyExist(_politico.Id, _partido.Id));

                        if (_politicoPartido == null)
                        {
                            //_politicoPartidoService.SetAtual(_politico.Id, 0);

                            _politicoPartido.Atual = 1;
                            _politicoPartido.Partido = _partido;
                            _politicoPartido.Politico = _politico;

                            _politicoPartidoService.Add(_mapper.Map<PoliticoPartido>(_politicoPartido));
                        }
                        else
                        {
                            if (_politicoPartido.Atual != 1)
                            {
                                _politicoPartido.Atual = 1;
                                //_politicoPartidoService.SetAtual(_politico.Id, 0);
                                _politicoPartidoService.Update(_mapper.Map<PoliticoPartido>(_politicoPartido));
                            }
                        }

                        _cargo.Nome = "Senador";
                        _cargo.Politico = _politico;

                        _cargo = _mapper.Map<CargoViewModel>(_cargoService.VerifyExist(_mapper.Map<Cargo>(_cargo)));

                        if (_cargo == null)
                        {
                            _cargoService.SetAtual(_politico.Id, 0);

                            _cargo.Atual = 1;
                            _cargo.Politico = _politico;
                            _cargo.Nome = "Senador";

                            _cargoService.Add(_mapper.Map<Cargo>(_cargo));
                        }
                        else
                        {
                            if (_cargo.Atual != 1)
                            {
                                _cargo.Atual = 1;
                                _cargoService.SetAtual(_politico.Id, 0);
                                _cargoService.Update(_mapper.Map<Cargo>(_cargo));
                            }
                        }

                        Ok("Sucesso");
                    }

                }

                return Ok("Sucesso");
                }
                catch (Exception ex)
                {
                    return BadRequest($"Erro: {ex.Message}");
                } */

                return Ok();
        }

        [HttpGet]
        [Route("add-all-partidos")]
        //[AuthorizeEnum(Perfil.ADM)]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> AddAllPartidos()
        {
/*             try
            {
                var webClient = new WebClient();
                var json = webClient.DownloadString("./Extra/partidos.json");

                List<Partidos_Raw> jsonNet = JsonConvert.DeserializeObject<List<Partidos_Raw>>(json);

                foreach (var item in jsonNet)
                {
                    PartidoViewModel _partido = new PartidoViewModel();

                    _partido.Sigla = item.Sigla;
                    _partido.Nome = item.Nome;
                    _partido.Imagem = item.Imagem;
                    _partido.Numero = item.Numero;

                    Partido partido = _mapper.Map<Partido>(_partido);

                    if (_partidoService.VerifyExist(partido) == null)
                    {
                       await _partidoService.AddAsync(partido);
                    }
                    else
                    {
                       await _partidoService.UpdateAsync(partido);
                    }
                }
                
                return Ok("Partidos Cadastrados com Sucesso.");

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }      */     
            return Ok();  
        }
    }
}