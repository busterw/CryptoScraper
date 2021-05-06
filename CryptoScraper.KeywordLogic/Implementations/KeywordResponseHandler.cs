using CryptoScraper.KeywordLogic.Abstractions;
using CryptoScraper.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CrpytoScraper.KeywordLogic.Implementations
{
    public class KeywordResponseHandler
    {
        private readonly IKeywordRequestSender _keywordGrabberRequestSender;
        public KeywordResponseHandler(IKeywordRequestSender keywordGrabberRequestSender)
        {
            _keywordGrabberRequestSender = keywordGrabberRequestSender;
        }

        public async Task HandleKeywordResponse(string keyword)
        {
            var content = await _keywordGrabberRequestSender.GetAllTimeInterest(keyword);

            var deserializedContent = JsonConvert.DeserializeObject<KeywordData>(content);
        }
    }
}
