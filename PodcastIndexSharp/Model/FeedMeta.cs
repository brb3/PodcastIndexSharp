namespace PodcastIndexSharp.Model
{
    using System.Collections.Generic;

    public class FeedMeta : FeedBase
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public uint? iTunesId { get; set; }

        public string Language { get; set; }

        public Dictionary<uint, string> Categories { get; set; }
    }
}