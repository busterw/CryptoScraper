using CryptoScraper.Models;
using System.Threading.Tasks;

namespace CryptoScraper.KeywordLogic.Abstractions
{
    public interface IKeywordRequestSender
    {
        Task<TimelineDataWithAverages> GetAllTimeInterest(string keyword);
        Task<TimelineDataWithAverages> GetInterestForTimePeriod(string keyword, InterestPeriod interestPeriod);
    }
}
