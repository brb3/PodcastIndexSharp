namespace PodcastIndexSharp.Response
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using PodcastIndexSharp.JsonConverters;
    using PodcastIndexSharp.Model;

    public class TrendingResponse : AbstractResponse
    {
        public List<Feed> Feeds { get; set; }

        public int Count { get; set; }

        public int Max { get; set; }

        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime Since { get; set; }
    }
}