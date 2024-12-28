namespace PodcastIndexSharp.Model
{
    using System;
    using Newtonsoft.Json;
    using PodcastIndexSharp.Enums;
    using PodcastIndexSharp.JsonConverters;

    public class Episode
    {
        public long Id { get; set; }

        public string Title { get; set; } = null!;

        public Uri Link { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Guid { get; set; } = null!;

        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime DatePublished { get; set; }

        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime DateCrawled { get; set; }

        public Uri EnclosureUrl { get; set; } = null!;

        public string EnclosureType { get; set; } = null!;

        public long EnclosureLength { get; set; }

        public int? Duration { get; set; }

        public Explicit Explicit { get; set; }

        [JsonProperty("Episode")]
        public int? EpisodeNumber { get; set; }

        public string EpisodeType { get; set; } = null!;

        public int? Season { get; set; }

        public Uri Image { get; set; } = null!;

        public int? FeedItunesId { get; set; }

        public Uri FeedImage { get; set; } = null!;

        public int? FeedId { get; set; }

        public Uri FeedUrl { get; set; } = null!;

        public string FeedAuthor { get; set; } = null!;

        public string FeedTitle { get; set; } = null!;

        public string FeedLanguage { get; set; } = null!;

        public Uri ChaptersUrl { get; set; } = null!;

        public Uri TranscriptUrl { get; set; } = null!;
    }
}