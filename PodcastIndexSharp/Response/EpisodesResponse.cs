namespace PodcastIndexSharp.Response
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using PodcastIndexSharp.Model;

    public class EpisodesResponse : AbstractResponse
    {
        // This is used so that `items` and `episodes` can be supported in the JSON response.
        // Note that "/episodes/random" and "/episodes/byfeedid" use an otherwise similar structure.
        private List<Episode> _episodes;

        [JsonProperty("items")]
        public List<Episode> Episodes
        {
            get { return _episodes ?? RandomEpisodes; }
            set { _episodes = value; }
        }

        [JsonProperty("episodes")]
        public List<Episode> RandomEpisodes { get; set; }

        public int Count { get; set; }
    }
}