using LeaguePlusWebApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaguePlusWebApi.Controllers
{
    [Authorize]
    public class ControllerBaseHandler : ControllerBase
    {
        private readonly IWebClient _webClient;

        public ControllerBaseHandler(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<ActionResult> HandleWebRequest(string url)
        {
            var response = await _webClient.GetFromUrl(url);
            if (string.IsNullOrEmpty(response))
                return NotFound();

            return Ok(response);
        }
    }
}
