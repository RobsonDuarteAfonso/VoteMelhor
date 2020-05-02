using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.Domain.Interfaces.Services;
using VoteMelhor.WebApi.Services;
using VoteMelhor.WebApi.Util;

namespace VoteMelhor.WebApi.Controllers
{
    [Route("v1/account")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly TokenService _tokenService;

        public UsuarioController(IUsuarioService usuarioService, TokenService tokenService)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]Usuario model)
        {
            try
            {
                var usuario = _usuarioService.AutenticarUsuario(model);

                if (usuario == null)
                    return NotFound(new { message = "Usuário ou senha inválidos" });

                string token = _tokenService.GenerateToken(usuario);
                return new
                {
                    usuario,
                    token
                };
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("autenticado")]
        [Authorize]
        public string Authenticated() => string.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("usuario")]
        [AuthorizeEnum(PerfilEnum.USR, PerfilEnum.ADM, PerfilEnum.EDT)]
        public string Usuario() => "Usuário";

        /// <summary>
        /// Cadastrar Novo Usuário
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        public async Task<IActionResult> Post(Usuario model)
        {
            try
            {
/*                 if (model)
                { */
                    _usuarioService.Add(model);
                    return Ok(model);
/*                 } 
                else
                {
                    return BadRequest(result.Errors);                
                } */
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

    }
}