using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;
using System;
using System.Threading.Tasks;

namespace LeaguePlusWebApi
{
    public interface IWebClient
    {
        Task<string> GetFromUrl(string url);

        string GetFullUrl(string url);

        void AddHeaders();
    }
}
