using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;
using System;
using System.Threading.Tasks;

namespace LeaguePlusWebApi.Interfaces
{
    public interface IWebClient
    {
        Task<string> GetFromUrl(string url);

        void AddHeadersForRiotApi();
    }
}
