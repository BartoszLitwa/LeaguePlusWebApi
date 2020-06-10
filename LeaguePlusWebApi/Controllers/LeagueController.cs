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
    public class LeagueController : ControllerBaseHandler
    {
        private readonly IWebClient _webClient;

        public LeagueController(IWebClient webClient) : base(webClient)
        {
            _webClient = webClient;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("OK");
        }

        // GET Challenger League
        [HttpGet("{region}/lol/league/v4/challengerleagues/by-queue/{queue}")]
        public async Task<ActionResult> GetChallengerLeague(string region, string queue)
        {
            return await HandleWebRequest($"{region}/lol/league/v4/challengerleagues/by-queue/{queue}");
        }

        // GET Grandmaster League
        [HttpGet("{region}/lol/league/v4/grandmasterleagues/by-queue/{queue}")]
        public async Task<ActionResult> GetGrandmasterLeague(string region, string queue)
        {
            return await HandleWebRequest($"{region}/lol/league/v4/grandmasterleagues/by-queue/{queue}");
        }

        // GET Master League
        [HttpGet("{region}/lol/league/v4/masterleagues/by-queue/{queue}")]
        public async Task<ActionResult> GetMasterLeague(string region, string queue)
        {
            return await HandleWebRequest($"{region}/lol/league/v4/masterleagues/by-queue/{queue}");
        }

        // GET All Leagues that has given summoner
        [HttpGet("{region}/lol/league/v4/entries/by-summoner/{summonerId}")]
        public async Task<ActionResult> GetSummonerLeagues(string region, string summonerId)
        {
            return await HandleWebRequest($"{region}/lol/league/v4/entries/by-summoner/{summonerId}");
        }

        // GET All League Entries
        [HttpGet("{region}/lol/league/v4/entries/{queue}/{tier}/{division}")]
        public async Task<ActionResult> GetAllLeaguesEntries(string region, string queue, string tier, string division)
        {
            return await HandleWebRequest($"{region}/lol/league/v4/entries/{queue}/{tier}/{division}");
        }

        // GET League by league ID
        [HttpGet("{region}/lol/league/v4/leagues/{leagueId}")]
        public async Task<ActionResult> GetLeagueByID(string region, string leagueId)
        {
            return await HandleWebRequest($"{region}/lol/league/v4/leagues/{leagueId}");
        }
    }
}
