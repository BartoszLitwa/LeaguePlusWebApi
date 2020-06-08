﻿using LeaguePlusWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaguePlusWebApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SummonerController : ControllerBaseHandler
    {
        private readonly IConfiguration _configuration;
        private readonly IWebClient _webClient;

        public SummonerController(IConfiguration configuration, IWebClient webClient) : base(webClient)
        {
            _configuration = configuration;
            _webClient = webClient;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("OK");
        }

        // GET summoner by name
        [HttpGet("{region}/lol/summoner/v4/summoners/by-account/{account}")]
        public async Task<ActionResult> GetSummonerByAccount(string region, string account)
        {
            return await HandleWebRequest($"{region}/lol/summoner/v4/summoners/by-account/{account}");
        }

        // GET summoner by name
        [HttpGet("{region}/lol/summoner/v4/summoners/by-name/{summonerName}")]
        public async Task<ActionResult> GetSummonerByName(string region, string summonerName)
        {
            return await HandleWebRequest($"{region}/lol/summoner/v4/summoners/by-name/{summonerName}");
        }

        // GET summoner by name
        [HttpGet("{region}/lol/summoner/v4/summoners/by-puuid/{puuid}")]
        public async Task<ActionResult> GetSummonerByPuuid(string region, string puuid)
        {
            return await HandleWebRequest($"{region}/lol/summoner/v4/summoners/by-puuid/{puuid}");
        }

        // GET summoner by name
        [HttpGet("{region}/lol/summoner/v4/summoners/{id}")]
        public async Task<ActionResult> GetSummonerById(string region, string id)
        {
            return await HandleWebRequest($"{region}/lol/summoner/v4/summoners/{id}");
        }
    }
}