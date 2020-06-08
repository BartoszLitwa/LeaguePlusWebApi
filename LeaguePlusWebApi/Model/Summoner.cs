using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaguePlusWebApi.Model
{
    public class Summoner
    {
        [Required]
        public string region { get; set; }

        [Required]
        public string summonerID { get; set; }
    }
}
