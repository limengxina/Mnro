using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mnro.Entity.Extenum;
using Mnro.Entity.Models;
using Mnro.Interface;

namespace Mnro.Web.Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
       
        private readonly ILogger<TestController> _logger;

        private readonly IUserService _iUserService;

        public TestController(ILogger<TestController> logger, IUserService userService)
        {
            _logger = logger;
            _iUserService = userService;
        }

        [HttpGet]
        public UserInfo Get()
        {
            var user =  _iUserService.Query<UserInfo>(WriteAndReadEnum.Read).FirstOrDefault();

            return user;
        }
    }
}
