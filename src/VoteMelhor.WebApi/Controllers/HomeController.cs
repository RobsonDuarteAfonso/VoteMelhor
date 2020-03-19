using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoteMelhor.ApplicationCore.Entities;
using VoteMelhor.ApplicationCore.Interfaces.Services;
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

    }
}