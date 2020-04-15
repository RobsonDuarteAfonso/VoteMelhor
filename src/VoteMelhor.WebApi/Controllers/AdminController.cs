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
using VoteMelhor.ApplicationCore.Entities;
using VoteMelhor.ApplicationCore.Enumations;
using VoteMelhor.ApplicationCore.Interfaces.Services;
using VoteMelhor.WebApi.Raws;
using VoteMelhor.WebApi.ViewModels;

namespace VoteMelhor.WebApi.Controllers
{
    [Route("v1/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IPoliticoPartidoService _politicoPartidoService;
        private readonly IPoliticoService _politicoService;
        private readonly IPartidoService _partidoService;
        private readonly ICargoService _cargoService;
        private readonly IMapper _mapper;

        public AdminController(
            IPoliticoPartidoService politicoPartidoService,
            IPartidoService partidoService,
            IPoliticoService politicoService,
            ICargoService cargoService,
            IMapper mapper)
        {
            _politicoPartidoService = politicoPartidoService;
            _politicoService = politicoService;
            _partidoService = partidoService;
            _cargoService = cargoService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("update-politicos")]
        //[AuthorizeEnum(Perfil.ADM)]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> UpdatePoliticos()
        {
            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync("http://legis.senado.leg.br/dadosabertos/senador/lista/atual");
                string apiResponse = await response.Content.ReadAsStringAsync();

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(apiResponse);

                string jsonString = JsonConvert.SerializeXmlNode(doc);

                // Site para gerar a class do objeto: jsonutils.com
                PoliticosSenadores_Raw jsonNet = JsonConvert.DeserializeObject<PoliticosSenadores_Raw>(jsonString);

                foreach (var item in jsonNet.ListaParlamentarEmExercicio.Parlamentares.Parlamentar)
                {
                    PoliticoViewModel _politico = new PoliticoViewModel();
                    PoliticoPartidoViewModel _politicoPartido = new PoliticoPartidoViewModel();

                    var itemrecebido = item.IdentificacaoParlamentar;

                    _politico.Id = Convert.ToInt32(itemrecebido.CodigoParlamentar);
                    _politico.Nome = itemrecebido.NomeParlamentar;
                    _politico.Imagem = itemrecebido.UrlFotoParlamentar;
                    _politico.Estado = (Estado)Enum.Parse(typeof(Estado), itemrecebido.UfParlamentar);

                    _politicoService.AddNewPolitico(_mapper.Map<Politico>(_politico));

                    Ok("Sucesso");

                }
                return Ok("Sucesso");
            }
        }

        [HttpGet]
        [Route("add-all-partidos")]
        //[AuthorizeEnum(Perfil.ADM)]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> AddAllPartidos()
        {
            try
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
                        _partidoService.Add(partido);
                    }
                    else
                    {
                        _partidoService.Update(partido);
                    }
                }
                
                return Ok("Partidos Cadastrados com Sucesso.");

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }            
        }
    }
}