using LeaguePlus.Core;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LeaguePlusWebApi
{
    [Route("api/")]
    [ApiController]
    public class MatchController : ControllerBaseHandler
    {
        private readonly IWebClient _webClient;
        private readonly ILogger _logger;

        public MatchController(IWebClient webClient, ILogger logger) : base(webClient, logger)
        {
            _webClient = webClient;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("OK");
        }

        // GET Match By Id
        [HttpGet("{region}/lol/match/v4/matches/{matchId}")]
        public async Task<ActionResult> GetMatchByID(string region, string matchId)
        {
            return await HandleWebRequest($"{region}/lol/match/v4/matches/{matchId}");
        }

        // GET MatchList ByAccount ID
        [HttpGet("{region}/lol/match/v4/matchlists/by-account/{encryptedAccountId}")]
        public async Task<ActionResult> GetMatchListByAccountID(string region, string encryptedAccountId)
        {
            return await HandleWebRequest($"{region}/lol/match/v4/matchlists/by-account/{encryptedAccountId}");
        }

        // GET Match Time line By Match ID
        [HttpGet("{region}/lol/match/v4/timelines/by-match/{matchId}")]
        public async Task<ActionResult> GetMatchTimelineByMatchID(string region, string matchId)
        {
            return await HandleWebRequest($"{region}/lol/match/v4/timelines/by-match/{matchId}");
        }

        // GET Match IDs By TournamentCode
        [HttpGet("{region}/lol/match/v4/matches/by-tournament-code/{tournamentCode}/ids")]
        public async Task<ActionResult> GetMatchIDsByTournamentCode(string region, string tournamentCode)
        {
            return await HandleWebRequest($"{region}/lol/match/v4/matches/by-tournament-code/{tournamentCode}/ids");
        }

        // GET Match By ID And Tournament Code
        [HttpGet("{region}/lol/match/v4/matches/{matchId}/by-tournament-code/{tournamentCode}")]
        public async Task<ActionResult> GetMatchByIDAndTournamentCode(string region, string matchId, string tournamentCode)
        {
            return await HandleWebRequest($"{region}/lol/match/v4/matches/{matchId}/by-tournament-code/{tournamentCode}");
        }
    }
}
