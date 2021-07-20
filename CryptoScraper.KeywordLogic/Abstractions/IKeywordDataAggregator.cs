using CryptoScraper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CryptoScraper.KeywordLogic.Abstractions
{
    public interface IKeywordDataAggregator
    {
        Task<Dictionary<DateTime, int>> AggregateInterestByDateOverTimePeriod(string assetName, InterestPeriod period);
    }
}
