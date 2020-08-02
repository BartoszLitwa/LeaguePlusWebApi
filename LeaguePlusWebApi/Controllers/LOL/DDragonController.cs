using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaguePlusWebApi
{
    [Route("api/lol")]
    [ApiController]
    public class DDragonController : ControllerBaseHandler
    {
        private readonly IWebClient _webClient;
        private readonly ILogger _logger;

        public DDragonController(IWebClient webClient, ILogger logger) : base(webClient, logger)
        {
            _webClient = webClient;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("OK");
        }

        // GET Current Game Version
        [HttpGet("version")]
        public async Task<ActionResult> GetCurrentGameVersion()
        {
            var json = await GetJsonFromUrl("https://ddragon.leagueoflegends.com/api/versions.json");
            if (string.IsNullOrEmpty(json))
            {
                _logger.LogError("Couldnt get the League current version");
                return NotFound();
            }

            List<string> versions = JsonConvert.DeserializeObject<List<string>>(json);
            return Ok($"'{versions.First()}'" ?? "'10.12.1'");
        }
    }
}
