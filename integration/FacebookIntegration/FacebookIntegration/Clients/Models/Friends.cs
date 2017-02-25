using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace FacebookIntegration.Clients.Models
{
    class Friends
    {
        [JsonProperty("data")]
        public List<object> Data { get; set; }

        [JsonProperty("summary")]
        public FriendsSummary Summary { get; set; }
    }

    class FriendsSummary
    {
        [JsonProperty("total_count")]
        public int Count { get; set; }
    }
}