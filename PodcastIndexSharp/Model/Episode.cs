namespace PodcastIndexSharp.Model
{
    using System;
    using Newtonsoft.Json;
    using PodcastIndexSharp.Enums;
    using PodcastIndexSharp.JsonConverters;

    public class Episode
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public Uri Link { get; set; }

        public string Description { get; set; }

        public string Guid { get; set; }

        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime DatePublished { get; set; }

        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime DateCrawled { get; set; }

        public Uri EnclosureUrl { get; set; }

        public string EnclosureType { get; set; }

        public long EnclosureLength { get; set; }

        public int Minutes { get; set; }

        public Explicit Explicit { get; set; }

        [JsonProperty("Episode")]
        public int? EpisodeNumber { get; set; }

        public string EpisodeType { get; set; }

        public int Season { get; set; }

        public Uri Image { get; set; }

        public int? FeedItunesId { get; set; }

        public int FeedId { get; set; }

        public Uri FeedUrl { get; set; }

        public string FeedAuthor { get; set; }

        public string FeedTitle { get; set; }

        public string FeedLanguage { get; set; }

        public Uri ChaptersUrl { get; set; }

        public Uri TranscriptUrl { get; set; }
    }
}