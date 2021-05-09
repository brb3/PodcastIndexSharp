namespace PodcastIndexSharp.Model
{
    using System.Collections.Generic;

    public class FeedMeta : FeedBase
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int? iTunesId { get; set; }

        public string Language { get; set; }

        public Dictionary<string, string> Categories { get; set; }
    }
}