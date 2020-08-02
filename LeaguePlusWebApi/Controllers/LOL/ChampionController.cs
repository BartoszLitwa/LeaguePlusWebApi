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
    public class ChampionController : ControllerBaseHandler
    {
        private readonly IWebClient _webClient;

        public ChampionController(IWebClient webClient) : base(webClient)
        {
            _webClient = webClient;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("OK");
        }

        // GET Free Champions Rotation
        [HttpGet("{region}/lol/platform/v3/champion-rotations")]
        public async Task<ActionResult> GetChampionsRotation(string region)
        {
            return await HandleWebRequest($"{region}/lol/platform/v3/champion-rotations");
        }
    }
}
