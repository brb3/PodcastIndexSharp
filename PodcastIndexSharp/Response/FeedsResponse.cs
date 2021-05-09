namespace PodcastIndexSharp.Response
{
    using System.Collections.Generic;
    using PodcastIndexSharp.Model;

    public class FeedsResponse : AbstractResponse
    {
        public List<Feed> Feeds { get; set; }

        public int Count { get; set; }
    }
}