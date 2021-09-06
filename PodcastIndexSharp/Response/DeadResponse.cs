namespace PodcastIndexSharp.Response
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using PodcastIndexSharp.JsonConverters;
    using PodcastIndexSharp.Model;

    public class DeadResponse : AbstractResponse
    {
        [JsonProperty("feeds")]
        public List<Podcast> Podcasts { get; set; }

        public int Count { get; set; }

        public int Max { get; set; }

        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime Since { get; set; }
    }
}