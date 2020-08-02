using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaguePlusWebApi
{
    [Route("api/data")]
    [ApiController]
    public class DatabaseController : ControllerBaseHandler
    {
        private readonly IWebClient _webClient;
        private readonly ILogger _logger;

        public DatabaseController(IWebClient webClient, ILogger logger) : base(webClient, logger)
        {
            _webClient = webClient;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult GetUserData()
        {
            return Ok("OK");
        }
    }
}
