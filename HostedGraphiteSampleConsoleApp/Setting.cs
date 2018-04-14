using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HostedGraphiteSampleConsoleApp
{
    public partial class Setting
    {
        [JsonProperty("api_access_interval")]
        public int ApiAccessInterval { get; set; }

        [JsonProperty("hosted_graphite_hostname")]
        public string HostedGraphiteHostName { get; set; }

        [JsonProperty("hosted_graphite_port")]
        public int HostedGraphitePort { get; set; }

        [JsonProperty("hosted_graphite_apikey")]
        public string HostedGraphiteApiKey { get; set; }

        [JsonProperty("hosted_graphite_metrics")]
        public string HostedGraphiteMetrics { get; set; }
    }
    public partial class Setting
    {
        public static Setting FromJson(string json) => JsonConvert.DeserializeObject<Setting>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Setting self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
