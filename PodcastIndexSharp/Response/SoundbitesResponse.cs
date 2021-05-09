namespace PodcastIndexSharp.Response
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using PodcastIndexSharp.Model;

    public class SoundbitesResponse : AbstractResponse
    {
        [JsonProperty("items")]
        public List<Soundbite> Soundbites { get; set; }

        public int Count { get; set; }
    }
}