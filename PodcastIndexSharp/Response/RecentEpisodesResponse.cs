namespace PodcastIndexSharp.Response
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using PodcastIndexSharp.Model;

    public class RecentEpisodesResponse : AbstractResponse
    {
        [JsonProperty("items")]
        public List<Episode> Episodes { get; set; } = new List<Episode>();
    }
}