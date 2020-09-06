using System.Threading.Tasks;

namespace LeaguePlus.DiscordBot
{
    class Program
    {
        static async Task Main(string[] args) => await new DiscordBotClient().InitializeAsync().ConfigureAwait(false);
    }
}
