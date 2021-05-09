namespace PodcastIndexSharp
{
    using System.Collections.Generic;
    using PodcastIndexSharp.Model;

    public class EpisodesResponse : AbstractResponse
    {
        public List<Episode> Episodes { get; set; }

        public int Count { get; set; }
    }
}