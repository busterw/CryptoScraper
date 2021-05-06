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

        public async Task<string> GetAllTimeInterest(string keyword)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get,
                _httpClient.BaseAddress
                + RequestName.InterestOverTimeAll.ToString()
                + '/'
                + keyword);

            var response = await _httpClient.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                //TODO handle failures better / at all
            }

            var content = await response.Content.ReadAsStringAsync();

            return SanitiseJson(content);
        }

        public async Task<string> GetInterestForTimePeriod(string keyword, InterestPeriod interestPeriod)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get,
               $"{_httpClient.BaseAddress}{RequestName.InterestOverTime.ToString()}/{keyword}/{interestPeriod.ToString()}");

            var response = await _httpClient.SendAsync(requestMessage);

            if (!response.IsSuccessStatusCode)
            {
                //TODO handle failures better / at all
            }

            var content = await response.Content.ReadAsStringAsync();

            return SanitiseJson(content);
        }

        /// <summary>
        /// Json object returned from google-trends-api has unwanted filler in the beginning and end,
        /// specifically the first 23 characters, and the last 19 characters. Probably a more readable
        /// way to do this.
        /// </summary>
        private static string SanitiseJson(string json)
            => '{' + json.Substring(0, json.Length - 19).Substring(23).Replace("\\", string.Empty) + '}';
    }
}
