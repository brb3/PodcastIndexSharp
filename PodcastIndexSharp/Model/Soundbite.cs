namespace PodcastIndexSharp.Model
{
    using System;

    public class Soundbite
    {
        public Uri EnclosureUrl { get; set; } = null!;

        public string Title { get; set; } = null!;

        public int StartTime { get; set; }

        public int Duration { get; set; }

        public long EpisodeId { get; set; }

        public string EpisodeTitle { get; set; } = null!;

        public string FeedTitle { get; set; } = null!;

        public Uri FeedUrl { get; set; } = null!;

        public int FeedId { get; set; }
    }
}