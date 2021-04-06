﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoScraper.Models
{

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
}
