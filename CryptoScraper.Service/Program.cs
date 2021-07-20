using CrpytoScraper.KeywordLogic.Implementations;
using CryptoScraper.KeywordLogic.Abstractions;
using CryptoScraper.KeywordLogic.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

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
            services.AddTransient<IKeywordDataAggregator, KeywordDataAggregator>();

            var provider = services.BuildServiceProvider();

            //TEMPORARY TEST code that calls KeyWordScrapperRequestSender
            var consoler = new ConsoleWriter(provider.GetRequiredService<IKeywordDataAggregator>());

            consoler.PrintStats("ETH", "Week").Wait();
        }
    }
}
