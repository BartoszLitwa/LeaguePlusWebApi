using System.Net.Http;
using System.Threading.Tasks;

namespace LeaguePlus.Core
{
    public interface IWebClient
    {
        Task<HttpResponseMessage> GetFromUrl(string url, bool lolLink = true);

        string GetFullUrl(string url);

        void AddHeaders();
    }
}
