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
        public KeywordRequestSender(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<TimelineDataWithAverages> GetAllTimeInterest(string keyword)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get,
                $"{_httpClient.BaseAddress}{RequestName.InterestOverTimeAll.ToString()}/{keyword}");

            var response = await _httpClient.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                //TODO handle failures better / at all
            }

            var content = await response.Content.ReadAsStringAsync();

            var jsonRootContent = JsonConvert.DeserializeObject<JsonRoot>(content);

            var rootContent = JsonConvert.DeserializeObject<Root>(jsonRootContent.Body);

            return rootContent.Default;
        }

        public async Task<TimelineDataWithAverages> GetInterestForTimePeriod(string keyword, InterestPeriod interestPeriod)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get,
               $"{_httpClient.BaseAddress}{RequestName.InterestOverTime.ToString()}/{keyword}/{interestPeriod.ToString()}");

            var response = await _httpClient.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                //TODO handle failures better / at all
            }

            var content = await response.Content.ReadAsStringAsync();

            var jsonRootContent = JsonConvert.DeserializeObject<JsonRoot>(content);

            var rootContent = JsonConvert.DeserializeObject<Root>(jsonRootContent.Body);

            return rootContent.Default;
        }
    }
}
