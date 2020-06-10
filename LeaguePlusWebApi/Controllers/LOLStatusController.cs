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
    public class LOLStatusController : ControllerBaseHandler
    {
        private readonly IWebClient _webClient;

        public LOLStatusController(IWebClient webClient) : base(webClient)
        {
            _webClient = webClient;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("OK");
        }

        // GET Free Champions Rotation
        [HttpGet("{region}/lol/status/v3/shard-data")]
        public async Task<ActionResult> GetChampionsRotation(string region)
        {
            return await HandleWebRequest($"{region}/lol/status/v3/shard-data");
        }
    }
}
