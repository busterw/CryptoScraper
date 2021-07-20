using CryptoScraper.KeywordLogic.Abstractions;
using CryptoScraper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoScraper.KeywordLogic.Implementations
{
    public class KeywordDataAggregator : IKeywordDataAggregator
    {
        private readonly IKeywordRequestSender _keywordRequestSender;

        public KeywordDataAggregator(IKeywordRequestSender keywordRequestSender) => _keywordRequestSender = keywordRequestSender;

        /// <summary>
        /// Returns a dictionary containing a list of times, and the relevent keyword interest at that time
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public async Task<Dictionary<DateTime, int>> AggregateInterestByDateOverTimePeriod(string assetName, InterestPeriod period)
        {
            var keywordData = await _keywordRequestSender.GetInterestForTimePeriod(assetName, period);

            return keywordData.TimelineData.ToDictionary(d => Convert.ToDateTime(d.FormattedTime), v => v.Value.FirstOrDefault());
        }
    }
}
