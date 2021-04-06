using Newtonsoft.Json;
using System.Collections.Generic;

namespace CryptoScraper.Models
{
    public class KeywordData
    {
        [JsonProperty("timelineData")]
        public List<TimelineData> TimelineData { get; set; }
    }
}

