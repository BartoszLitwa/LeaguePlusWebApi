using LeaguePlus.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LeaguePlusWebApi
{
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Created By Bartosz Litwa");
        }

        [HttpGet("jd")]
        public ActionResult jd()
        {
            return Ok("Jebac disa kurwe zwisa!");
        }

        [HttpPost("authenticate")]
        public ActionResult Authenticate([FromBody] UserCred userCred)
        {
            return Ok();
        }
    }
}