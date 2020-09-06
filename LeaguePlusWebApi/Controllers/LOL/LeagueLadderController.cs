using LeaguePlus.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LeaguePlusWebApi
{
    [Route("api/")]
    [ApiController]
    public class LeagueLadderController : ControllerBaseHandler
    {
        private readonly IWebClient _webClient;

        public LeagueLadderController(IWebClient webClient) : base(webClient)
        {
            _webClient = webClient;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("OK");
        }

        // GET Free Champions Rotation
        [HttpGet("{region}/lol/league-exp/v4/entries/{queue}/{tier}/{division}")]
        public async Task<ActionResult> GetChampionsRotation(string region, string queue, string tier, string division)
        {
            return await HandleWebRequest($"{region}/lol/league-exp/v4/entries/{queue}/{tier}/{division}");
        }
    }
}
