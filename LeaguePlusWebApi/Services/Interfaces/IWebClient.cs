using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LeaguePlusWebApi
{
    public interface IWebClient
    {
        Task<HttpResponseMessage> GetFromUrl(string url, bool lolLink = true);

        string GetFullUrl(string url);

        void AddHeaders();
    }
}
