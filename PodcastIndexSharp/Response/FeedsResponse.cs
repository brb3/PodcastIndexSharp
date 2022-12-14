namespace PodcastIndexSharp.Response
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using PodcastIndexSharp.Model;

    public class FeedsResponse : AbstractResponse
    {
        [JsonProperty("feeds")]
        public List<Podcast> Podcasts { get; set; } = new List<Podcast>();

        public int Count { get; set; }
    }
}