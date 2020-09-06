using LeaguePlus.Core;
using Microsoft.AspNetCore.Mvc;

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
