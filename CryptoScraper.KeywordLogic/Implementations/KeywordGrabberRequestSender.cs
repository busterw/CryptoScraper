using CryptoScraper.KeywordLogic.Abstractions;
using CryptoScraper.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrpytoScraper.KeywordLogic.Implementations
{
    public class KeywordGrabberRequestSender : IKeywordGrabberRequestSender
    {
        private readonly HttpClient _httpClient;
        public KeywordGrabberRequestSender()
        {
            _httpClient = new HttpClient
            {
                //TODO move to config
                BaseAddress = new Uri("http://127.0.0.1:5001/")
            };
        }
        public async Task<string> GetAllTimeInterest(string keyword)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, _httpClient.BaseAddress + "interestovertimeall/" + keyword);

            var response = await _httpClient.SendAsync(requestMessage);

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        public Task<string> GetInterestForTimePeriod(string keyword, InterestPeriod interestPeriod)
        {
            throw new NotImplementedException();
        }
    }
}
