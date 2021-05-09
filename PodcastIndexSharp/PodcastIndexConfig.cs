namespace PodcastIndexSharp
{
    public class PodcastIndexConfig
    {
        public const string Section = "PodcastIndex";

        public string BaseUrl { get; set; } = "https://api.podcastindex.org/api/1.0/";

        public string UserAgent { get; set; } = "PodcastIndexSharp";

        public string AuthKey { get; set; }

        public string Secret { get; set; }
    }
}