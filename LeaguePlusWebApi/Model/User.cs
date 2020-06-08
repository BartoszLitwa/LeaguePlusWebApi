using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeaguePlusWebApi.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public List<Summoner> summoners { get; set; }

        public Summoner userSummoner { get; set; }
    }
}
