using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LeaguePlusWebApi
{
    public class WebClient : IWebClient
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private readonly HttpClient _client = new HttpClient();

        public WebClient(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;

            AddHeaders();
        }

        public async Task<string> GetFromUrl(string url)
        {
            if(string.IsNullOrEmpty(url))
            {
                _logger.LogError($"Given URL is blank.");
                return null;
            }

            var fullUrl = GetFullUrl(url);

            try
            {
                var response = await _client.GetAsync(fullUrl);
                if(response == null || !response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.TooManyRequests)
                        _logger.LogError($"Rate limit exceeded!");
                    else
                        _logger.LogError($"[{response.StatusCode}] Error while fetching data from {fullUrl}.");

                    return null;
                }

                string json = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(json))
                {
                    _logger.LogError($"[{response.StatusCode}] Couldnt get any response from {fullUrl}.");
                    return null;
                }

                return json;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while getting response from {fullUrl}. {ex.Message}");

                return null;
            }
        }

        public void AddHeaders()
        {
            _client.DefaultRequestHeaders.Add(name: "User-Agent", value: "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36");
            _client.DefaultRequestHeaders.Add(name: "Accept-Language", value: "pl-PL,pl;q=0.9,en-US;q=0.8,en;q=0.7");
            //_client.DefaultRequestHeaders.Add(name: "Accept-Charset", value: "application/x-www-form-urlencoded; charset=UTF-8");
            _client.DefaultRequestHeaders.Add(name: "Origin", value: "https://developer.riotgames.com");
            _client.DefaultRequestHeaders.Add(name: "X-Riot-Token", value: /*_configuration[KeyVaultData.ApiRiotKey])*/"RGAPI-2642e8ac-c03d-4dca-ae81-0638bcd81b96");
        }

        public string GetFullUrl(string url)
        {
            var region = url.Substring(0, url.IndexOf('/'));
            return $"https://{region}.api.riotgames.com/{url.Substring(url.IndexOf('/') + 1)}";
        }
    }
}
