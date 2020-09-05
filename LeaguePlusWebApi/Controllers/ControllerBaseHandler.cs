using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaguePlusWebApi
{
    [Authorize]
    public class ControllerBaseHandler : ControllerBase
    {
        private readonly IWebClient _webClient;
        private readonly ILogger _logger;

        public ControllerBaseHandler(IWebClient webClient, ILogger logger)
        {
            _webClient = webClient;
            _logger = logger;
        }

        protected ControllerBaseHandler(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public async Task<ActionResult> HandleWebRequest(string url)
        {
            var response = await _webClient.GetFromUrl(url);
            if(response == null || !response.IsSuccessStatusCode)
            {
                _logger.LogError($"[{response.StatusCode}] Couldnt get the response from {url}");
                return StatusCode((int)response.StatusCode);
            }

            var json = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(json))
            {
                _logger.LogError($"[{response.StatusCode}] response from {url} is empty");
                return NotFound();
            }

            return Ok(json);
        }

        public async Task<string> GetJsonFromUrl(string url)
        {
            var response = await _webClient.GetFromUrl(url, false);
            if (response == null || !response.IsSuccessStatusCode)
            {
                _logger.LogError($"[{response.StatusCode}] Couldnt get the response from {url}");
                return null;
            }

            var json = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(json))
            {
                _logger.LogError($"[{response.StatusCode}] response from {url} is empty");
                return null;
            }

            return json;
        }
    }
}
