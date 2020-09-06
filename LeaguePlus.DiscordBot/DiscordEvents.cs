using System.Threading.Tasks;

namespace LeaguePlus.DiscordBot
{
    public class DiscordEvents
    {
        #region Constructor

        public DiscordEvents()
        {

        }

        #endregion
        public async Task OnReadyAsync()
        {
            await Task.Delay(1);
        }
    }
}
