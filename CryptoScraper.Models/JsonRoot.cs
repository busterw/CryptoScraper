using Newtonsoft.Json;
using System.Collections.Generic;

namespace CryptoScraper.Models
{
    public class JsonRoot
    {
        [JsonProperty("success")]
        public string Success { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}

public class TimelineData
{
    [JsonProperty("time")]
    public string Time { get; set; }

    [JsonProperty("formattedTime")]
    public string FormattedTime { get; set; }

    [JsonProperty("formattedAxisTime")]
    public string FormattedAxisTime { get; set; }

    [JsonProperty("value")]
    public List<int> Value { get; set; }

    [JsonProperty("hasData")]
    public List<bool> HasData { get; set; }

    [JsonProperty("formattedValue")]
    public List<string> FormattedValue { get; set; }
}

public class Root
{
    [JsonProperty("default")]
    public TimelineDataWithAverages Default { get; set; }
}

public class TimelineDataWithAverages
{
    [JsonProperty("timelineData")]
    public List<TimelineData> TimelineData { get; set; }
    [JsonProperty("averages")]
    public List<object> Averages { get; set; }
}