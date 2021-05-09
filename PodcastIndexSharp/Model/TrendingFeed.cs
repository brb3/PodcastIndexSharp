namespace PodcastIndexSharp.Model
{
    using System;
    using Newtonsoft.Json;
    using PodcastIndexSharp.JsonConverters;

    public class TrendingFeed : FeedMeta
    {
        public Uri Image { get; set; }

        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime NewestItemPublishedTime { get; set; }

        public int TrendScore { get; set; }
    }
}