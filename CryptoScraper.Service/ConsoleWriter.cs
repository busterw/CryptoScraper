using CryptoScraper.KeywordLogic.Abstractions;
using CryptoScraper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoScraper.Service
{
    internal class ConsoleWriter
    {
        private readonly IKeywordDataAggregator _keywordDataAggregator;
        internal ConsoleWriter(IKeywordDataAggregator keywordDataAggregator) => _keywordDataAggregator = keywordDataAggregator;

        public async Task PrintStats(string assetName, string interestPeriod)
        {
            var interestPeriodEnum = Enum.Parse<InterestPeriod>(interestPeriod);

            var assetPricesOverTime = await _keywordDataAggregator.AggregateInterestByDateOverTimePeriod(assetName, interestPeriodEnum);

            foreach (var assetPricePoint in assetPricesOverTime)
                Console.WriteLine($"{assetPricePoint.Key}  :  {assetPricePoint.Value}");

        }
    }
}
