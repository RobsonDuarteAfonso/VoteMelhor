using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VoteMelhor.ApplicationCore.Entities;
using VoteMelhor.ApplicationCore.Enumations;
using VoteMelhor.ApplicationCore.Interfaces.Services;
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
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]Usuario model)
        {
            var usuario = _usuarioService.AutenticarUsuario(model);

            if (usuario == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            string token = _tokenService.GenerateToken(usuario);
            return new
            {
                usuario = usuario,
                token = token
            };

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

        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        public async Task<IActionResult> Post(Usuario model)
        {
            try
            {
                _usuarioService.Add(model);
                return Ok(model);
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

    }
}