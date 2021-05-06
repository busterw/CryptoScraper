using CrpytoScraper.KeywordLogic.Implementations;
using CryptoScraper.KeywordLogic.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CryptoScraper.Service
{
    static class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var services = new ServiceCollection();

            services.AddRequestSender(configuration);
            var provider = services.BuildServiceProvider();

            //TEMPORARY TEST code that calls KeyWordScrapperRequestSender
            var temprequestsender = provider.GetRequiredService<KeywordRequestSender>();
            var tempResult = temprequestsender.GetAllTimeInterest("ethereum").Result;
        }
    }
}
