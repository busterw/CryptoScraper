using CryptoScraper.Models;
using System.Threading.Tasks;

namespace CryptoScraper.KeywordLogic.Abstractions
{
    public interface IKeywordGrabberRequestSender
    {
        Task<string> GetAllTimeInterest(string keyword);
        Task<string> GetInterestForTimePeriod(string keyword, InterestPeriod interestPeriod);
    }
}
