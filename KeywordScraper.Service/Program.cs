using CrpytoScraper.KeywordLogic.Implementations;
using CryptoScraper.KeywordLogic.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace KeywordScraper.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var sp = new ServiceCollection()
                .AddTransient<IKeywordGrabberRequestSender, KeywordGrabberRequestSender>()
                .BuildServiceProvider();


            //TEMPORARY TEST code that calls KeyWordScrapperRequestSender
            var temprequestsender = new KeywordGrabberRequestSender();
            var tempResult = temprequestsender.GetAllTimeInterest("test").Result;
        }
    }
}
