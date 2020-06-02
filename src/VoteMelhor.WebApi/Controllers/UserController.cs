using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using VoteMelhor.Domain.Commands;
using VoteMelhor.Domain.Commands.Creates;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Enumations;
using VoteMelhor.Domain.Handlers;
using VoteMelhor.Domain.Interfaces.Repositories;
using VoteMelhor.WebApi.Dtos;
using VoteMelhor.WebApi.Services;
using VoteMelhor.WebApi.Util;

namespace VoteMelhor.WebApi.Controllers
{
    [Route("v1/user")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public UsuarioController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("authenticate")]
        [AllowAnonymous]
        public QueryResult Authenticate(
            [FromBody] UserDto userDto,
            [FromServices] IUserRepository userRepository
        )
        {
            try
            {
                var newUser = new User(userDto.Email, userDto.Password);
                var user = userRepository.AuthenticateUser(newUser);

                if (user == null)
                {
                    return new QueryResult(false, "Usuário ou senha inválidos", new { userDto.Email, userDto.Password });
                }

                string token = _tokenService.GenerateToken(user);
                return new QueryResult(true, "Usuário autenticado com sucesso", new { user, token });
            }
            catch (Exception ex)
            {
                return new QueryResult(false, $"Erro: {ex.Message}", new { userDto.Email, userDto.Password });
            }
        }


        /*         [HttpGet]
                [Route("autenticado")]
                [Authorize]
                public string Authenticated() => string.Format("Autenticado - {0}", User.Identity.Name);
         */
/*         [HttpGet]
        [Route("usuario")]
        [AuthorizeEnum(RoleEnum.USR, RoleEnum.ADM, RoleEnum.EDT)]
        public string Usuario() => "Usuário"; */

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public CommandResult Post(
            [FromBody] CreateUserCommand command,
            [FromServices] UserHandler handler
        )
        {
            try
            {
                return (CommandResult)handler.Handle(command);

            }
            catch (Exception ex)
            {
                return new CommandResult(false, $"Erro: {ex.Message}", command);
            }
        }
    }
}