using CryptoScraper.Models;
using System.Threading.Tasks;

namespace CryptoScraper.KeywordLogic.Abstractions
{
    public interface IKeywordRequestSender
    {
        Task<KeywordData> GetAllTimeInterest(string keyword);
        Task<KeywordData> GetInterestForTimePeriod(string keyword, InterestPeriod interestPeriod);
    }
}
