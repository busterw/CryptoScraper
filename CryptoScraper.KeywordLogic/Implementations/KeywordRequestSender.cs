using CryptoScraper.KeywordLogic.Abstractions;
using CryptoScraper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrpytoScraper.KeywordLogic.Implementations
{
    public class KeywordRequestSender : IKeywordRequestSender
    {
        private readonly HttpClient _httpClient;
        public KeywordRequestSender()
        {
            _httpClient = new HttpClient
            {
                //TODO move to config + DI in
                BaseAddress = new Uri("http://127.0.0.1:5001/")
            };
        }

        public async Task<string> GetAllTimeInterest(string keyword)
        {
            //TODO move request names to an enum
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, _httpClient.BaseAddress + "interestovertimeall/" + keyword);

            var response = await _httpClient.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                //TODO handle failures better / at all
            }

            var content = await response.Content.ReadAsStringAsync();

            return SanitiseJson(content);
        }

        public Task<string> GetInterestForTimePeriod(string keyword, InterestPeriod interestPeriod)
        {
            throw new NotImplementedException();
        }

        private static string SanitiseJson(string json)
            => '{' + json.Substring(0, json.Length - 19).Substring(23).Replace("\\", string.Empty) + '}';
    }
}
