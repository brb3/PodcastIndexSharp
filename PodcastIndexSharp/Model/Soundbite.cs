namespace PodcastIndexSharp.Model
{
    using System;

    public class Soundbite
    {
        public Uri EnclosureUrl { get; set; }

        public string Title { get; set; }

        public int StartTime { get; set; }

        public int Duration { get; set; }

        public long EpisodeId { get; set; }

        public string EpisodeTitle { get; set; }

        public string FeedTitle { get; set; }

        public Uri FeedUrl { get; set; }

        public int FeedId { get; set; }
    }
}