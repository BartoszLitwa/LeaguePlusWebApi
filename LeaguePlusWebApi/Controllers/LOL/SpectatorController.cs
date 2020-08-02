using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaguePlusWebApi
{
    [Route("api/")]
    [ApiController]
    public class SpectatorController : ControllerBaseHandler
    {
        private readonly IWebClient _webClient;
        private readonly ILogger _logger;

        public SpectatorController(IWebClient webClient, ILogger logger) : base(webClient, logger)
        {
            _webClient = webClient;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("OK");
        }

        // GET Current Game Info By SummonerID
        [HttpGet("{region}/lol/spectator/v4/active-games/by-summoner/{encryptedSummonerId}")]
        public async Task<ActionResult> GetCurrentGameInfoBySummonerID(string region, string encryptedSummonerId)
        {
            return await HandleWebRequest($"{region}/lol/spectator/v4/active-games/by-summoner/{encryptedSummonerId}");
        }

        // GET List Of Featured Games
        [HttpGet("{region}/lol/spectator/v4/featured-games")]
        public async Task<ActionResult> GetListOfFeaturedGames(string region)
        {
            return await HandleWebRequest($"{region}/lol/spectator/v4/featured-games");
        }
    }
}
