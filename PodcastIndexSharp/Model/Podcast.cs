namespace PodcastIndexSharp.Model
{
    using System;
    using System.Net;
    using Newtonsoft.Json;
    using PodcastIndexSharp.Enums;
    using PodcastIndexSharp.JsonConverters;

    public class Podcast : FeedMeta
    {
        public Uri OriginalUrl { get; set; }

        public Uri Link { get; set; }

        public string Description { get; set; }

        public string OwnerName { get; set; }

        public Uri Image { get; set; }

        public Uri Artwork { get; set; }

        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime LastUpdateTime { get; set; }

        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime LastCrawlTime { get; set; }

        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime LastParseTime { get; set; }

        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime LastGoodHttpStatusCode { get; set; }

        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime NewestItemPublishTime { get; set; }

        public HttpStatusCode LastHttpStatus { get; set; }

        public string ContentType { get; set; }

        public int? TrendScore { get; set; }

        public string Generator { get; set; }

        public FeedType Type { get; set; }

        public int? Dead { get; set; }

        public string Chash { get; set; }

        public int? EpisodeCount { get; set; }

        public int? CrawlErrors { get; set; }

        public int? ParseErrors { get; set; }

        public FeedLocked Locked { get; set; }

        public long? ImageUrlHash { get; set; }

        public Value Value { get; set; }

        public Funding Funding { get; set; }
    }
}