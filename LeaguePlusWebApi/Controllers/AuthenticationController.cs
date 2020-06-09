using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeaguePlusWebApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaguePlusWebApi.Controllers
{
    [Authorize]
    [Route("api/")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

        public AuthenticationController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = _jwtAuthenticationManager.Authenticate(userCred.Username, userCred.Password);
            if (string.IsNullOrEmpty(token))
                return Unauthorized();

            return Ok(token);
        }

        [HttpGet("private/{jwtToken}")]
        public ActionResult NameAndPassword(string jwtToken)
        {
            return Ok("value");
        }
    }
}