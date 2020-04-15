using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VoteMelhor.ApplicationCore.Entities;
using VoteMelhor.ApplicationCore.Enumations;
using VoteMelhor.ApplicationCore.Interfaces.Services;
using VoteMelhor.WebApi.Services;
using VoteMelhor.WebApi.Util;
using VoteMelhor.WebApi.Validations;

namespace VoteMelhor.WebApi.Controllers
{
    [Route("v1/account")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly TokenService _tokenService;
        private readonly CreateUsuarioValidation _createUsuarioValidation;

        public UsuarioController(IUsuarioService usuarioService, TokenService tokenService, CreateUsuarioValidation createUsuarioValidation)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
            _createUsuarioValidation = createUsuarioValidation;
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
        [AuthorizeEnum(Perfil.USR, Perfil.ADM, Perfil.EDT)]
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
                ValidationResult result = _createUsuarioValidation.Validate(model);

                if (result.IsValid)
                {
                    _usuarioService.Add(model);
                    return Ok(model);
                } 
                else
                {
                    return BadRequest(result.Errors);                
                }
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

    }
}