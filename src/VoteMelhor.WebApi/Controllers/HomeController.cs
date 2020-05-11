using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoteMelhor.Domain.Commands;
using VoteMelhor.Domain.Commands.Creates;
using VoteMelhor.Domain.Entities;
using VoteMelhor.Domain.Handlers;
using VoteMelhor.WebApi.Services;

namespace VoteMelhor.WebApi.Controllers
{
    [Route("v1/[Controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {
        }

        [HttpPost]
        [Route("")]
        //[AuthorizeEnum(Perfil.ADM)]
        [AllowAnonymous]
        public CommandResult Create(
            [FromBody]CreateLawSuitCommand command,
            [FromServices]LawSuitHandler handler
        )
        {
            command.Summary= "teste";
            return (CommandResult)handler.Handle(command);

        }

    }
}