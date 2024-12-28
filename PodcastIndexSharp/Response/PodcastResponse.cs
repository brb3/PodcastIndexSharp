namespace PodcastIndexSharp.Response
{
    using Newtonsoft.Json;
    using PodcastIndexSharp.Model;

    public class PodcastResponse : AbstractResponse
    {
        [JsonProperty("feed")]
        public Podcast Podcast { get; set; } = null!;
    }
}