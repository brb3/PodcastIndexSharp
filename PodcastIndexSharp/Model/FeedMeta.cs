namespace PodcastIndexSharp.Model
{
    using System.Collections.Generic;

    public class FeedMeta : FeedBase
    {
        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public uint? iTunesId { get; set; } = null!;

        public string Language { get; set; } = null!;

        public Dictionary<uint, string> Categories { get; set; } = null!;
    }
}