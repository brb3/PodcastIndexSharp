namespace PodcastIndexSharp.Response
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using PodcastIndexSharp.Model;

    public class CategoriesListResponse : AbstractResponse
    {
        [JsonProperty("feeds")]
        public List<Category> Categories { get; set; }

        public int Count { get; set; }
    }
}