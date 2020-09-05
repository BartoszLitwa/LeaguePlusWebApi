using System.ComponentModel.DataAnnotations;

namespace LeaguePlus.Core
{
    public class Summoner
    {
        [Required]
        public string region { get; set; }

        [Required]
        public string puuid { get; set; }
    }
}
