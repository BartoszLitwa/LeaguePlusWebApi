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
    public class ChampionMasteryController : ControllerBaseHandler
    {
        private readonly IWebClient _webClient;

        public ChampionMasteryController(IWebClient webClient) : base(webClient)
        {
            _webClient = webClient;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("OK");
        }

        // GET Summoner All Champion Mastery
        [HttpGet("{region}/lol/champion-mastery/v4/champion-masteries/by-summoner/{encryptedSummonerId}")]
        public async Task<ActionResult> GetSummonerAllChampionMastery(string region, string encryptedSummonerId)
        {
            return await HandleWebRequest($"{region}/lol/champion-mastery/v4/champion-masteries/by-summoner/{encryptedSummonerId}");
        }

        // GET Champion Mastery By Player And ChampID
        [HttpGet("{region}/lol/champion-mastery/v4/champion-masteries/by-summoner/{encryptedSummonerId}/by-champion/{championId}")]
        public async Task<ActionResult> GetChampionMasteryByPlayerAndChampID(string region, string encryptedSummonerId, string championId)
        {
            return await HandleWebRequest($"{region}/lol/champion-mastery/v4/champion-masteries/by-summoner/{encryptedSummonerId}/by-champion/{championId}");
        }

        // GET Summoner Total Mastery Score
        [HttpGet("{region}/lol/champion-mastery/v4/scores/by-summoner/{encryptedSummonerId}")]
        public async Task<ActionResult> GetSummonerTotalMasteryScore(string region, string encryptedSummonerId)
        {
            return await HandleWebRequest($"{region}/lol/champion-mastery/v4/scores/by-summoner/{encryptedSummonerId}");
        }
    }
}
