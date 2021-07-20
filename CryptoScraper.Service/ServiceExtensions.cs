using CrpytoScraper.KeywordLogic.Implementations;
using CryptoScraper.KeywordLogic.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace CryptoScraper.Service
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRequestSender(this ServiceCollection services, IConfiguration configuration)
        {
            return services.AddSingleton<IKeywordRequestSender, KeywordRequestSender>(
                sp => new KeywordRequestSender(
                    new HttpClient
                    {
                        BaseAddress = new Uri(configuration["Keyword:Url"])
                    }));
        }
    }
}
