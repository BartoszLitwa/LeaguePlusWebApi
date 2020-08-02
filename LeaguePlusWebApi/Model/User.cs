using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeaguePlusWebApi
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        public List<Summoner> summoners { get; set; }

        public Summoner userSummoner { get; set; }
    }
}
